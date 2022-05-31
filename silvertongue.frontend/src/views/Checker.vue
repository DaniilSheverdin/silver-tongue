<template>
	<div class="checker-container">
		<h1>Поиск ошибок в тексте</h1>
		<hr/>
		<div class="checkerContent-container">
			<p id='info'>Для проверки текста введите слово или фразу</p>
			<form name='textForm'>
				<div  class="form-group">
					<textarea placeholder="What's your story?" v-model="text" class="form-control" name="text"></textarea>
				</div>
				
				<div class="form-group">
          <button class="btn_ btn-block customButton" :disabled="loading" @click.prevent="handleCheck">
            <span
              v-show="loading"
              class="spinner-border spinner-border-sm"
            ></span>
            <span>Проверить</span>
          </button>
        </div>
        <div class="form-group">
          <div v-if="message" class="alert alert-danger" role="alert">
            {{ message }}
          </div>
        </div>
			</form>
			<hr/>
			<div v-if='!isNotChecked&&errorList.length!=0'>
				<h2>Исправления орфографических ошибок:</h2>
				<hr/>
				<textarea readonly='true' v-model="errorList" class="form-control" name="text">
				</textarea>
			</div>
			<p class="info_2 correct" v-else-if="!isNotChecked">Орфографические ошибки не найдены</p>
			<p v-if="!isNotChecked" v-bind:class="[result.isGrammarCorrect? 'correct': 'error', 'info_2']">Грамматические ошибки {{grammarMessage}}</p>
			<div>
				<h2>Последние ошибки:</h2>
				<ul>
					<li v-for="i in archive" :key="i.checkID">
						{{i}}
					</li>
				</ul>
			</div>
			<p v-if="!isNotChecked">{{result}}</p>
			<p>{{text}}</p>
		</div>
	</div>
</template>

<script lang="ts">
	import { ICheck } from '@/types/Check';
import {Component, Vue} from 'vue-property-decorator'
import { CheckerService } from '@/services/checker-service'
import { ISpellError } from '@/types/SpellError';

const checkerService=new CheckerService();
	@Component(
		{
			name: 'Checker',
			components: {}
		}
	)
	export default class Checker extends Vue{
		archive: ICheck[]=[{checkID:-1, date:"", phrase:"", isGrammarCorrect: true, isSpellCorect:true, errors:[]}];
		loading: boolean = false;
  	message: string = "";
		isVoiceInput: boolean = false;
		text='';
		isNotChecked=true;
		errorList='';
		result: ICheck={date:'', isGrammarCorrect:false, isSpellCorect:false, errors:[], checkID:0, phrase:this.text };
		async handleCheck(){
			this.result= await (await checkerService.getResult(this.text));
			this.isNotChecked=false;
			this.result.errors.forEach(element => {
				this.errorList=element.word+" - "+element.optionsSequence+"\n";
			});
		}
		get grammarMessage(){
			return this.result.isGrammarCorrect? "не найдены" : "найдены";
		}
		async initialize(){
			this.archive=await checkerService.getArchive();
		}
		async created(){
			await this.initialize();
		}
	}
</script>



<style lang='scss'>
	.checkerContent-container{
		width:100%;
		display: flex;
		flex-direction: column;
	}
	#info{
		font-style: italic;
		font-weight: 300;
		font-size: 24px;
		line-height: 39px;
	}
	.info_2{
		font-style: normal;
		font-weight: 300;
		font-size: 18px;
		line-height: 28px;
		text-align: center;
	}
	.form-control{
		margin-bottom: 2vh;
	}
	.correct{
		background-color:#7fd764;
		color:white;
	}
	.error{
		color:white;
		background-color: rgb(189, 0, 0);
	}
	.btn_{
		display: inline-block;
    font-weight: 400;
    line-height: 1.5;
    text-align: center;
    text-decoration: none;
    vertical-align: middle;
    cursor: pointer;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    background-color: transparent;
    border: 1px solid transparent;
    padding: 0.375rem 0.75rem;
    font-size: 1rem;
    border-radius: 0.25rem;
    transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
		background-color: black;
		color: #ffff;
		border: none;
	}
</style>

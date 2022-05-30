<template>
	<div class="checker-container">
		<h1>Поиск ошибок в тексте</h1>
		<hr/>
		<div class="checkerContent-container">
			<p class='info'>Для проверки текста введите слово или фразу</p>
			<form name='textForm'>
				<div  class="form-group">
					<textarea placeholder="What's your story?" v-model="text" class="form-control" name="text"></textarea>
				</div>
				
				<div class="form-group">
          <button class="btn btn-primary btn-block" :disabled="loading" @click.prevent="handleCheck">
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
			<div v-if='!isNotChecked&&errorList.length!=0'>
				<h2>Исправления орографических ошибок:</h2>
				<hr/>
				<textarea readonly='true' v-model="errorList" class="form-control" name="text">
				</textarea>
			</div>
			<p class="info" v-if="result.isGrammarCorrect && !isNotChecked" style="background-color:#7fd764;color:white">Грамматические ошибки не найдены</p>
			<p class="info" v-if="!result.isGrammarCorrect && !isNotChecked">Найдены грамматические ошибки</p>
			<div>
				<h2>Последние ошибки:</h2>
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
	}
</script>



<style lang='scss'>
	.checkerContent-container{
		width:100%;
		display: flex;
		flex-direction: column;
	}
	.info{
		font-style: italic;
		font-weight: 300;
		font-size: 24px;
		line-height: 39px;
	}
	.form-control{
		margin-bottom: 2vh;
	}
</style>

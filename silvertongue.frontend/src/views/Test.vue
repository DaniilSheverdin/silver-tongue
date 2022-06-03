<template>
	<div class="test-container">
		<h1>{{title}}</h1>
		<p>{{about}}</p>
		<hr />
		<form>
			<ol v-if='count!=0'>
				<li v-for="i in count" :key="i">
					{{ test[i-1].question?test[i-1].question:""}}
					<div v-for='j in test[i-1].options.length' :key="j">
						<input v-model="answers[i-1]" type="radio" :id='test[i - 1].options[j - 1].id' onMouseDown="this.isChecked=this.checked;"
							onClick="this.checked=!this.isChecked;" :value="test[i-1].options[j-1].id">
						<label :for='test[i - 1].options[j - 1].id'>{{test[i-1].options[j-1].value}}</label>
						<br />
					</div>
				</li>
				
			</ol>
			<div class="form-group">
				<button class="btn_ btn-block customButton" :disabled="loading" @click.prevent="handleSubmit()">
					<span v-show="loading" class="spinner-border spinner-border-sm"></span>
					<span>Проверить</span>
				</button>
			</div>
		</form>
		<div v-if='!isNotChecked'>{{result}}</div>
	</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { TestService } from '@/services/test-service'
import { IOneTest } from '@/types/OneTest';
const testService = new TestService();
@Component(
	{
		name: 'Test',
		components: {}
	}
)
export default class Test extends Vue {
	title:any;
	about:any;
	answers=[];
	id:any;
	result:any;
	loading: boolean = false;
	count:number=0;
	test: IOneTest[]=[];
	isNotChecked=true;
 	async initialize() {
		this.test = await testService.getTest(this.id);
			this.count = this.test?this.test.length:0;
	}
	async created() {
		this.title = localStorage.getItem('testTitle');
		this.about = localStorage.getItem('testAbout');
		this.id = localStorage.getItem('testID');
		await this.initialize();
	}
	constructor(){
		super();
		this.test=[{question:"",options:[{id:1,value:""}]}];
		this.count=0;
	}
	destroyed(){
		localStorage.setItem('testTitle', '');
		localStorage.setItem('testAbout', '');
		localStorage.setItem('testID', '');
	}
	async handleSubmit(){
		this.result=await testService.getResult(this.answers, this.id);
		this.isNotChecked=false;
	}
	get Result(){
		return this.result;
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
		input {
			-webkit-appearance: none;
			-moz-appearance: none;
			appearance: none;
	
			border-radius: 50%;
			width: 16px;
			height: 16px;
	
			border: 2px solid #999;
			transition: 0.2s all linear;
			outline: none;
			margin-right: 5px;
	
			position: relative;
			top: 4px;
		}
	
		input:checked {
			border: 6px solid black;
		}
</style>
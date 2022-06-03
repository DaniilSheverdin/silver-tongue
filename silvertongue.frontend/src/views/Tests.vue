<template>
	<div class="tests-container">
		<h1>Тесты</h1>
		<hr/>
		<div v-if="getSize()>=1">
			<form v-for="i in getSize()" :key="i">
				<h2>{{tests[i-1].title}}</h2>
				<p>{{tests[i-1].about}}</p>
				<button class="btn btn-primary btn-block" @click.prevent='handleNewTest(tests[i-1].id,
				tests[i-1].title, tests[i-1].about)'>
            <span>Вход</span>
        </button>
			</form>
		</div>
		
	</div>
</template>

<script lang="ts">
	import {Component, Vue} from 'vue-property-decorator'
	import { TestService } from '@/services/test-service'
	import { ITest } from '@/types/Test';
	import { namespace } from "vuex-class";

	const testService=new TestService();
	const Test = namespace("Test");
	@Component(
		{
			name: 'Tests',
			components: {}
		}
	)
	export default class Tests extends Vue{
		@Test.Action
		getTest!: (data: any) => Promise<any>;
		tests: ITest[]=[{id:1,title:"", about:""}];
		a=0;
		count=0;
		message="";
		check=false;
		async initialize(){
			this.tests=await testService.getTests();
			this.check=true;
		}
		async created(){
			await this.initialize();
		}
	  getSize(){
			return this.tests.length;
		}

		handleNewTest(id: number, title: string, about: string) {
			localStorage.setItem("testTitle",title);
			localStorage.setItem("testAbout", about);
			localStorage.setItem("testID", JSON.stringify(id));
			
			this.$router.push("/test");
    };
  
	}
</script>

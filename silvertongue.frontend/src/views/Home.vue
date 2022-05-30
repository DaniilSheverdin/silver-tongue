<template>
	<div class="home-container">
		<h1>Привет, {{ currentUser.name }}!</h1>
		<hr/>
		<div id='rating-container'>
			<div id='userRating'>
				<p class='userInfo'>Твое место в рейтинге: {{rating.indexOf(lvl)+1}}</p>
				<p class='userInfo'>Сумма очков: {{lvl.points}}</p>
				<p id='about'>Используй обучающие материалы, тренируй орфографию и грамматику, запоминай новые слова в своем словаре, проверяй уровень знаний с помощью тестов и увеличивай свой рейтинг!</p>
			</div>
			<div id='ratingTable'><h2>Рейтинг пользователей</h2>
				<table class='table' v-if='getSize()>=10'>
					<tr v-for='index in 10' :key="index" :style="[lvl.name===rating[index-1].name?{'background-color':'#7fd764', 'color':'white'}:{}]">
						<td>{{index.toString()+" место"}}</td>
						<td>{{rating[index-1].name}}</td>
						<td >{{rating[index-1].points}}</td>
					</tr>
				</table>
				<table id='ratingTable' class='table' v-else>
					<tr v-for='index in getSize()' :key="index" :style="[lvl.name===rating[index-1].name?{'background-color':'#7fd764', 'color':'white'}:{}]">
						<td>{{index.toString()+" место"}}</td>
						<td>{{rating[index-1].name}}</td>
						<td>{{rating[index-1].points}}</td>
					</tr>
				</table>
			</div>
		</div>	
	</div>
</template>

<script lang="ts">
	import { IRating } from '@/types/UserRating';
	import {Component, Vue} from 'vue-property-decorator'
	import { RatingService } from '@/services/rating-serivce'
	import { namespace } from "vuex-class";
	const Auth = namespace("Auth");

	const ratingService=new RatingService();
	@Component(
		{
			name: 'Home',
			components: {}
		}
	)
	

	export default class Home extends Vue{
		rating: IRating[]=[
			{points:33, name: "Здесь"},
			{points:22, name: "Должен"},
			{points:33, name: "Быть"},
			{points:33, name: "Ответ"},
			{points:33, name: "БЫКэнда"}
		];
		lvl:IRating={points:33, name: "Здесь"}
		async initialize(){
			this.rating=await ratingService.getRating();
			await this.getLvl()
		}
		async created(){
			await this.initialize();
		}
		getSize(){
				return this.rating? this.rating.length:0;
		}
		// ✅ Find first object whose value matches condition\
		async getLvl(){
			const lvl_=this.rating.find(obj => obj!.name===this.currentUser.name);
			this.lvl=lvl_?lvl_:this.lvl;
		}
		
		@Auth.State("user")
		currentUser!: any;
		mounted() {
			if (!this.currentUser) {
				this.$router.push("/login");
			}
		}
	}
</script>

<style lang='scss'>
	#rating-container {
		display: flex;
		flex-direction: row;

		width: 84%;
		margin-bottom:2vh;
		margin-top: 4.5vh;
	}
	#userRating{
		width: 50%;
		margin-right: 7vw;
	}
	.userInfo{
		font-style: italic;
		font-weight: 300;
		font-size: 24px;
		line-height: 38px;
	}
	#about{
		margin-top: 10vh;
		font-weight: 400;
		font-size: 16px;
		line-height: 28px;
		font-style: normal;
	}
	#ratingTable{
		width: 40%;
    margin-left: auto;
    margin-right: auto;
		
	}
	#ratingTable table{
		position: fixed;
		padding-right:25vw;
	}
	#ratingTable h2{
		margin-bottom: 2vh;
		font-size: 2vw;
	}
</style>

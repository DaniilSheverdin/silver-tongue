<template>
	<div class="home-container">
		<h1>Привет, {{ currentUser.name }}!</h1>
		<hr/>
		<div id='rating-container'>
			<div id='userRating'>
				<p>Твое место в рейтинге: {{rating.indexOf(lvl)+1}}</p>
			</div>
			<div id='ratingTable'><h2>Рейтинг пользователей</h2>
				<table class='table' v-if='getSize()>=10'>
					<tr v-for='index in 10' :key="index">
						<td>{{index.toString()+" место"}}</td>
						<td>{{rating[index-1].name}}</td>
						<td>{{rating[index-1].points}}</td>
					</tr>
				</table>
				<table id='ratingTable' class='table' v-else>
					<tr v-for='index in getSize()' :key="index">
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
		position: fixed;
		display: flex;
		flex-direction: row;
		justify-content: space-between;
		width: 100%;
		margin-bottom:2vh;
		margin-top: 4.5vh;
	}
	#userRating{
		
		width:50%;
	}
	#ratingTable{
		width: 50%;
	}
	#ratingTable h2{
		margin-bottom: 2vh;
	}
</style>

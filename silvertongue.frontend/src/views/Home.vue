<template>
	<div class="home-container">
		<h1>Привет, UserName!</h1>
		<hr/>
		<div id='rating-container'>
			<div id='userRating'>
				<p>Твое место в рейтинге</p>
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

	const ratingService=new RatingService();
	@Component(
		{
			name: 'Home',
			components: {}
		}
	)
	

	export default class Home extends Vue{
		rating: IRating[]=[
			{id:1, points:33, name: "Здесь"},
			{id:2, points:22, name: "Должен"},
			{id:3, points:33, name: "Быть"},
			{id:4, points:33, name: "Ответ"},
			{id:5, points:33, name: "БЫКэнда"}
		];
		async initialize(){
			this.rating=await ratingService.getRating();
		}
		async created(){
			await this.initialize();
		}
		getSize(){
				return this.rating? this.rating.length:0;
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

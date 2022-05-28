<template>
	<div class="side-menu-container">
		<router-link to="/"><img id="imgLogo" alt="Vue logo" src="../assets/logo.png"></router-link> 
		<stongue-button :link="'tests'" is-full-width>
			Тесты
		</stongue-button>
		<stongue-button :link="'tests'" is-full-width>
			Мой словарь
		</stongue-button>
		<stongue-button :link="'tests'" is-full-width>
			Орфография
		</stongue-button>
		<stongue-button :link="'tests'" is-full-width>
			Грамматика
		</stongue-button>
		<stongue-button :link="'tests'" is-full-width>
			Материалы
		</stongue-button>
		<a href @click.prevent="logOut">
			<img id="exitBtn" alt="Exit" src="../assets/exit.svg">
		</a>
		
	</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import StongueButton from './StongueButton.vue';
import { namespace } from "vuex-class";

const Auth = namespace("Auth");
@Component({
	name: 'SideMenu',
	components:{ StongueButton}
})

export default class SideMenu extends Vue{
	@Auth.State("user")
  private currentUser!: any;
  @Auth.Action
  private signOut!: () => void;

	 logOut() {
    this.signOut();
    this.$router.push("/login");
  }
}
</script>

<style scoped lang="scss">
	@import "@/scss/global.scss";
	.side-menu-container{
		background-color: #CFFF93;
		height: 100vh;
		width: $menu-width;
		display: flex;
		flex-direction: column;
		box-sizing: border-box;
		padding: 0.6vw;
		justify-content: space-between;
	}
	#imgLogo{
		width: 10vw;
		padding-top: 1.8vh;
		padding-bottom: 1.8vh;
	}
	#exitBtn{
		width: 50%;
		align-items: flex-start;
  	flex: 1 0 auto;
	}
</style>
<template>
	<div class="side-menu-container">
		<router-link to="/"><img id="imgLogo" alt="Vue logo" src="../assets/logo.png"></router-link> 
	</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({
	name: 'SideMenu',
	components:{}
})

export default class SideMenu extends Vue{}
</script>

<style scoped lang="scss">
	@import "@/scss/global.scss";
	.side-menu-container{
		background-color: #CFFF93;
		height: 100vh;
		width: $menu-width;
		display: flex;
		flex-direction: column;
		padding: 0.8 rem;
		box-sizing: border-box;
	}
	#imgLogo{
		width: $menu-width;
	}
</style>
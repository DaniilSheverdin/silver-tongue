<template>
	<div class="btn-link">
		<button @click="visitRoute"
			:class="['stongue-button', {'full-width': isFullWidth}]"
		>
			<slot></slot>
		</button>
	</div>
</template>

<script lang="ts">
	import Vue from 'vue'
	import Component from 'vue-class-component'
	import {Prop} from 'vue-property-decorator'

	@Component(
		{
			name: 'StongueButton',
			components: { }
		}
	)
	export default class StongueButton extends Vue{
		@Prop({required: false, type: String})
		link?: string;

		@Prop({required: false, type: Boolean, default: false})
		isFullWidth?: boolean;

		visitRoute(){
			const path = `/${this.link}`
			if (this.$route.path !== path) this.$router.push(path)

		}
	}
</script>

<style scoped lang="scss">
	@import "@/scss/global.scss";

	.full-width{
		display: block;
		width: 100%;
	}
	.stongue-button{
		background: black;
		cursor: pointer;
		color: white;
		padding: 0.5em;
		font-size: 2vh;
		font-weight: 600;
		box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
		&:hover{
			background: white;
			border-color: black;
			color: black;
		}
	}
	
</style>
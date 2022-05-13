<template>
	<div class="home-container">
		<h1>This is a Home page</h1>
		<hr/>
	</div>
</template>

<script lang="ts">
	import {Component, Vue} from 'vue-property-decorator'

	@Component(
		{
			name: 'Home',
			components: {}
		}
	)
	export default class Home extends Vue{}
</script>

<template>
	<div class="tests-container">
		<h1>This is a Tests page</h1>
	</div>
</template>

<script lang="ts">
	import {Component, Vue} from 'vue-property-decorator'

	@Component(
		{
			name: 'Tests',
			components: {}
		}
	)
	export default class Tests extends Vue{}
</script>

<template>
	<Home />
</template>

<style lang="scss">
	$turquoise: #795548;
	$grey-light:   hsl(0, 0%, 60%);
	$grey-lighter: hsl(0, 0%, 70%);
	@import '~bulma/bulma.sass';
	* {
		font-family: $family-primary;
	}
</style>

<script>
	import Home from './home/Home.vue';
	export default {
		name: 'app',
		components: { Home }
	}
</script>

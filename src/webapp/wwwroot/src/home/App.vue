<template>
	<Home />
</template>

<style lang="scss">
	$turquoise: #3F51B5;
	$grey-light:   hsl(0, 0%, 60%);
	$grey-lighter: hsl(0, 0%, 70%);
	@import '~bulma/bulma.sass';
	* {
		font-family: $family-primary;
	}
</style>

<script>
	import Home from './Home.vue';
	export default {
		name: 'app',
		components: { Home }
	}
</script>

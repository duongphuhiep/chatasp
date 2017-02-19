<template>
	<Home />
</template>

<style lang="scss">
	@import '../assets/global.scss';
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

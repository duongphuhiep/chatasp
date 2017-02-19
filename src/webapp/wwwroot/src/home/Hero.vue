<template>
	<section class="hero is-primary">
		<div class="hero-body">
			<div class="container">
				<div class=" columns">
					<div class="column is-half">
						<h1 class="title">
							CHATASP
						</h1>
						<h2 class="subtitle">
							A crowd free chatting forum
						</h2>
					</div>
					<div class="column is-half">
						<Login></Login>
					</div>
				</div>
			</div>
		</div>
	</section>
</template>
<script>
	import Login from './Login.vue';
	
	export default {
		components: {Login}
	}
</script>
<style lang='scss' scoped>
	.title {
		font-weight: 900
	}
	.label {
		color: white
	}
</style>

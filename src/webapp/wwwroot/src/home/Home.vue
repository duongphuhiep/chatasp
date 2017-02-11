<template>
	<div>
		<Hero />
		<div class="section container">
			<div class="columns">
				<div class="column is-half has-top-margin">
					<h1 class="title">Fantastic features!</h1>
					<ul>
						<li>
							<h2 class="subtitle">Freedom</h2>
						</li>
						<li>
							<h2 class="subtitle">Anonymous</h2>
						</li>
						<li>
							<h2 class="subtitle">Security</h2>
						</li>
						<li>
							<h2 class="subtitle">Crowding</h2>
						</li>
					</ul>
				</div>
				<RegisterForm class="column is-half" />
			</div>
		</div>
	</div>
</template>

<script>
	import Hero from './Hero.vue';
	import RegisterForm from './RegisterForm.vue';
	export default {
		name: 'app',
		components: { Hero, RegisterForm }
	}
</script>

<template>
	<div>
		<Hero />
		<div class="section container">
			<div class="columns">
				<div class="column is-half has-top-margin">
					<div v-if='bye'>
						<h1 class="title">Bye</h1>
						<h2 class="subtitle">Thanks for stopping by!</h2>
						<h2>We hope to see you again soon.</h2>
					</div>
					<div v-else>
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
				</div>
				<RegisterForm class="column is-half" />
			</div>
		</div>
	</div>
</template>

<script>
	import Hero from './Hero.vue';
	import RegisterForm from './RegisterForm.vue';
	import queryStringParser from 'querystring';
	
	export default {
		name: 'app',
		components: { Hero, RegisterForm },
		data() {
			let queryString = window.location.search.substr(1);
			let c = queryStringParser.parse(queryString);
			return {
				"bye": c.bye
			}
		}
	}
</script>

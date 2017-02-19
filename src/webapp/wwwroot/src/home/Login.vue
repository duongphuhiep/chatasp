<template>
	<div>
		<form class="control is-grouped" @submit.prevent='login'>
			<div class='control is-expanded'>
				<label for="Login" class="label">Login</label>
				<input id="Login" v-model="form.Login" :class='{"input":true, "is-paddingless":true, "is-danger": valerr.Login}' type="text"
					placeholder="User name or Email" />
				<span class="help is-danger" v-if="valerr.Login">{{valerr.Login}}</span>
			</div>

			<div class='control is-expanded'>
				<label for="Password" class="label">Password</label>
				<input id="Password" v-model="form.Password" :class='{"input":true, "is-paddingless":true, "is-danger": valerr.Password}'
					type="password" placeholder="password" />
				<span class="help is-danger" v-if="valerr.Password">{{valerr.Password}}</span>
			</div>

			<div class='control'>
				<label class="label">&nbsp;</label>
				<button id="submit" class="button">Login</button>
			</div>
		</form>
		
		<div v-if='status' class="red">
			{{status}}
		</div>
	</div>
</template>

<style lang="scss" scoped>
	@import '../assets/global.scss';
	.red {
		color: $red;
	}
	.label {
		color: $white-ter;
	}
</style>

<script>
	import axios from "axios";

	class FormData {
		constructor() {
			this.Login = "";
			this.Password = "";
		}
	}

	export default {
		methods: {
			login(e) {
				axios.post('/Home/Login', this.form)
					.then(e => {
						if (e.data.user) {
							//the user is logged, return to home page as a logged user
							window.location = '/';
						}
						else {
							this.status = "Bad login or password";
						}
					})
					.catch(error => {
						let r = error.response;
						console.log(r.status);
						if (r) {
							if (r.status == 400)
								this.valerr = r.data;
						}
						else
							alert(error);
					});
			}
		},

		data() {
			return {
				form: new FormData(),
				valerr: {}, //validation errors
				status: null
			}
		}
	}
</script>

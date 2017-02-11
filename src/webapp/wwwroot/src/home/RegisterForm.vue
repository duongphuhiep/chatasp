<template>
	<form @submit.prevent='registerUser'>
		<p class="control">
			<label for="NickName" class="label">Nick name</label>
			<input id="NickName" v-model="form.NickName" type="text" class="input">
		</p>

		<p class="control">
			<label for="Email" class="label">Email</label>
			<input id="Email" v-model="form.Email" type="text" class="input">
		</p>

		<p class="control">
			<label for="Password" class="label">Password</label>
			<input id="Password" v-model="form.Password" type="password" class="input">
		</p>

		<p class="control">
			<label for="ConfirmPassword" class="label">Confirm Password</label>
			<input id="ConfirmPassword" v-model="form.ConfirmPassword" type="password" class="input">
		</p>

		<p class="control">
			<label for="FirstName" class="label">First name</label>
			<input id="FirstName" v-model="form.FirstName" type="text" class="input">
		</p>

		<p class="control">
			<label for="LastName" class="label">Last name</label>
			<input id="LastName" v-model="form.LastName" type="text" class="input">
		</p>

		<p class="control"><button type="submit" class="button is-primary is-large">Sign Up</button></p>
	</form>
</template>

<script>
	import axios from "axios";

	class FormData {
		constructor() {
			this.NickName = "";
			this.Email = "";
			this.Password = "";
			this.ConfirmPassword = "";
			this.FirstName = "";
			this.LastName = "";
		}
	}

	export default {
		methods: {
			registerUser(e) {
				axios.post('/api/v1.0/Users/Register', this.form)
				.then(e => {
					console.info(e);
					Console.log('OK');
				})
				.catch((error)=>{
					
					Console.log('Failed');
				});
			}
		},
		data() {
			return {form: new FormData()};
		}
	}
</script>

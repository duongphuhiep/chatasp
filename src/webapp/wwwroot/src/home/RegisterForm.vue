<template>
	<form @submit.prevent='registerUser'>
		<label for="NickName" class="label">Nick Name</label>
		<p :class='{"control": true, "has-icon": valerr.NickName, "has-icon-right": valerr.NickName}'>
			<input id="NickName" v-model="form.NickName" type="text" :class='{"input": true, "is-danger": valerr.NickName}'>
			<span class="icon is-small" v-if="valerr.NickName">
				<i class="fa fa-warning"></i>
			</span>
			<span class="help is-danger" v-if="valerr.NickName">{{valerr.NickName}}</span>
		</p>

		<label for="Email" class="label">Email</label>
		<p :class='{"control": true, "has-icon": valerr.Email, "has-icon-right": valerr.Email}'>
			<input id="Email" v-model="form.Email" type="text" :class='{"input": true, "is-danger": valerr.Email}'>
			<span class="icon is-small" v-if="valerr.Email">
				<i class="fa fa-warning"></i>
			</span>
			<span class="help is-danger" v-if="valerr.Email">{{valerr.Email}}</span>
		</p>

		<label for="Password" class="label">Password</label>
		<p :class='{"control": true, "has-icon": valerr.Password, "has-icon-right": valerr.Password}'>
			<input id="Password" v-model="form.Password" type="password" :class='{"input": true, "is-danger": valerr.Password}'>
			<span class="icon is-small" v-if="valerr.Password">
				<i class="fa fa-warning"></i>
			</span>
			<span class="help is-danger" v-if="valerr.Password">{{valerr.Password}}</span>
		</p>

		<label for="ConfirmPassword" class="label">Confirm Password</label>
		<p :class='{"control": true, "has-icon": valerr.ConfirmPassword, "has-icon-right": valerr.ConfirmPassword}'>
			<input id="ConfirmPassword" v-model="form.ConfirmPassword" type="password" :class='{"input": true, "is-danger": valerr.ConfirmPassword}'>
			<span class="icon is-small" v-if="valerr.ConfirmPassword">
				<i class="fa fa-warning"></i>
			</span>
			<span class="help is-danger" v-if="valerr.ConfirmPassword">{{valerr.ConfirmPassword}}</span>
		</p>

		<label for="FirstName" class="label">First Name</label>
		<p :class='{"control": true, "has-icon": valerr.FirstName, "has-icon-right": valerr.FirstName}'>
			<input id="FirstName" v-model="form.FirstName" type="text" :class='{"input": true, "is-danger": valerr.FirstName}'>
			<span class="icon is-small" v-if="valerr.FirstName">
				<i class="fa fa-warning"></i>
			</span>
			<span class="help is-danger" v-if="valerr.FirstName">{{valerr.FirstName}}</span>
		</p>

		<label for="LastName" class="label">Last Name</label>
		<p :class='{"control": true, "has-icon": valerr.LastName, "has-icon-right": valerr.LastName}'>
			<input id="LastName" v-model="form.LastName" type="text" :class='{"input": true, "is-danger": valerr.LastName}'>
			<span class="icon is-small" v-if="valerr.LastName">
				<i class="fa fa-warning"></i>
			</span>
			<span class="help is-danger" v-if="valerr.LastName">{{valerr.LastName}}</span>
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
				.catch(error=>{
					if (error.response && error.response.status==400)
						this.valerr = error.response.data;
					else
						alert(error);
				});
			}
		},

		data() {
			return {
				form: new FormData(),
				valerr: {}
			};
		}
	}
</script>

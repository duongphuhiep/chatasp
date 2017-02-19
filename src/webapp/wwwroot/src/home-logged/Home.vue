<template>
	<div>
		<h1>Welcome {{ user.nickName }}</h1>
		<p>{{ user.email }}</p>
		<a href="/Home/Logout">Log Out</a>
	</div>
</template>

<script>
	import axios from 'axios';

	export default {
		data () {
			return {
				user: {}	
			}
		},
		mounted() {
			axios.get('/Home/GetProfile')
				.then(e => {
					this.user = e.data;
				})
				.catch(error => {
					alert(error);
				});
		}
	}
</script>

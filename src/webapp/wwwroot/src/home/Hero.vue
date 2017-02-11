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
						<form class="control is-grouped">
							<div class='control is-expanded'>
								<label for="login" class="label">Login</label>
								<input id="login" class="input is-paddingless" type="text" placeholder="Username or Email" />
							</div>
							<div class='control is-expanded'>
								<label for="password" class="label">Password</label>
								<input id="password" class="input is-paddingless" type="password" placeholder="password" />
							</div>
							<div class='control'>
								<label class="label">&nbsp;</label>
								<button id="submit" class="button">Login</button>
							</div>
						</form>
					</div>
				</div>
			</div>
		</div>
	</section>
</template>
<script>
	export default {
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

<template>
	<div>
		<h1>LOGIN</h1>
		<div class="container">
			<div class="row">
				<div class="col">
				</div>
				<div class="col">
					<form @submit="login">
						<input class="form-control form-control-lg" v-model="username" placeholder="username" />
						<br />
						<input class="form-control form-control-lg" v-model="password" placeholder="password" type="password" />
						<br />
						<button class="btn btn-lg btn-primary" type="submit">Login</button>
					</form>
				</div>
				<div class="col">
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	import { mapMutations } from "vuex";	
	export default {
		data: () => {
			return {
				username: "",
				password: "",
			};
		},
		methods: {
			...mapMutations(["setUser", "setToken"]),
			async login(e) {
				e.preventDefault();
				const response = await fetch("https://dohled.liberec.cz/api/Member/Authentication", {
					method: "POST",
					headers: {
						"Content-Type": "application/json",
					},
					body: JSON.stringify({
						username: this.username,
						password: this.password,
					}),
				});
				const { user, token } = await response.json();
				if (token != null) {
					this.setUser(user);
					this.setToken(token);
					localStorage.setItem('token', JSON.stringify(token));
					this.$router.push("/data");					
				}
			},
		},
	};
</script>
<template>
	<div id="nav">
		<!--<router-link to="/">Home</router-link>-->
		<!--<router-link v-if="isLoggedIn" to="/data">Data</router-link>-->
		<!--<router-link to="/about">About</router-link>-->
		
		<router-link v-if="!isLoggedIn" to="/login">Login</router-link>
	</div>
	<router-view />
</template>

<style>
	#app {
		/*font-family: Audiowide, Andada, Avenir, Helvetica, Andada, Arial, sans-serif;*/
		-webkit-font-smoothing: antialiased;
		-moz-osx-font-smoothing: grayscale;
		text-align: center;
		color: #000000;
		/*2c3e50*/
	}

	#nav {
		padding: 30px;
	}

		#nav a {
			font-weight: bold;
			color: #2c3e50;
		}

			#nav a.router-link-exact-active {
				color: #42b983;
			}
</style>
<script>
	import { mapGetters } from "vuex";
	export default {
		computed: {
			...mapGetters(["isLoggedIn"])
		},
		beforeCreate() {
			if (!this.$store.state.isLoggedIn) {
				this.$router.push("/login");
			}
		}
	};
</script>

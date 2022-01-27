<template>
	<div id="nav">
		<router-link to="/">Home</router-link>
		<router-link to="/data">Data</router-link>
		<router-link to="/about">About</router-link>
	</div>
	<router-view />

	<button class="btn btn-primary" data-bs-target="#collapseTarget" data-bs-toggle="collapse">
		Bootstrap collapse
	</button>
	<div class="collapse py-2" id="collapseTarget">
		This is the toggle-able content!
	</div>
</template>

<style>
	/*@import url('https://fonts.googleapis.com/css?family=Audiowide');*/
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

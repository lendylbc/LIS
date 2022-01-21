<template>
	<div class="board">
		<h1>{{ msg }}</h1>
		<p>
			<a href="https://www.libereckais.cz" target="_blank" rel="noopener">Liberecká IS</a>.
		</p>
		<h3>Možnosti</h3>
		<ul>
			<li><a href="https://www.libereckais.cz" target="_blank" rel="noopener">Pøehled senzorù</a></li>
			<li><a href="https://www.libereckais.cz" target="_blank" rel="noopener">Pøehled výstupù</a></li>
		</ul>
	</div>
</template>

<script>
	export default {
		name: 'Dashboard',
		props: {
			msg: String
		}
	}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
	h3 {
		margin: 40px 0 0;
	}

	ul {
		list-style-type: none;
		padding: 0;
	}

	li {
		display: inline-block;
		margin: 0 10px;
	}

	a {
		color: #42b983;
	}
</style>

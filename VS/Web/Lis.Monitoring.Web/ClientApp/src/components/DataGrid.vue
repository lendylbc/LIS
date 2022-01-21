<template>
	<div class="grid">
		<h1>{{ msg }}</h1>
		<p>
			<a href="https://www.libereckais.cz" target="_blank" rel="noopener">data1</a>.
			<a href="https://www.libereckais.cz" target="_blank" rel="noopener">data2</a>.
		</p>
		<ul>
			<li v-for="item in playlist" v-bind:key="item.name">{{ item.name }}</li>
		</ul>
	</div>
</template>

<script>
	export default {
		name: 'DataGrid',
		props: {
			msg: String
		},
		data() {
			return {
				// example playlist array
				playlist: [
					{
						id: 123,
						name: 'teplota 1',
					},
					{
						id: 124,
						name: 'teplota 2',
					},
				],
			};
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

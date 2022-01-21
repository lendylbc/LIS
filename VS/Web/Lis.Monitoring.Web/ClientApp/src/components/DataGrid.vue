<template>
	<div class="grid">
		<div class="grid-container">
			<div class="grid-item">1</div>
			<div class="grid-item">2</div>
			<div class="grid-item">3</div>
			<div class="grid-item">4</div>
			<div class="grid-item">
				<h1>{{ msg }}</h1>
			</div>
			<div class="grid-item">
				<table style="width:30%">
					<tr>
						<th style="text-align:left">Id</th>
						<th style="text-align:left">Text</th>
						<th style="text-align:right">Teplota</th>
					</tr>
					<tr v-for="item in playlist" v-bind:key="item.name"><td style="text-align:left">{{ item.id }}</td><td style="text-align:left">{{ item.name }}</td><td style="text-align:right">{{ item.value }}</td></tr>
				</table>
			</div>
		</div>
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
						value: 25.4
					},
					{
						id: 124,
						name: 'teplota 2',
						value: 25.8
					},
					{
						id: 125,
						name: 'teplota 3',
						value: 28.6
					},
					{
						id: 126,
						name: 'teplota 4',
						value: 27.1
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

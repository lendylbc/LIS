<template>
		<div class="container">			
			<div class="row">
				<h2>{{ msg }}</h2>
			</div>
			<div class="row">
				<div class="col">
				</div>
				<div class="col">
					<table class="table table-striped" style="width: 30%">
						<tr class="table-color">
							<th class="align-left">IP</th>
							<th class="align-left">Port</th>
							<th class="align-right">Popis</th>
							<th class="align-right">Aktivní</th>
						</tr>
						<tr class="table-color" v-for="item in gridData" v-bind:key="item.id">
							<td class="align-left">{{ item.ipAddress }}</td>
							<td class="align-left">{{ item.port }}</td>
							<td class="align-right">{{ item.description }}</td>
							<td class="align-right">{{ item.active }}</td>
						</tr>
					</table>
				</div>
				<div class="col">
				</div>
			</div>
		</div>
</template>

<script>
	export default {
		name: 'DataGrid',
		props: {
			msg: String,
			gridData: [],
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

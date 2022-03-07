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
						<th class="align-left">Popis zařízení</th>
						<th class="align-left">Parametr</th>
						<th class="align-left">Datum odečtu</th>
						<th class="align-right">Hodnota</th>
					</tr>
					<tr class="table-color table-active-color" :style="[item.errorDetected ? {'background': '#dc3545'} : {'background': '#198754'}] " v-for="item in gridData" v-bind:key="item.id">
						<td class="align-left">{{item.deviceDesc}}</td>
						<td class="align-left">{{item.paramDesc}}</td>
						<td class="align-right">{{item.inserted}}</td>
						<td class="align-right">{{ValueUnitData(item)}}</td>						
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
		},
		methods: {
			ValueUnitData(item) {
				if (item.valueType == 1) {
					return item.value == null ? "" : item.value + item.unit;
				} else if (item.valueType == 2) {
					return item.valueString == null ? "" : item.valueString;
				} else {
					return "";
				}
			}
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

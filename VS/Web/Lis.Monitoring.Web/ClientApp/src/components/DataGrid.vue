<template>
	<div class="container">
		<div class="row">
			<h2>{{ msg }}</h2>
		</div>		
	</div>
	<table class="table center">
		<tr class="table-active-color">
			<th nowrap class="align-left">Popis zařízení</th>
			<th nowrap class="align-left">Parametr</th>
			<th nowrap class="align-right">Datum odečtu </th>
			<th nowrap class="align-right">Hodnota</th>
		</tr>
		<tr class="table-active-color" :style="[item.errorDetected ? {'background': '#dc3545'} : {'background': '#198754'}] " v-for="item in gridData" v-bind:key="item.id">
			<td nowrap class="align-left">{{item.deviceDesc}}</td>
			<td nowrap class="align-left">{{item.paramDesc}}</td>
			<td nowrap class="align-right">{{dateFormat(item.inserted)}}</td>
			<td nowrap class="align-right">{{ValueUnitData(item)}}</td>
		</tr>
	</table>
</template>

<script>
	import moment from 'moment'
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
			},
			dateFormat(date) {
				if (date == null) {
					return ""
				} else {
					return moment(date).format("DD.MM.YYYY HH:mm");
				}
			}
		},		
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

	.center {
		margin-left: auto;
		margin-right: auto;
		width: 80%;
	}
</style>

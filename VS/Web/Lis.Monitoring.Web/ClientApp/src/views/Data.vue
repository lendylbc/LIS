<template>
	<div class="data">
		<img alt="LIS logo" src="../assets/logo.png">
		<div>
			<button class="btn btn-primary btn-lg" data-bs-target="#collapseTarget" data-bs-toggle="collapse">
				Test zabalení
			</button>
			<div class="collapse py-2" id="collapseTarget">
				<div class="alert alert-success">
					<strong>Úspěšně!</strong> Indikace stavů.
				</div>
				<div class="alert alert-info">
					<strong>Info!</strong> Informace.
				</div>
				<div class="alert alert-danger">
					<strong>Chyba!</strong> Pozor pozor!!!
				</div>
			</div>
		</div>
		<br />
		<div>
			<button class="btn btn-lg btn-primary" @click="getAllData">Stáhni všechna data</button>
		</div>
		<br />
		<div v-if="isError">
			<div class="alert alert-danger">
				<strong>Chyba!</strong> Chyba načtení dat!!!
			</div>
		</div>
		<div v-else-if="isLoading"><div class="spinner-border text-info"></div></div>
		<div v-else>
			<DataGrid msg="Message" v-bind:gridData="gridData" />
		</div>
	</div>
</template>

<script>
	// @ is an alias to /src
	import DataGrid from '@/components/DataGrid.vue'
	import apiClient from '@/common/httpCommon.js';
	export default {
		name: 'Data',
		components: {
			DataGrid
		},
		data() {
			return {
				getResult: null,
				gridData: [],
				page: 0,
				size: 0,
				isLoading: false,
				isError: false,
			}
		},
		methods: {
			fortmatResponse(res) {
				return JSON.stringify(res.data, null, 2);
			},

			async getAllData() {
				try {
					this.isLoading = true;
					const res = await apiClient.get("Device/Get");

					const result = {
						status: res.status + "-" + res.statusText,
						headers: res.headers,
						data: res.data,
					};

					this.getResult = this.fortmatResponse(result);
					var json = JSON.parse(this.getResult);
					this.page = json["page"];
					this.size = json["size"];
					this.gridData = json["data"];
				} catch (err) {
					this.isError = true;
					this.getResult = this.fortmatResponse(err.response?.data) || err;
				} finally {
					this.isLoading = false;
				}
			},
		}
	}
</script>

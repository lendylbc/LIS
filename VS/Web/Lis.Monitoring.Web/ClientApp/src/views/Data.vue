<template>
	<div class="data">
		<img alt="LIS logo" src="../assets/logo.png">
		<button class="btn btn-sm btn-primary" @click="getAllData">Get All</button>
		<div v-if="getResult" class="alert alert-secondary mt-2" role="alert"><pre>{{getResult}}</pre></div>
		<DataGrid msg="Lis monitoring system" />
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
			}
		},
		methods: {
			fortmatResponse(res) {
				return JSON.stringify(res, null, 2);
			},

			async getAllData() {
				try {
					const res = await apiClient.get("Device/Get");

					const result = {
						status: res.status + "-" + res.statusText,
						headers: res.headers,
						data: res.data,
					};

					this.getResult = this.fortmatResponse(result);
				} catch (err) {
					this.getResult = this.fortmatResponse(err.response?.data) || err;
				}
			},
		}
	}
</script>

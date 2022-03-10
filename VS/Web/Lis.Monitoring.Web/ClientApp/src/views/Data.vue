<template>
	<div class="data">
		<img alt="LIS logo" src="../assets/logo.png">
		
		<div v-if="isError">
			<div class="alert alert-danger">
				<strong>Chyba!</strong> Chyba načtení dat!!!
			</div>
		</div>
		<div v-else-if="isLoading"><div class="spinner-border text-info"></div></div>
		<div v-else>
			<DataGrid msg="Přehled hlídaných parametrů" v-bind:gridData="gridData" />
		</div>
	</div>
</template>

<script>
	// @ is an alias to /src
	import DataGrid from '@/components/DataGrid.vue'
	import apiClient from '@/common/httpCommon.js';
	import { mapGetters } from "vuex";
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

			formatResponse(res) {
				return JSON.stringify(res.data, null, 2);
			},

			async getAllData() {
				try {
					this.isLoading = true;
					let token = JSON.parse(localStorage.getItem('token'));
					const res = await apiClient.get("DeviceData/GetLastDataAllActiveDevices", {
						headers: {
							Authorization: `Bearer ` + token
						}
					});

					const result = {
						status: res.status + "-" + res.statusText,
						headers: res.headers,
						data: res.data,
					};

					this.getResult = this.formatResponse(result);
					var json = JSON.parse(this.getResult);
					this.page = json["page"];
					this.size = json["size"];
					this.gridData = json["data"];
				} catch (err) {
					this.isError = true;
					this.getResult = this.formatResponse(err.response?.data) || err;
					this.$router.push("/login");
				} finally {
					this.isLoading = false;
				}
			},

		},
		mounted() {
			this.getAllData();
			this.timer = setInterval(this.getAllData, 60000);
		},
		computed: {
			...mapGetters(["getToken"])
		}
	}
</script>

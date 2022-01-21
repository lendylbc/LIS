<template>
  <div class="data">
    <img alt="LIS logo" src="../assets/logo.png">
    <DataGrid msg="Lis monitoring system"/>
  </div>
</template>

<script>
// @ is an alias to /src
	import DataGrid from '@/components/DataGrid.vue'

export default {
  name: 'Data',
      components: {
			DataGrid
  }
}
</script>

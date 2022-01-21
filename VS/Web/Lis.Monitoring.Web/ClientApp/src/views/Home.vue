<template>
  <div class="home">
    <img alt="LIS logo" src="../assets/logo.png">
    <Dashboard msg="Lis monitoring system"/>
  </div>
</template>

<script>
// @ is an alias to /src
	import Dashboard from '@/components/Dashboard.vue'

export default {
  name: 'Home',
      components: {
         Dashboard
  }
}
</script>

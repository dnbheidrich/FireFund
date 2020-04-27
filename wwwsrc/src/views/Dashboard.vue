<template>
  <div class="dashboard container-fluid">
    <div class="row text-center">
      <div class="col-12">
    <h1 class="text-warning">WELCOME TO THE DASHBOARD</h1>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {
    this.getRooms();
  },
   methods:{
     async getRooms(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getMyRooms");
    }
  }
  },
  computed: {
    rooms() {
      return this.$store.state.rooms;
    },
  },
 
};
</script>

<style></style>

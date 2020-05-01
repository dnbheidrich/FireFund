<template>
  <div class="room component text-center">
  <div class="col-12">
     <div class="card">
      <img :src="roomData.imgUrl" alt="">
      <div class="card-body">
        <h4 class="card-title">{{roomData.name}}</h4>
        <p class="card-text">{{roomData.description}}</p>
        </div>
  </div>
  </div>



  </div>
</template>


<script>
export default {
  name: 'component',
  data(){
    return {
    }
  },
  props: ["roomData"],
  computed:{},
  methods:{
     addRoom() {
      this.$store.dispatch("addRoom", this.newRoom);
    },
  },
  components:{}
}
</script>


<style scoped>

</style>
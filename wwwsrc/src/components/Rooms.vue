<template>
  <div class="room component text-center">
  <div class="col-12">
    router
     <div class="card">
        <router-link
        :to="{ name: 'RoomDetails', params: { roomId: this.roomData.id } }"
      >
      <img :src="roomData.imgUrl" alt="">
        </router-link>
      <div class="card-body">
        <h4 class="card-title">{{roomData.name}}</h4>
        <p class="card-text">{{roomData.description}}</p>
        <button type="danger">Delete</button>
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
<template>
  <div class="component">

<h1 class="text-white">Welcome to {{activeRoom.name}}</h1>
  </div>
</template>


<script>
export default {
  name: 'RoomDetails',
  props: ["roomData"],
   mounted() {
     this.getRooms();
     
  },
  data(){
    return {}
  },
  computed:{
    room() {
      return this.$store.state.rooms;
    },
    activeRoom(){
      return this.$store.state.activeRoom
    }
  },
  methods:{
     async getRooms(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getMyRooms");
      if (!this.$store.state.rooms.length) {
      this.$store.dispatch("getRoomById", this.$route.params.roomId);
    } else {
      this.$store.dispatch(
      "setActiveRoom",
      this.$store.state.rooms.find(c => c.id == this.$route.params.roomId)
      );
    }
      }
  }
  },
  components:{}
}
</script>


<style scoped>

</style>
<template>
  <div class="component">

<h1 class="text-white">Welcome to {{activeRoom.name}}</h1>
  <div class="row text-center">
  <div class="col-12">



<h1>Create Room</h1>
<form @submit.prevent="addRoom">
      <input
        v-model="newRoom.Name"
        type="text"
        name="make"
        placeholder="Name..."
        
      />
      <input
       v-model="newRoom.Description" required
        type="text"
        name="model"
        placeholder="Description..."
      />
      <input
      v-model="newRoom.ImgUrl"
        type="text"
        name="year"
        placeholder="ImgUrl..."
      />
       <button type="submit" class="btn btn-success">Submit</button>
    </form>
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
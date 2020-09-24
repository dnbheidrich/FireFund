<template>
  <div class="dashboard container-fluid">
    <div class="row text-center">
      <div class="col-12">
    <h1 class="text-center text-warning">WELCOME TO THE DASHBOARD</h1>
      </div>
    </div>
    <div class="row text-center">
  <div class="col-12">



<h1 class="text-center text-warning">Create Room</h1>
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
</div>
    <div class="row">
      <rooms v-for="room in room" :key="room.id" :roomData="room" />
    </div>
  </div>
</template>

<script>
import rooms from "../components/Rooms"
export default {
  mounted() {
    this.getRooms();
  },
  data(){
    return {
       newRoom: {
        Name: "",
        Description: "",
        ImgUrl: "",
      },
    }
  },

   methods:{
     async getRooms(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getMyRooms");
    }
  },
   addRoom() {
      this.$store.dispatch("addRoom", this.newRoom);
  }
  },
  computed: {
    room() {
      return this.$store.state.rooms;
    },
  },
  components: {
    rooms
  },
 
};
</script>

<style></style>

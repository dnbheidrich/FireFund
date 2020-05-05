<template>
  <div class="component">

<h1 class="text-white">Welcome to {{activeRoom.name}}</h1>

<h1>Create Category</h1>
<form @submit.prevent="">
      <input
        v-model="newCategory.Name"
        type="text"
        name="make"
        placeholder="Name..."
        
      />
      <input
       v-model="newCategory.Description" required
        type="text"
        name="model"
        placeholder="Description..."
      />
      <input
      v-model="newCategory.ImgUrl"
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
    return {
       newCategory: {
        Name: "",
        Description: "",
        ImgUrl: "",
      },
    }
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
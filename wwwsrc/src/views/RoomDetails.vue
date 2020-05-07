<template>
  <div class="component">

<h1 class="text-white">Welcome to {{activeRoom.name}}</h1>

<h1>Create Category</h1>
<form @submit.prevent="addCategory">
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
    // this.getCategories();
  },
  data(){
    return {
       newCategory: {
        Name: "",
        Description: "",
        ImgUrl: "",
        RoomId: this.$route.params.roomId
      },
    }
  },
  computed:{
    room() {
      return this.$store.state.rooms;
    },
    activeRoom(){
      return this.$store.state.activeRoom
    },
     categories() {
      return this.$store.state.categories;
    },
  },
  methods:{
     addCategory() {
       debugger
      this.$store.dispatch("addCategory", this.newCategory);
  },
   async getCategories(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getMyCategories");
      }
   },
     async getRooms(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getRoomById", this.$route.params.roomId);
        if (!this.$store.state.rooms.length) {
      this.$store.dispatch("getCategoriesByRoomId", this.$route.params.roomId);
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
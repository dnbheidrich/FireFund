<template>
  <div class="component">

<h1 class="text-center text-warning">Welcome to {{activeRoom.name}}</h1>

<h1 class="text-center text-warning">Create Category</h1>
<form class="text-center" @submit.prevent="addCategory">
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
    <div class="row">
      <categories v-for="categories in myCategories" :key="categories.id" :categoriesData="categories" />
    </div>
  </div>
</template>


<script>
import Categories from "../components/Categories"

export default {
  name: 'RoomDetails',
  props: ["roomData"],
   mounted() {
    this.getRooms();
    this.getCategories();
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
     myCategories() {
      return this.$store.state.categories.reverse();
    },
  },
  methods:{
     addCategory() {
      // RoomId comes in as string if reloaded on page
      this.$store.dispatch("addCategory", this.newCategory);
  },
   async getCategories(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getCategoriesByRoomId", this.$route.params.roomId);
      }
   },
     async getRooms(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getRoomById", this.$route.params.roomId);
        if (!this.$store.state.rooms.length) {
      this.$store.dispatch("getMyRooms");
    } else {
      this.$store.dispatch(
      "setActiveRoom",
      this.$store.state.rooms.find(c => c.id == this.$route.params.roomId)
      );
    }
      }
  },
  
  },
  components:{
    Categories
  }
}
</script>


<style scoped>

</style>
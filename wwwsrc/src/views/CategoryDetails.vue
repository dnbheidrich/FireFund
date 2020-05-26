<template>
  <div class="CategoryDetails">
<h1>Create Item</h1>
<form @submit.prevent="addItem">
      <input
        v-model="newItem.Name"
        type="text"
        name="make"
        placeholder="Name..."
        
      />
      <input
       v-model="newItem.Description"
        type="text"
        name="model"
        placeholder="Description..."
      />
      <input
      v-model="newItem.ImgUrl"
        type="text"
        name="year"
        placeholder="ImgUrl..."
      />
      <input
      v-model="newItem.Quantity"
        type="number"
        name="year"
        placeholder="Quantity..."
      />
      <input
      v-model="newItem.Acv"
        type="number"
        name="year"
        placeholder="Acv..."
      />
      <input
      v-model="newItem.Rcv"
        type="number"
        name="year"
        placeholder="Rcv..."
      />
       <button type="submit" class="btn btn-success">Submit</button>
    </form>
    <div class="row">
      <items v-for="items in myItems" :key="items.id" :itemsData="itemsData" />
    </div>
  </div>
</template>


<script>
import Items from "../components/Items"

export default {
  name: 'CategoryDetails',
   mounted() {
    this.getItems();
    this.getCategories();
  },
  data(){
    return {
      newItem: {
        Name: "",
        Description: "",
        ImgUrl: "",
        CategoryId: this.$route.params.categoryId,
        Quantity: parseInt(),
        Acv: parseInt(),
        Rcv: parseInt(),

      },
    }
  },
  computed:{
     categories() {
      return this.$store.state.categories;
    },
    activeCategory(){
      return this.$store.state.activeCategory;
    },
     myItems() {
      return this.$store.state.items;
    },
  },
  methods:{
     addItem() {
       debugger
      this.$store.dispatch("addItem", this.newItem);
  },
   async getItems(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getItemsByCategoryId", this.$route.params.categoryId);
      }
   },
     async getCategories(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getCategoryById", this.$route.params.categoryId);
        if (!this.$store.state.rooms.length) {
      this.$store.dispatch("getMyCategories");
    } else {
      this.$store.dispatch(
      "setActiveCategory",
      this.$store.state.rooms.find(c => c.id == this.$route.params.categoryId)
      );
    }
      }
  }
  },
  components:{
    Items
  }
}
</script>


<style scoped>

</style>
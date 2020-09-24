<template>
  <div class="categories">
 <div class="col-6">
     <div class="card">
 <router-link
        :to="{ name: 'CategoryDetails', params: { categoryId: this.categoriesData.id } }"
      >
      <img :src="categoriesData.imgUrl" alt="">
        </router-link>
      <div class="card-body">
        <h4 class="card-title">{{categoriesData.name}}</h4>
        <p class="card-text">{{categoriesData.description}}</p>
        <button @click="deleteCategory" class="danger">Delete</button>
        </div>
  </div>
  </div>

  </div>
</template>


<script>
export default {
  name: 'categories',
  props: ["categoriesData"],

  data(){
    return {}
  },
  computed:{},
  methods:{
    deleteCategory(){
     let id = this.categoriesData.id;
     let roomId = this.categoriesData.roomId;
      this.$store.dispatch("deleteCategoryById", {id, roomId});
    }
  },
  components:{}
}
</script>


<style scoped>

</style>
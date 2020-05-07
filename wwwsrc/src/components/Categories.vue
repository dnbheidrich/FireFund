<template>
  <div class="categories">
 <div class="col-12">
     <div class="card">

      <img :src="categoriesData.imgUrl" alt="">
      <div class="card-body">
        <h4 class="card-title">{{categoriesData.name}}</h4>
        <p class="card-text">{{categoriesData.description}}</p>
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
  methods:{},
  components:{}
}
</script>


<style scoped>

</style>
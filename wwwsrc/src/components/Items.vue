<template>
  <div class="component">
 <div class="col-12">
    router
     <div class="card">
      <div class="card-body">
        <h4 class="card-title">{{itemsData.name}}</h4>
        <p class="card-text">{{itemsData.description}}</p>
        <button type="danger">Delete</button>
        </div>
  </div>
  </div>


  </div>
</template>


<script>
export default {
  name: 'component',
  props: ["itemsData"],
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
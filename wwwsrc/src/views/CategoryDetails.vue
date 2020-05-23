<template>
  <div class="CategoryDetails">
<h1>Create Item</h1>
<form @submit.prevent="">
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

  </div>
</template>


<script>
export default {
  name: 'CategoryDetails',
  data(){
    return {
      newItem: {
        Name: "",
        Description: "",
        ImgUrl: "",
        CategoryId: this.$route.params.categoryId,
        Quantity: "",
        Acv:"",
        Rcv:"",

      },
    }
  },
  computed:{},
  methods:{},
  components:{}
}
</script>


<style scoped>

</style>
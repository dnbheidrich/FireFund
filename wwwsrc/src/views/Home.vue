<template>
<div class="home container-fluid">
  <div class="row text-center">
    <div class="col-12">
    <h1 class="text-warning">Welcome Home</h1>
    </div>
  </div>
</div>
</template>

<script>
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>

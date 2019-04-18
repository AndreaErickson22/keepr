<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <!-- <Keep></Keep> -->
  </div>
</template>

<script>
// import Keep from "@/components/Keep.vue";
export default {
  name: "home",
  mounted() {
    //blocks users not logged in
    if (!this.$store.state.user.id) {
      this.$router.push({ name: "login" });
    }
  }

  //   this.$store.dispatch("getpublicKeeps");
  // },
  // components: Keep
};
</script>
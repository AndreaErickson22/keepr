<template>
  <div id="backgroundcolor">
    <div class="PublicKeeps">
      PublicKeeps
      <div v-for="keep in Keeps" :key="keep.id" class="card" style="width: 18rem;">
        <img :src="keep.img" class="card-img-top" alt>

        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p
            class="card-text"
          >Some quick example text to build on the card title and make up the bulk of the card's content.</p>
          <!-- <a href="#" class="btn btn-primary">Keep View Count</a>
          <a href="#" class="btn btn-primary">Add to Vault</a>-->
          <a href="#" class="btn btn-primary">Delete Keep</a>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "PublicKeeps",
  props: [],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getAllKeeps");
  },
  computed: {
    Keeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    // addKeepToVault(id) {
    //   console.log(id);
    // },
    // goToKeepView(keepid) {
    //   this.$router.push({ name: "keeps", params: { keepid: keepid } });
    // }
  },
  components: {}
};
</script>
<style>
#backgroundcolor {
  background-color: blueviolet;
}
</style>

<template>
  <div class="Vaults">
    <div class="row d-flex justify-content-center m-3">
      <div class="card" style="width: 18rem;">
        <div class="card-body vault-card rounded">
          <h5 class="card-title">{{vault.name}}</h5>
          <p class="card-text">{{vault.description}}</p>
          <a class="btn btn-primary">Show me my vault</a>
          <a @click="deleteVault(vault)" class="btn btn-primary">Delete my vault</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vaults",
  props: ["vault"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    Vaults() {
      return this.$store.state.userVaults;
    }
  },
  methods: {
    deleteVault(vault) {
      this.$store.dispatch("deleteVault", vault);
    }
  },
  components: {}
};
</script>
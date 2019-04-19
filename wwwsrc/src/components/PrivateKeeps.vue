<template>
  <div id="backgroundcolor">
    <div class="PrivateKeeps">
      PrivateKeeps
      <div v-for="keep in Keeps" :key="keep.id" class="card" style=" width: 18rem;">
        <img :src="keep.img" class="card-img-top" alt>

        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text"></p>
          <a @click="addKeepView(keep)" class="btn btn-primary">Keep View Count {{keep.views}}</a>
          <!-- <a @click="addKeeptoVault(keep)" class="btn btn-primary">Add to Vault{{keep.keeps}}</a> -->
          <select @change="addKeeptoVault(keep, selectedVault)" v-model="selectedVault">
            <option v-for="vault in Vaults" :key="vault.id" :value="vault">{{vault.name}}</option>
          </select>
          <a @click="deleteKeep(keep)" class="btn btn-primary">Delete Keep</a>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "PrivateKeeps",
  props: [],
  data() {
    return {
      selectedVault: {}
    };
  },
  mounted() {
    this.$store.dispatch("getUserKeeps");
  },
  computed: {
    Keeps() {
      return this.$store.state.userKeeps;
    },
    Vaults() {
      return this.$store.state.vaults;
    },
    User() {
      return this.$store.state.user;
    }
  },
  methods: {
    // addKeepToVault(id) {
    //   console.log(id);
    // },
    // goToKeepView(keepid) {
    //   this.$router.push({ name: "keeps", params: { keepid: keepid } });
    // }

    addKeepView(keep) {
      keep.views++;
      this.$store.dispatch("addKeepView", keep);
    },
    addKeepCount(keep) {
      keep.keeps++;
      this.$store.dispatch("addKeepCount", keep);
    },
    deleteKeep(keep) {
      this.$store.dispatch("deleteKeep", keep);
    },
    addKeeptoVault(keep, vault) {
      debugger;
      let KeepId = keep.id;
      let VaultId = vault.id;
      let UserId = this.User.id;
      this.$store.dispatch("addKeeptoVault", { KeepId, VaultId, UserId });
    }
  },
  components: {}
};
</script>
<style>
#backgroundcolor {
  background-color: blueviolet;
}
</style>

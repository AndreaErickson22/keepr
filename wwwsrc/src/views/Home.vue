<template>
  <div class="home">
    <h1>Welcome To Your Dashboard</h1>
    <div class="container-fluid">
      <div class="row d-flex justify-content-center">
        <div class="col-6">
          <form @submit.prevent="addKeep" class="Form-BG">
            <div name="keep-form" class="form-group col-12 text-center">
              <h3>Create a new Artboard</h3>
              <label for="formGroupExampleInput">Artboard Name</label>
              <input
                type="text"
                class="form-control m-2 shadow"
                id="formGroupExampleInput"
                v-model="newKeep.name"
                placeholder="Keep Name"
              >
            </div>
            <div class="form-group">
              <label for="formGroupExampleInput2">Keep Image URL</label>
              <input
                type="text"
                class="form-control m-2 shadow"
                id="formGroupExampleInput2"
                v-model="newKeep.img"
                placeholder="Image Url"
              >
            </div>
            <div class="form-group">
              <label for="formGroupExampleInput2">Keep Description</label>
              <input
                type="text"
                class="form-control m-2 shadow"
                id="formGroupExampleInput2"
                v-model="newKeep.description"
                placeholder="Keep Description"
              >
            </div>

            <button type="submit" class="btn btn-success mb-3 shadow">Post Keep</button>
          </form>
        </div>
        <!-- vaultform -->
        <div class="col-6">
          <form @submit.prevent="addVault()" class="Form-BG">
            <div name="vault-form" class="form-group text-center">
              <h3>Create a new Art Vault</h3>
              <label for="formGroupExampleInput">Art Vault Portfolio Name</label>
              <input
                type="text"
                class="form-control m-2 shadow"
                id="formGroupExampleInput"
                v-model="newVault.name"
                placeholder="Vault Name"
              >
            </div>

            <div class="form-group">
              <label for="formGroupExampleInput2">Vault Description</label>
              <input
                type="text"
                class="form-control m-2 shadow"
                id="formGroupExampleInput2"
                v-model="newVault.description"
                placeholder="Vault Description"
              >
            </div>
            <button type="submit" class="btn btn-success mb-3 shadow">Post Vault</button>
          </form>
        </div>
      </div>
    </div>
    <!-- <vaults v-for="vault in vaults" v:vault="vault"></vaults> -->
    <vaults v-for="vault in vaults" v-bind:key="vault"></vaults>
    <div class="col-12">
      <private-keeps></private-keeps>
    </div>
  </div>
</template>

<script>
import PrivateKeeps from "@/components/PrivateKeeps.vue";
import PublicKeeps from "@/components/PublicKeeps.vue";
import Vaults from "@/components/Vaults.vue";

export default {
  name: "home",
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: "",
        isPrivate: true,
        userId: ""
      },
      newVault: {
        name: "",
        description: ""
      },
      UserKeeps: {}
    };
  },
  mounted() {
    //blocks users not logged in
    // if (!this.$store.state.user.id) {
    //   this.$router.push({ name: "login" });
    // }

    this.$store.dispatch("getUserVaults");
  },
  computed: {
    username() {
      return this.$store.state.user.username;
    },
    userId() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },

  components: {
    PrivateKeeps,
    Vaults
  },

  methods: {
    register() {
      this.$store.dispatch("register", this.newUser);
    },
    loginUser() {
      this.$store.dispatch("login", this.creds);
    },
    addKeep() {
      let newKeep = this.newKeep;
      newKeep.userId = this.userId;
      this.$store.dispatch("addUserKeep", newKeep);
      this.newKeep = { name: "", description: "", img: "" };
    },
    addVault() {
      this.$store.dispatch("addUserVaults", this.newVault);
      this.newVault = { name: "", description: "" };
    }
  }
};
</script>
<style>
#h1 {
  background-color: blueviolet;
  height: 120px;
  width: 100%;
}
.Form-BG {
  background-color: plum;
  width: 400px;
  height: auto;
  align-content: center;
}
.form-control {
  width: 300px;
}
</style>

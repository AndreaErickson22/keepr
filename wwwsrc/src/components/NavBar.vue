<template>
  <div class>
    <nav class="navbar">
      <!-- <router-link>
        <button>My Keeps</button>
      </router-link>

      <router-link>
        <button>All Keeps</button>
      </router-link>-->

      <router-link to="/login">
        <button @click="logOut">Log Out</button>
      </router-link>
    </nav>
  </div>
</template>

<script>
export default {
  name: "navbar",
  props: [],
  data() {
    return {};
  },
  computed: {},
  methods: {
    loginUser() {
      this.$store.dispatch("login", this.creds);
    },
    logOut() {
      this.$store.dispatch("logout");
    }
  },
  components: {}
};
</script>
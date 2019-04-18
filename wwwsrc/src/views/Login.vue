<template>
  <div class="LoginBG">
    <div class="container-fluid">
      <div class="login">
        <form v-if="loginForm" @submit.prevent="loginUser" claa="m-4">
          <div class="form-group text-left">
            <label>Email:</label>
            <input
              class="form-control shadow"
              type="email"
              v-model="creds.email"
              placeholder="Email"
            >
          </div>
          <div class="form-group text-left">
            <label>Password:</label>
            <input
              class="form-control shadow"
              type="password"
              v-model="creds.password"
              placeholder="password"
            >
          </div>
          <button class="btn btn-primary shadow" type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
          <div class="form-group text-left">
            <label>Enter your name:</label>
            <input
              class="form-control shadow"
              type="text"
              v-model="newUser.username"
              placeholder="name"
            >
          </div>
          <div class="form-group text-left">
            <label>Enter your email:</label>
            <input type="email" v-model="newUser.email" placeholder="email">
          </div>
          <div class="form-group text-left">
            <label>Enter your password:</label>
            <input type="password" v-model="newUser.password" placeholder="password">
          </div>
          <button type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm">
          <p v-if="loginForm">No account Click to Register</p>
          <p v-else>Already have an account click to Login</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import router from "@/router.js";
export default {
  name: "login",
  mounted() {
    //checks for valid session
    this.$store.dispatch("authenticate");
  },
  data() {
    return {
      loginForm: true,
      creds: {
        email: "",
        password: ""
      },
      newUser: {
        email: "",
        password: "",
        username: ""
      }
    };
  },
  methods: {
    register() {
      this.$store.dispatch("register", this.newUser);
    },
    loginUser() {
      this.$store.dispatch("login", this.creds);
    }
  }
};
</script>
<style>
.LoginBG {
  background-color: aqua;
  height: 100 px;
  width: 100%;
}
</style>

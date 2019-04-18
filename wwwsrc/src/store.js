import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    publicKeeps: [],
    userKeeps: [],
    vaults: [],
    vaultkeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setPublicKeeps(state, data) {
      state.publicKeeps = data
    },
    setUserKeeps(state, data) {
      state.userKeeps = data
    },
    setVaults(state, data) {
      state.vaults = data
    },
    setVaultKeeps(state, data) {
      state.vaultkeeps = data
    },
  },

  //#region --authorization---
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    //#endregion
    ///#region--Keeps--

    addUserKeeps({ commit, dispatch }, payload) {
      api.post('/keeps', payload)
        .then(res => {
          dispatch('getUsersKeeps')
        })
    },
    getUserKeeps({ commit }) {
      api.get('/keeps/user')
        .then(res => {
          commit("setUserKeeps", res.data)
        })
      router.push({ name: "keeps" })
    },
    editKeep({ commit, dispatch }, payload) {
      api.put('/keeps', payload)
        .then(res => {
          console.log("keep edited")
        })
    },
    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('/keeps' + keepId)
        .then(res => {
          console.log("keep deleted")
          dispatch('getUserKeeps')
        })
    },
    //#endregion--keeps--

    getUserVaults({ commit, dispatch }, payload) {
      api.get('vaults/', payload)
        .then(res => {
          dispatch("getUserVaults", res.data)
        })
    },
    addUserVaults({ commit, dispatch }, payload) {
      api.post('vaults/', payload)
        .then(res => { dispatch('getUserVaults') }
        )
    }
  },
  deleteVault({ commit, dispatch }, vaultId) {
    api.delete('vaults/' + vaultId)
      .then(res => {
        console.log("vault deleted")
        dispatch('getUserVaults')
      })
  },
  // getVault({ commit, dispatch, state)
  //     } 
  //       auth.get('authenticate')
  //         .then(res => {
  //         api.get('vaults/' res.data.id).then(re)
  //           .then(res => {
  //             commit("setUserVaults", res.data)
  //           })
  //       },


}
)


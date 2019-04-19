import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

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
    publicVault: {},
    userKeeps: [],
    vaults: [],
    vaultKeeps: []
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
      state.vaultKeeps = data
    },
    setPublicVault(state, data) {
      state.publicVault = data
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
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'login' })
        })
        .catch(e => {
          console.log('Logout Failed')
        })
    },
    //#endregion
    ///#region--Keeps--

    addUserKeep({ commit, dispatch }, payload) {
      api.post('/keeps', payload)
        .then(res => {

          dispatch('getUserKeeps')
        })
    },
    getUserKeeps({ commit }) {
      api.get('/keeps/user')
        .then(res => {
          commit("setUserKeeps", res.data)
        })
      // router.push({ name: "home" })
    },
    getAllKeeps({ commit }) {
      api.get('/keeps/')
        .then(res => {
          commit("setPublicKeeps", res.data)
        })
    },
    editKeep({ commit, dispatch }, payload) {
      api.put('/keeps', payload)
        .then(res => {
          console.log("keep edited")
        })
    },
    deleteKeep({ commit, dispatch }, keep) {
      api.delete(`keeps/${keep.id}`, keep)
        .then(res => {
          console.log("keep deleted")
          dispatch('getUserKeeps')
        })
    },
    //#endregion--keeps--

    getUserVaults({ commit, dispatch }, payload) {
      api.get('/vaults', payload)
        .then(res => {
          commit("setVaults", res.data)
        })

    },
    addUserVaults({ commit, dispatch }, payload) {
      api.post('Vaults', payload)
        .then(res => {
          dispatch('getUserVaults')
        })
        .catch(e => {
          console.log("cannot make vault")
        })
    },
    setPublicVault({ commit, dispatch }, payload) {
      commit('setPublicVault', payload)
      dispatch('getVaultKeeps', payload.id)
    },

    addKeeptoVault({ commit, dispatch }, payload) {
      api.post('vaultkeeps/' + payload.VaultId, payload)
        .then(res => {
          dispatch('getVaultKeeps', payload.vaultId)
        })
        .catch(e => {
          console.log("cannot make vault keep at this time")
        })
    },

    //   getvaultKeeps({ commit, dispatch }, vaultId)
    //   api.get('vaults/' + vaultId + '/keeps')
    //     .then(res => {
    //       commit('setVaultKeeps', res.data)
    //     })
    // },

    deleteVault({ commit, dispatch }, payload) {
      api.delete('vaults/' + payload.id)
        .then(res => {
          dispatch('getUserVaults')
        })
        .catch(e => {
          console.log("Cannot delete this vault")
        })
    },
    addKeepView({ commit, dispatch }, keep) {
      api.put(`keeps/${keep.id}`, keep)
        .then(res => {
          dispatch('getUserKeeps')
        })
    },
    addKeepCount({ commit, dispatch }, keep) {
      api.put(`keeps/${keep.id}`, keep)
        .then(res => {
          dispatch('getUserKeeps')
        })
    }
  }


}

)
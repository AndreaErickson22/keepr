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

    //ARE THESE CORRECT?
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

    getpublicKeeps({ commit, dispatch }, publickeeps) {
      api.get('/keeps')
        .then(res => {
          commit('setpublicKeeps', res.data)
        })
    },
    addUserKeeps({ commit, dispatch }, keepData) {
      api.post('/keeps', keepData)
        .then(serverKeep => {
          dispatch('getKeeps')
        })
    },
    editKeep({ commit, dispatch }, keepData) {
      api.put('/keeps' + keepData.keepId, keepData)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('/keep' + keepId)
        .then(res => {
          dispatch('getKeeps')
        })
    },

  }
})

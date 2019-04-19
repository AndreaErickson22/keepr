<template>
  <div class="VaultView">
    <div class="row d-flex justify-content-center m-3">
      <div class="card" style="width: 18rem;">
        <div class="card-body vault-card rounded">
          <!-- this is where the view count will go -->
          <!-- <p>{{taskData.createdAt | formatTime}}</p> -->
          <h5 class="card-title">Vault page</h5>
          <p
            class="card-text"
          >With supporting text below as a natural lead-in to additional content.</p>
          <a href="#" class="btn btn-primary">Show me my vault</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vaults",
  props: [],
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: {}
};
</script>
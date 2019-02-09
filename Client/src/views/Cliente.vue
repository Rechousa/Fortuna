<template>
  <div class="wrapper">
    <div class="animated fadeIn">
      <b-card header-tag="header" footer-tag="footer">
        <div slot="header">
          <i class="fa fa-align-justify"></i> Dados do Cliente
        </div>
        <div>
          <b-tabs fill tabs>
            <b-tab title="Cliente" active>
              <clientetab1></clientetab1>
            </b-tab>
            <b-tab title="Histórico">
              <clientetab2></clientetab2>
            </b-tab>
            <b-tab title="Alertas">
              <clientetab3></clientetab3>
            </b-tab>
          </b-tabs>
        </div>
        <div></div>
      </b-card>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import clientetab1 from "./base/ClienteTab1.vue";
import clientetab2 from "./base/ClienteTab2.vue";
import clientetab3 from "./base/ClienteTab3.vue";

export default {
  name: "Cliente",
  components: { clientetab1, clientetab2, clientetab3 },
  data: () => {
    return {
      cliente: {}
    };
  },
  created: function() {
    this.fetchData();
  },
  methods: {
    fetchData: async function() {
      await axios
        .get(`http://localhost:8181/api/clientes/${this.$route.params.id}`)
        .then(response => (this.cliente = response.data))
        .catch(error => alert("Ocorreu um erro ao obter a informação."));
    }
  }
};
</script>

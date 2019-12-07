<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col lg="12">
        <c-table
          :table-data="items"
          :fields="fields"
          :perPage="5"
          caption="<i class='fa fa-align-justify'></i> Clientes"
        ></c-table>
      </b-col>
      <b-col cols="6" sm="4" md="2" xl class="mb-3 mb-xl-0">
        <b-button variant="primary" @click="novocliente">Novo cliente</b-button>
      </b-col>
    </b-row>
    <!--/.row-->
  </div>
</template>

<script>
/*
  {username: 'Samppa Nori', registered: '2012/01/01', role: 'Member', status: 'Active', _rowVariant: 'success'},
  {username: 'Estavan Lykos', registered: '2012/02/01', role: 'Staff', status: 'Banned', _rowVariant: 'danger'},
  {username: 'Chetan Mohamed', registered: '2012/02/01', role: 'Admin', status: 'Inactive', _rowVariant: 'info'},
  {username: 'Derick Maximinus', registered: '2012/03/01', role: 'Member', status: 'Pending'},
  {username: 'Friderik Dávid', registered: '2012/01/21', role: 'Staff', status: 'Active'},
  {username: 'Yiorgos Avraamu', registered: '2012/01/01', role: 'Member', status: 'Active'},
  {username: 'Avram Tarasios', registered: '2012/02/01', role: 'Staff', status: 'Banned'},
*/
import axios from "axios";
import cTable from "./base/Table.vue";

export default {
  name: "clientes",
  components: { cTable },
  data: () => {
    return {
      items: [],
      fields: [
        { key: "nome", label: "Nome", sortable: true },
        { key: "morada", sortable: true },
        { key: "telefone", sortable: true },
        {
          key: "numeroContribuinte",
          label: "Nr. Contribuinte",
          sortable: true
        },
        { key: "email", sortable: true },
        { key: "convencao", label: "Convenção", sortable: true }
      ]
    };
  },
  created: function() {
    this.fetchData();
  },
  methods: {
    fetchData: async function() {
      await axios
        .get("http://localhost:8181/api/clientes/")
        .then(response => (this.items = response.data))
        .catch(error => {
          this.$store.dispatch("showErrorAlertAction", {
            message: "Ocorreu um erro ao obter a informação."
          });
        });
    },
    novocliente: async function() {
     this.$router.push({ name: "novocliente" }); 
    }
  }
};
</script>

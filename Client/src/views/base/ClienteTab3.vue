<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col lg="12">
        <c-table
          :table-data="items"
          :fields="fields"
          :perPage="5"
          caption="<i class='fa fa-align-justify'></i> Alertas"
        ></c-table>
      </b-col>
    </b-row>
    <!--/.row-->
  </div>
</template>

<script>
import axios from "axios";
import cTable from "./Table.vue";

export default {
  name: "ClienteTab3",
  components: { cTable },
  data: () => {
    return {
      items: [],
      fields: [
        { key: "descricao", label: "Descrição", sortable: true },
        { key: "dataHora", sortable: true },
      ]
    };
  },
  created: function() {
    this.fetchData();
  },
  methods: {
    fetchData: async function() {
      await axios
        .get(`http://localhost:8181/api/clientes/${this.$route.params.id}/alertas`)
        .then(response => (this.items = response.data))
        .catch(error => alert("Ocorreu um erro ao obter a informação."));
    }
  }
};
</script>

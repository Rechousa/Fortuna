<template>
  <b-row>
    <b-col sm="12">
      <b-form-group>
        <label for="company">Nome</label>
        <b-form-input
          type="text"
          id="company"
          placeholder="Enter your company name"
          v-model="cliente.nome"
        ></b-form-input>
      </b-form-group>
      <b-form-group>
        <label for="street">Morada</label>
        <b-form-input
          type="text"
          id="street"
          placeholder="Enter street name"
          v-model="cliente.morada"
        ></b-form-input>
      </b-form-group>
      <b-row>
        <b-col sm="8">
          <b-form-group>
            <label for="city">Cidade</label>
            <b-form-input
              type="text"
              id="city"
              placeholder="Enter your city"
              v-model="cliente.cidade"
            ></b-form-input>
          </b-form-group>
        </b-col>
        <b-col sm="4">
          <b-form-group>
            <label for="postal-code">Código Postal</label>
            <b-form-input
              type="text"
              id="postal-code"
              placeholder="Postal Code"
              v-model="cliente.codigoPostal"
            ></b-form-input>
          </b-form-group>
        </b-col>
      </b-row>
      <b-form-group>
        <label for="country">Telefone</label>
        <b-form-input
          type="text"
          id="country"
          placeholder="Country name"
          v-model="cliente.telefone"
        ></b-form-input>
      </b-form-group>
      <b-form-group>
        <label for="vat">Nr. Contribuinte</label>
        <b-form-input
          type="text"
          id="vat"
          placeholder="PL1234567890"
          v-model="cliente.contribuinte"
        ></b-form-input>
      </b-form-group>
      <b-form-group>
        <label for="vat">Convenção</label>
        <b-form-input type="text" id="vat" placeholder="PL1234567890" v-model="cliente.convencao"></b-form-input>
      </b-form-group>
    </b-col>
  </b-row>
</template>

<script>
import axios from "axios";

export default {
     name: "ClienteTab1",
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

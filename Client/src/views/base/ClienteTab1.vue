<template>
  <div>
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
        <b-row>
          <b-col sm="8">
            <b-form-group>
              <label for="country">Telefone</label>
              <b-form-input
                type="text"
                id="country"
                placeholder="Country name"
                v-model="cliente.telefone"
              ></b-form-input>
            </b-form-group>
          </b-col>
          <b-col sm="4">
            <b-form-group>
              <label for="vat">Nr. Contribuinte</label>
              <b-form-input
                type="text"
                id="vat"
                placeholder="PL1234567890"
                v-model="cliente.contribuinte"
              ></b-form-input>
            </b-form-group>
          </b-col>
        </b-row>
        <b-form-group>
          <label for="vat">Convenção</label>
          <b-form-input type="text" id="vat" placeholder="PL1234567890" v-model="cliente.convencao"></b-form-input>
        </b-form-group>
      </b-col>
    </b-row>
    <b-row class="align-items-center">
      <b-col cols="6" sm="4" md="2" xl class="mb-3 mb-xl-0">
        <b-button variant="primary" class="mr-2" @click="saveData">Gravar</b-button>
        <b-button variant="danger" class="mr-2" @click="isVisibleConfirmModal=true">Eliminar</b-button>
      </b-col>
    </b-row>

    <b-modal
      title="Eliminar cliente"
      v-model="isVisibleConfirmModal"
      cancel-title="Cancelar"
      ok-variant="danger"
      ok-title="Eliminar"
      @ok="deleteRecord"
    >Tem a certeza que pretende eliminar o cliente "{{ cliente.nome }}" ?</b-modal>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "ClienteTab1",
  data: () => {
    return {
      cliente: {},
      isVisibleConfirmModal: false
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
        .catch(error => {
          this.$store.dispatch("showErrorAlertAction", {
            message: "Ocorreu um erro ao obter a informação."
          });
        });
    },
    saveData: async function() {
      await axios
        .put(
          `http://localhost:8181/api/clientes/${this.$route.params.id}`,
          this.cliente
        )
        .then(response => {
          this.$store.dispatch("showSuccessAlertAction", {
            message: "Cliente gravado com sucesso!"
          });
        })
        .catch(error => {
          this.$store.dispatch("showErrorAlertAction", {
            message: "Ocorreu um erro ao gravar o cliente."
          });
        });
    },
    deleteRecord: async function() {
      await axios
        .delete(`http://localhost:8181/api/clientes/${this.$route.params.id}`)
        .then(response => {
          this.$store.dispatch("showSuccessAlertAction", {
            message: "Cliente eliminado com sucesso!"
          });
          this.$router.push({ name: "Clientes" });
        })
        .catch(error => {
          this.$store.dispatch("showErrorAlertAction", {
            message: "Ocorreu um erro ao eliminar o cliente."
          });
        });
      this.isVisibleConfirmModal = false;
    },
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    }
  }
};
</script>

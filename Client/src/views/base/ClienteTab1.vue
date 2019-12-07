<template>
  <div>
    <b-row>
      <b-col sm="12">
        <b-form-group>
          <label for="name">Nome</label>
          <b-form-input type="text" id="name" placeholder="Nome do cliente" v-model="cliente.nome"></b-form-input>
        </b-form-group>
        <b-form-group>
          <label for="address">Morada</label>
          <b-form-input
            type="text"
            id="address"
            placeholder="Morada do cliente"
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
                placeholder="Cidade / Localidade"
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
                placeholder="Código postal"
                v-model="cliente.codigoPostal"
              ></b-form-input>
            </b-form-group>
          </b-col>
        </b-row>
        <b-row>
          <b-col sm="4">
            <b-form-group>
              <label for="phone">Telefone</label>
              <b-form-input
                type="text"
                id="phone"
                placeholder="Nr. de telemóvel ou telefone"
                v-model="cliente.telefone"
              ></b-form-input>
            </b-form-group>
          </b-col>
          <b-col sm="4">
            <b-form-group>
              <label for="numeroUtente">Número de Utente / SNS</label>
              <b-form-input
                type="text"
                id="numeroUtente"
                placeholder="Nr. de utente"
                v-model="cliente.numeroUtente"
              ></b-form-input>
            </b-form-group>
          </b-col>
          <b-col sm="4">
            <b-form-group>
              <label for="vat-number">Nr. Contribuinte</label>
              <b-form-input
                type="text"
                id="vat-number"
                placeholder="Nr. de contribuinte do cliente"
                v-model="cliente.numeroContribuinte"
              ></b-form-input>
            </b-form-group>
          </b-col>
        </b-row>
        <b-row>
          <b-col sm="4">
            <b-form-group>
              <label for="email">Email</label>
              <b-form-input
                type="text"
                id="email"
                placeholder="Endereço de email"
                v-model="cliente.email"
              ></b-form-input>
            </b-form-group>
          </b-col>
          <b-col sm="4">
            <b-form-group>
              <label for="nomeConvencao">Convenção / Seguradora</label>
              <b-form-input
                type="text"
                id="nomeConvencao"
                placeholder="Nome da Convenção que o cliente possa ter"
                v-model="cliente.nomeConvencao"
              ></b-form-input>
            </b-form-group>
          </b-col>
          <b-col sm="4">
            <b-form-group>
              <label for="numeroConvencao">Nr. da Convenção / Seguradora</label>
              <b-form-input
                type="text"
                id="numeroConvencao"
                placeholder="Número do seguro"
                v-model="cliente.numeroConvencao"
              ></b-form-input>
            </b-form-group>
          </b-col>
        </b-row>
      </b-col>
    </b-row>
    <b-row class="align-items-center">
      <b-col cols="6" sm="4" md="2" xl class="mb-3 mb-xl-0">
        <b-button variant="primary" class="mr-2" @click="(isNew ? addRecord() : saveData())">Gravar</b-button>
        <b-button
          v-if="!isNew"
          variant="danger"
          class="mr-2"
          @click="isVisibleConfirmModal=true"
        >Eliminar</b-button>
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
    if (!this.isNew) {
      this.fetchData();
    }
  },
  methods: {
    fetchData: async function() {
      if (!this.isNew) {
        await axios
          .get(`http://localhost:8181/api/clientes/${this.$route.params.id}`)
          .then(response => (this.cliente = response.data))
          .catch(error => {
            this.$store.dispatch("showErrorAlertAction", {
              message: "Ocorreu um erro ao obter a informação."
            });
          });
      }
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
    addRecord: async function() {
      await axios
        .post(`http://localhost:8181/api/clientes/`, this.cliente)
        .then(response => {
          this.$store.dispatch("showSuccessAlertAction", {
            message: "Cliente gravado com sucesso!"
          });
          this.$router.push({ name: "Clientes" });

          // var location = response.headers["location"];
          // if (location) {
          //   this.$router.replace({ path: location });
          // } else {
          //   this.$router.push({ name: "Clientes" });
          // }
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
  },
  computed: {
    isNew() {
      const result = this.$route.name === "novocliente";
      return result;
    }
  }
};
</script>

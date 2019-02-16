import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export const store = new Vuex.Store({

  state: {
    dismissSecs: 10,
    dismissCountDown: 0,
    alertMode: "none",
    alertMessage: "",
    alertType: "success",
    showDismissibleAlert: false
  },

  mutations: {
    showSuccessAlert(state, payload) {
      state.alertMode = "success";
      state.showDismissibleAlert = true;
      state.dismissCountDown = state.dismissSecs;
      state.alertMessage = payload.message;
    },
    showErrorAlert(state, payload) {
      state.alertMode = "danger";
      state.showDismissibleAlert = true;
      state.dismissCountDown = state.dismissSecs;
      state.alertMessage = payload.message;
    },
    countDownChanged(state, payload) {
      state.dismissCountDown = payload;
    },
    hideAlert(state, payload) {
      state.showDismissibleAlert = false;
    }
  },

  actions: {
    showSuccessAlertAction({ commit }, payload) {
      commit('showSuccessAlert', payload)
    },
    showErrorAlertAction({ commit }, payload) {
      commit('showErrorAlert', payload)
    },
    countDownChangedAction({ commit }, payload) {
      commit('countDownChanged', payload)
    },
    hideAlertAction({ commit }, payload) {
      commit('hideAlert', payload)
    },
  },

  getters: {
    alertMessage(state) {
      return state.alertMessage;
    },
    alertMode(state) {
      return state.alertMode;
    },
    dismissCountDown(state) {
      return state.dismissCountDown;
    },
    dismissSecs(state) {
      return state.dismissSecs;
    },
    showDismissibleAlert(state) {
      return state.showDismissibleAlert;
    }
  }
})
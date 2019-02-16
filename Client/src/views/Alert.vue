<template>
  <div>
    <div class="alerts-container">
      <b-alert
        :show="alertMode=='success' && dismissCountDown"
        dismissible
        v-bind:variant="alertMode"
        @dismissed="dismissCountdown=0"
        @dismiss-count-down="countDownChanged"
      >
        {{ alertMessage }}
        <b-progress variant="info" :max="dismissSecs" :value="dismissCountDown" height="4px"></b-progress>
      </b-alert>
      <b-alert
        :show="alertMode=='danger' && showDismissibleAlert"
        dismissible
        v-bind:variant="alertMode"
        @dismissed="hideDismissibleAlert"
      >{{ alertMessage }}</b-alert>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    countDownChanged(dismissCountDown) {
      this.$store.dispatch("countDownChangedAction", dismissCountDown);
    },
    hideDismissibleAlert() {
      this.$store.dispatch("hideAlertAction");
    },
  },
  computed: {
    alertMessage() {
      return this.$store.getters.alertMessage;
    },
    alertMode() {
      return this.$store.getters.alertMode;
    },
    dismissCountDown() {
      return this.$store.getters.dismissCountDown;
    },
    dismissSecs() {
      return this.$store.getters.dismissSecs;
    },
    showDismissibleAlert() {
      return this.$store.getters.showDismissibleAlert;
    }
  }
};
</script>

<style scoped>
.alerts-container {
    position: fixed;
    z-index: 2000;
    min-width: 400px;
    top: 36px;
    right: 10px;
    font-weight: bold;
}
</style>
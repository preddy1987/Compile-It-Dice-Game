//import Vue from 'vue/dist/vue.js'
import Vue from 'vue';
import App from './App.vue';
import 'bootstrap'; 
import 'bootstrap/dist/css/bootstrap.min.css';
import router from "./router";

Vue.config.productionTip = false;

// export const eventHandler = new Vue();

export const globals = new Vue({
  data: {
    playerName: '',
    isGameActive: false,
    players: [],
    timer: null,
    currentPlayer: '',
    isLastRound: false,
    isTurnOver: false,
    hasWinner: false,
    successDiceData: [],
    errorDiceData: [],
    remainingDiceData: [],
    rollDiceData: []
  }
});

new Vue({
  router,
  render: h => h(App),
}).$mount('#app');


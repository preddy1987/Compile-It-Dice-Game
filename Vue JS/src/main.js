//import Vue from 'vue/dist/vue.js'
import Vue from 'vue';
import App from './App.vue';
import 'bootstrap'; 
import 'bootstrap/dist/css/bootstrap.min.css';
import router from "./router";

Vue.config.productionTip = false;

export const eventHandler = new Vue();
export const globals = new Vue({
  data: {
    playerName: '',
    gameStarted: false
  }
});

new Vue({
  router,
  render: h => h(App),
}).$mount('#app');


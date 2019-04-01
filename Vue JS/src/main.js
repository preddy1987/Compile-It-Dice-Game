import Vue from 'vue';
import App from './App.vue';
import 'bootstrap'; 
import 'bootstrap/dist/css/bootstrap.min.css';

window.serverUrl = "http://localhost:50260/";

Vue.config.productionTip = false;

export const eventHandler = new Vue();

new Vue({
  render: h => h(App),
}).$mount('#app');


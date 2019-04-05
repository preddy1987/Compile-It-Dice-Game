import Vue from 'vue';
import App from './App.vue';
import 'bootstrap'; 
import 'bootstrap/dist/css/bootstrap.min.css';


Vue.config.productionTip = false;

export const eventHandler = new Vue();
export const serverUrl = "http://localhost:50260/";


new Vue({
  render: h => h(App),
}).$mount('#app');


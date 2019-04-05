<template>
<<<<<<< HEAD
  <div>    
    <dashboard  v-if="page === 'dashboard'"/>
    <join-view v-on:playerAdded="updatePlayerList" v-if="page === 'join'"/>
=======
  <div> 
    <dashboard/>
>>>>>>> 5e1c3e729b56b1bfd9f5878beac65bb2c4914a5d
  </div>
</template>

<script>
import Dashboard from './components/Dashboard.vue';
import JoinView from './components/JoinView.vue';
import {serverUrl} from '@/main.js';
import LandingView from './components/LandingView.vue'


export default {
  name: 'App',
  components: {
    Dashboard,
    JoinView,
    LandingView
  },
  data() {
    return {
      page: 'join'
    }
  },
  methods: {
    updatePlayerList() {
      // Get the players and bind to player view
      this.page = 'dashboard';
    },
    getPlayers() {
      let ajaxURL = serverUrl + "api/players";

      //http://localhost:50260/api/players
      fetch(ajaxURL, {
          method: 'get',
          headers: {
              "Content-Type": "application/json"
          }
      })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        window.console.log(data);
        // this.updatePlayers(data.gamePlayers, data.gameStatus.currentPlayer);         
      })
      .catch((error) => {
        window.console.log('Error:', error);
      });
    }
  }
}
</script>

<style scoped>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>

<template>
  <div class = 'landing-container'>
    <img src ='../assets/CompileIt.svg'/>
    <p>Welcome to our game. There are 13 dice that are colored red, 
      yellow and green that are rolled 3 at a time. The dice have a
      success, warning, and error. The goal 
      is to collect 13 successes to win. If you get 3 errors
      then the successes that you have collected that turn will
      not be banked. You can end your turn anytime to bank your 
      successes. As you collect successes and errors those
      dice are replaced with dice from your cup.</p>
    <button @click="addPlayer">{{joinBtnLabel}}</button> 
    <button @click="startGame">{{gameBtnLabel}}</button> 
    <button @click="removeAllPlayers">Reset Game</button>   
    <ul>
      <h4>Players</h4>
      <li v-for="player in players" :key="player">{{player}}</li>
    </ul>
  </div>
</template>

<script>
import {APIService} from '@/APIService';
import {globals} from '@/main.js';
const apiService = new APIService();
export default {
  name: 'landing-view',
  data() {
    return {
      players: null
    }
  },
  computed: {
    joinBtnLabel() {
      return globals.playerName.length > 0 ? 'Leave' : 'Join';
    },
    gameBtnLabel() {
      return globals.playerName.length > 0 ? 'Start Game' : 'View Game';
    }
  },
  methods: {
    addPlayer() {
      if(globals.playerName.length > 0){        
        apiService.removePlayer(globals.playerName).then((data) => {
          window.console.log(data);
          globals.playerName = "";
          this.getPlayers();          
        });      
      }
      else {
        this.$router.push({ name: 'join' });
      }
    },
    getPlayers() {
      apiService.getPlayers().then((data) => {
        window.console.log(data);
        this.players = data.gamePlayers.map(player => {
          return player.name;
        });
      });
    },
    startGame() {
      if(this.players.length > 0) {
        this.$router.push({ name: 'dashboard' });
      }
    },
    removeAllPlayers() {
      apiService.removeAllPlayers().then(() => {
        this.getPlayers();
        global.playerName = "";
      });      
    }
  },
  created() {
    this.getPlayers();
  }
}
</script>

<style scoped>
.landing-container {
    margin : 3%;
}


</style>

<template>
  <div>    
    <dice-view :dice="diceData" />
    <form @submit.prevent="addPlayer">
      <input type="text" name="name" v-model="addPlayerName" placeholder="Name">
      <input type="submit" value="Add Player">
    </form>
    <form @submit.prevent="removePlayer">
      <input type="text" name="name" v-model="removePlayerName" placeholder="Name">
      <input type="submit" value="Remove Player">
    </form>
    <button>Start Game</button>
    <button>Roll</button>
    <button>Pass Turn</button>
    <player-status :gameStatus="gameStatus" :turnStatus="turnStatus"/>
    <game-status :players="players"/>
    <dice-view :dice="remainingDiceData" />
  </div>
</template>

<script>
import {serverUrl} from '@/main.js';
import DiceView from './components/DiceView.vue'
import PlayerStatus from './components/PlayerStatus.vue'
import GameStatus from './components/GameStatus.vue'

export default {
  name: 'App',
  components: {
    DiceView,
    PlayerStatus,
    GameStatus
  },
  data() {
    return {
      diceData: [{value:'1', color:'red'},{value:'2', color:'green'},{value:'3', color:'yellow'}],
      gameStatus: {currentPlayer: 'Chris'},
      turnStatus: {turnErrors: '1',turnSuccesses:'1',turnWarnings:'1'},
      addPlayerName: "",
      removePlayerName: "",
      remainingDiceData: [],
      players: []
    }
  },
  methods: {
    addPlayer() {
      const player = {};
      player.name = this.addPlayerName;

      let ajaxURL = serverUrl + "api/player";

      //http://localhost:50260/api/player
      fetch(ajaxURL, {
          method: 'post',
          headers: {
              "Content-Type": "application/json"
          },
          body: JSON.stringify(player)
      })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        window.console.log(data);
        this.updateRemainingDice(data.turnStatus.remainingDice);
        this.getPlayers();         
      })
      .catch((error) => {
        window.console.log('Error:', error);
      });
    },
    removePlayer() {
      let ajaxURL = `${serverUrl}api/player/${this.removePlayerName}`;

      //http://localhost:50260/api/player/{name}
      fetch(ajaxURL, {
          method: 'delete',
          headers: {
              "Content-Type": "application/json"
          }
      })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        window.console.log(data);
        this.getPlayers();         
      })
      .catch((error) => {
        window.console.log('Error:', error);
      });
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
        this.updatePlayers(data.gamePlayers, data.gameStatus.currentPlayer);         
      })
      .catch((error) => {
        window.console.log('Error:', error);
      });
    },
    updateRemainingDice(dice) {
      window.console.log(dice);
      this.remainingDiceData = [];
      
      dice.forEach((die) => {
        this.remainingDiceData.push({value: 1, color:die.typeName})
        //{type: 3, numberOfSides: 6, typeName: "Green", sideNames: Array(6)}
      });
    },
    updatePlayers(players, currentPlayer) {
      window.console.log(players);
      this.players = [];
      
      players.forEach((player) => {
        this.players.push({
          name:player.name, 
          round:player.roundCount, 
          current:(currentPlayer === player.name), 
          score:player.totalSuccesses
        })
      });
    }
  },
  created(){
    this.getPlayers();
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

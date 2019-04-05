<template>
  <div id="dashboard">    
    <dice-view :dice="diceData" />
    <form @submit.prevent="addPlayer">
      <input type="text" name="name" v-model="addPlayerName" placeholder="Name">
      <input type="submit" value="Add Player">
    </form>
    <form @submit.prevent="removePlayer">
      <input type="text" name="name" v-model="removePlayerName" placeholder="Name">
      <input type="submit" value="Remove Player">
    </form>
    <button class="btn btn-secondary" @click="startGame">Start Game</button>
    <player-status @roll="rollDice" @pass="passTurn" :turnStatus="turnStatus"/>
    <game-status :players="players"/>
    <dice-view :dice="remainingDiceData" />
  </div>
</template>

<script>
import {serverUrl} from '@/main.js';

import DiceView from './DiceView.vue'
import PlayerStatus from './PlayerStatus.vue'
import GameStatus from './GameStatus.vue'


export default {
  name: 'Dashboard',
  components: {
    DiceView,
    PlayerStatus,
    GameStatus
  },
  data() {
    return {
      diceData: [{compileType:'Success', dieType:'green'},{compileType:'Warning', dieType:'yellow'},{compileType:'Error', dieType:'red'}],
      turnStatus: {turnErrors: 0, turnSuccesses: 0, turnWarnings: 0},
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
          if(die === 'Green'){
              this.remainingDiceData.push({compileType: 'Success', dieType: 'Green'})
          }
          else if(die === 'Yellow'){
              this.remainingDiceData.push({compileType: 'Warning', dieType: 'Yellow'})
          }
          else if(die === 'Red'){
              this.remainingDiceData.push({compileType: 'Error', dieType: 'Red'})
          }
        // this.remainingDiceData.push({value: 1, color:die})
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
    },
    rollDice() {
      let ajaxURL = serverUrl + "api/rolldice";

      //http://localhost:50260/api/rolldice
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
        this.turnStatus.turnErrors = data.turnStatus.turnErrors;
        this.turnStatus.turnSuccesses = data.turnStatus.turnSuccesses;
        this.turnStatus.turnWarnings = data.turnStatus.turnWarnings;
        this.updateRemainingDice(data.turnStatus.remainingDice);
        this.diceData = data.dieSides;         
      })
      .catch((error) => {
        window.console.log('Error:', error);
      });
    },
    passTurn() {
      let ajaxURL = serverUrl + "api/passturn";

      //http://localhost:50260/api/passturn
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
        this.getPlayers();
        this.turnStatus = {turnErrors: 0, turnSuccesses: 0, turnWarnings: 0};
        this.updateRemainingDice(data.turnStatus.remainingDice);
      })
      .catch((error) => {
        window.console.log('Error:', error);
      });
    },
    startGame() {
      let ajaxURL = serverUrl + "api/start";

      //http://localhost:50260/api/start
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
      })
      .catch((error) => {
        window.console.log('Error:', error);
      });
    }            
  },
 
  created(){
    this.getPlayers();
  }
}
</script>

<style scoped>

</style>

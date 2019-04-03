<template>
  <div>    
    <dice-view :dice="diceData" />
    <form action="/action_page.php" @submit.prevent="addPlayerClick">
      <input type="text" name="name" v-model="playerName" placeholder="Name">
      <input type="submit" value="Add Player">
    </form>
    <button>Remove Player</button>
    <button>Start Game</button>
    <button>Roll</button>
    <button>Pass Turn</button>
    <player-status :gameStatus="gameStatus" :turnStatus="turnStatus"/>
    <game-status :players="players" />
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
      turnStatus: {turnErrors: '1',turnSuccesses:'1',turnWarnings:'1',totalSuccesses:'5',round:'5'},
      playerName: "",
      remainingDiceData: [{value:'1', color:'red'},{value:'2', color:'green'},{value:'3', color:'yellow'}],
      players: [{name:'Chris'},{name:'Bob'},{name:'Tina'}]
    }
  },
  methods: {
    addPlayerClick() {
      const player = {};
      player.name = this.playerName;

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

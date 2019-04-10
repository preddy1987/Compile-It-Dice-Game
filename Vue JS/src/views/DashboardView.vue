<template>
  <div id="dashboard">    
    <dice-view :dice="diceData" />
    <player-status :isActivePlayersTurn="isCurrentPlayersTurn" 
                   @roll="rollDice" 
                   @pass="passTurn" 
                   @removePlayer="removePlayer" 
                   :turnStatus="turnStatus" />
    <game-status :players="players" />
    <dice-view :dice="remainingDiceData" />
  </div>
</template>

<script>
import {APIService} from '@/APIService';
import {globals} from '@/main.js';
import DiceView from '@/components/DiceView.vue'
import PlayerStatus from '@/components/PlayerStatus.vue'
import GameStatus from '@/components/GameStatus.vue'
const apiService = new APIService();

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
      remainingDiceData: [],
      players: [],
      currentPlayer: null
    }
  },
  computed: {
    isCurrentPlayersTurn(vm) {
      return globals.playerName === vm.currentPlayer;
    }
  },
  methods: {
    getPlayers() {
      apiService.getPlayers().then((data) => {
        window.console.log(data);
        this.currentPlayer = data.gameStatus.currentPlayer;
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
      apiService.rollDice().then((data) => {
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
      apiService.passTurn().then((data) => {
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
      apiService.startGame().then((data) => {
        window.console.log(data);
        globals.gameStarted = true;
      })
      .catch((error) => {
        window.console.log('Error:', error);
      });
    },
    removePlayer() {
      if(globals.playerName.length > 0){        
        apiService.removePlayer(globals.playerName).then((data) => {
          window.console.log(data);
          globals.playerName = ""; 
          this.$router.push({ name: 'landing' });  
        });      
      }
      else {
        this.$router.push({ name: 'landing' });
      }      
    }
  }, 
  created(){
    this.getPlayers();
  }
}
</script>

<style scoped>

</style>

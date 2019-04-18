<template>
  <div id="main">
    <div>
        <img src='@/assets/CompileIt.svg'/>
        <span>Player Name: <span>{{player}}</span></span>
        <div>
          <router-view />
        </div>
    </div>
  </div>
</template>

<script>
import {APIService} from '@/APIService';
import {globals} from '@/main.js';
const apiService = new APIService();

export default {
  name: 'app',
  methods: {
    startHeartBeat() {
      globals.timer = setTimeout(this.getStatus, 1000);    
    },
    stopHeartBeat() {
      clearTimeout(globals.timer);
    },
    getStatus() {
      apiService.getPlayers().then((data) => {
        window.console.log(data);
        globals.isGameActive = data.gameStatus.isGameActive;
        globals.currentPlayer = data.gameStatus.currentPlayer;
        globals.hasWinner = data.gameStatus.hasWinner;
        globals.isGameActive = data.gameStatus.isGameActive;
        globals.isLastRound = data.gameStatus.isLastRound;
        globals.isTurnOver = data.gameStatus.isTurnOver;
        data.gamePlayers.sort((a, b) => (a.totalSuccesses < b.totalSuccesses) ? 1 : -1);
        globals.players = data.gamePlayers;
        if(globals.players.length === 0) {
          globals.playerName = "";
        }
        if(data.turnStatus !== null) {
          globals.errorDiceData = data.turnStatus.errorSides;
          globals.successDiceData = data.turnStatus.successSides;
          globals.remainingDiceData = data.turnStatus.remainingDice;
          globals.rollDiceData = data.turnStatus.dieSides;
        }
        else {
          globals.errorDiceData = [];
          globals.successDiceData = [];
          globals.remainingDiceData = [];
          globals.rollDiceData = [];
        }
        this.startHeartBeat(); 
      })
      .catch(error => {
        window.console.log("Error:", error);
        this.startHeartBeat();
      }); 
    }
  },
  computed: {
    player() {
      return globals.playerName.length > 0 ? globals.playerName : 'Not Playing';
    }
  },
  created() {
    this.startHeartBeat();
  }
}
</script>

<style scoped>
#main {
  display: flex;
  align-items: center;
  flex-direction: column;
}

#main > div {
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-direction: column;    
  width: 375px;
  height: 700px;  
}

#main > div > img {
  height: 100%;
  width: 375px;
  background-color: whitesmoke;
}

#main > div div {  
  height: 550px;
  padding-bottom: 10px;
}

#main > div {
  background-color: silver;
}

#main > div > span {
  font-size: 20px;
  color: blue;
  margin-bottom: 5px;
}

#main > div > span > span {
  font-size: 20px;
  color: green;
}
</style>

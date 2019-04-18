<template>
  <div class='landing-container'>
    <div>
      <div class="player-center player-title"><div>Players</div></div>
      <ol>
        <li v-for="player in players" :key="player">{{player}}</li>
      </ol>
    </div>
    <div class="player-center">
      <button class="btn btn-primary" v-if="!isGameStarted" @click="addPlayer">{{joinBtnLabel}}</button> 
      <button class="btn btn-primary" v-if="players.length > 0 && (isGameStarted || isGamePlayer)" @click="startGame">{{gameBtnLabel}}</button> 
      <button class="btn btn-secondary" @click="removeAllPlayers">Reset</button>
      <button class="btn btn-info" @click="directions">Help</button>
    </div>   
  </div>
</template>

<script>
import {APIService} from '@/APIService';
import {globals} from '@/main.js';
const apiService = new APIService();

export default {
  name: 'landing-view',
  computed: {
    joinBtnLabel() {
      return globals.playerName.length > 0 ? 'Leave' : 'Join';
    },
    gameBtnLabel() {
      return globals.isGameActive ? 'View' : 'Start';
    },
    players() {
      return globals.players.map(player => {
        return player.name;
      });
    },
    isGameStarted() {
      return globals.isGameActive;
    },
    isGamePlayer() {
      let isInGame = false;
      this.players.forEach(player => {
        if(player === globals.playerName) {
          isInGame = true;
        }
      });
      return isInGame;
    }
  },
  methods: {
    addPlayer() {
      if(globals.playerName.length > 0){        
        apiService.removePlayer(globals.playerName).then((data) => {
          window.console.log(data);
          globals.playerName = "";  
        }).catch((error) => {
          window.console.log('Error:', error);
        });      
      }
      else {
        this.$router.push({ name: 'join' });
      }
    },
    startGame() {
      if(this.players.length > 0) {
        if(this.isGamePlayer) {
          apiService.startGame().then(() => {
            this.$router.push({ name: 'dashboard' });
          }).catch((error) => {
            window.console.log('Error:', error);
          });        
        }
        else {
          this.$router.push({ name: 'dashboard' });
        }
      }
    },
    removeAllPlayers() {
      apiService.removeAllPlayers().then(() => {
        globals.playerName = "";
      }).catch((error) => {
          window.console.log('Error:', error);
      });    
    },
    directions() {
      this.$router.push({ name: 'directions' });
    }
  },
  watch: {
    isGameStarted: function () {
      if(globals.playerName.length > 0) {
        this.$router.push({ name: 'dashboard' });
      }
    }    
  }
}
</script>

<style scoped>
.landing-container button {
  margin: 5px;
}

.landing-container li {
  margin: 5px;
  font-size: 20px;
}

.landing-container .player-title > div {
  font-size: 20px;
  font-weight: bold;
  margin-top: 10px;
}

.landing-container .player-center {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  padding: 5px;
}

.landing-container {
  display: flex;
  justify-content: space-between;
  flex-direction: column;
}
</style>

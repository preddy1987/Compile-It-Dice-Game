<template>
  <div>    
    <dice-view :dice="diceData" />
    <button>Add Player</button>
    <button>Remove Player</button>
    <button>Start Game</button>
    <button>Roll</button>
    <button>Pass Turn</button>
    <player-status />
    <game-status />
  </div>
</template>

<script>
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
      diceData: [{value:'1', color:'red'},{value:'2', color:'green'},{value:'3', color:'yellow'}]
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

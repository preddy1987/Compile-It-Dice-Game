<template>
  <div>    
    <dice-view :dice="diceData" />
  </div>
</template>

<script>
import DiceView from './components/DiceView.vue'

export default {
  name: 'App',
  components: {
    DiceView
  },
  data() {
    return {
      diceData: [{value:'1', color:'red'},{value:'2', color:'green'},{value:'3', color:'yellow'}]
    }
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>

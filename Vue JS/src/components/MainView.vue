<template>
  <div>    
    <die v-for="die in dice" :startImageAddress="die.address" :startImageAddressId="die.value" :key="die.id"></die>
    <div>
      <roll></roll>
    </div>
  </div>
</template>

<script>
import {eventHandler} from '@/main.js';
import Roll from './Roll.vue'
import Die from './Die.vue'

export default {
  name: 'MainView',  
  data() {
    return {
      dice: [
        { id: 1, value: '1', address: '/images/dieRed1.svg' }, 
        { id: 2, value: '1', address: '/images/dieYellow1.svg' },
        { id: 3, value: '1', address: '/images/dieGreen1.svg' },
      ]
    }    
  },
  methods: {
    updateDice() {
      fetch(window.serverUrl + 'api/rolldice')    
      .then( (response) => {          
          return response.json();     
      })
      .then( (data) => {     
          window.console.log(data.message);
      });
    }
  },
  components: {
    Roll,
    Die
  },
  created() {
      eventHandler.$on('roll-dice', this.updateDice);
  }
}
</script>

<style>

</style>

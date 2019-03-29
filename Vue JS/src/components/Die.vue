<template>
    <span class="die">
        <img :src="imageAddress" @click="switchImage" :data="imageAddressId">
    </span>
</template>

<style scoped>
span.die img {
  margin: 10px;
  width: 50px;
}
</style>

<script>
import {eventHandler} from '@/main.js';
export default {
  name: 'die',
  props: {
    startImageAddress: String,
    startImageAddressId: String
  },
  data() {
    return {
       imageAddress: this.startImageAddress,
       imageAddressId: Number(this.startImageAddressId),
       dice: [
        {id:'1', address:'/images/dieRed1.svg'}, 
        {id:'2', address:'/images/dieRed2.svg'}, 
        {id:'3', address:'/images/dieRed3.svg'},
        {id:'4', address:'/images/dieRed4.svg'},
        {id:'5', address:'/images/dieRed5.svg'},
        {id:'6', address:'/images/dieRed6.svg'},
        {id:'1', address:'/images/dieGreen1.svg'}, 
        {id:'2', address:'/images/dieGreen2.svg'}, 
        {id:'3', address:'/images/dieGreen3.svg'},
        {id:'4', address:'/images/dieGreen4.svg'},
        {id:'5', address:'/images/dieGreen5.svg'},
        {id:'6', address:'/images/dieGreen6.svg'},
        {id:'1', address:'/images/dieYellow1.svg'}, 
        {id:'2', address:'/images/dieYellow2.svg'}, 
        {id:'3', address:'/images/dieYellow3.svg'},
        {id:'4', address:'/images/dieYellow4.svg'},
        {id:'5', address:'/images/dieYellow5.svg'},
        {id:'6', address:'/images/dieYellow6.svg'}
      ]
    }
  },
  methods: {
    switchImage(e) {
        this.imageAddressId = e.currentTarget.getAttribute('data');
        if(this.imageAddressId == 6) {
            this.imageAddressId = 1;    
        }
        else {
            this.imageAddressId++;
        }
        this.imageAddress = `/images/dieBlack${this.imageAddressId}.svg`;
    },
    updateWithRandomDie() {
        const rnd = Math.trunc(Math.random() * 18);
        this.imageAddress = this.dice[rnd].address;
        this.imageAddressId = this.dice[rnd].id;
    }
  },
  created() {
      eventHandler.$on('roll-dice', this.updateWithRandomDie);
  }
}
</script>
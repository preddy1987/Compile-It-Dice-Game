<template>
  <div>    
    <span v-for="die in diceData" :key="die.id">
        <img :src="die.address">
    </span>
  </div>
</template>

<script>
export default {
  name: 'DiceView',
  props: {
    // [{value:'1', color:'red'},{value:'1', color:'red'},{value:'1', color:'red'}], value options are 1-6 and color options are green, yellow, and red
    dice: Array
  },
  data() {
    return {
      // This is only here so Vue will pack the images with the component Javascript.
      // The code will be dynamically creating the file names
      dieImages: {
        green: [
          require('../assets/dieGreen1.svg'),
          require('../assets/dieGreen2.svg'),
          require('../assets/dieGreen3.svg'),
          require('../assets/dieGreen4.svg'),
          require('../assets/dieGreen5.svg'),
          require('../assets/dieGreen6.svg')
        ],
        red: [
          require('../assets/dieRed1.svg'),
          require('../assets/dieRed2.svg'),
          require('../assets/dieRed3.svg'),
          require('../assets/dieRed4.svg'),
          require('../assets/dieRed5.svg'),
          require('../assets/dieRed6.svg')
        ],
        yellow: [
          require('../assets/dieYellow1.svg'),
          require('../assets/dieYellow2.svg'),
          require('../assets/dieYellow3.svg'),
          require('../assets/dieYellow4.svg'),
          require('../assets/dieYellow5.svg'),
          require('../assets/dieYellow6.svg')
        ]
      }
    }    
  },
  computed: {
    diceData() {
      let data = []; //[{id:1, address:''}]
      for(let i = 0; i < this.dice.length; i++) {
        data.push({
          id: i,
          address: this.getImageAddress(this.dice[i].value, this.dice[i].color.toLowerCase())
        })
      }
      return data;
    }
  },
  methods: {
    getImageAddress(value, color) {
      let result = '';
      if(color === 'green'){
        result = this.dieImages.green[value-1];
      }
      else if(color === 'red'){
        result = this.dieImages.red[value-1];
      }
      else if(color === 'yellow'){
        result = this.dieImages.yellow[value-1];
      }
      return result;
    }
  }
}
</script>

<style scoped>
div {
  display: flex;
  flex-direction: row;
  justify-content: center;
}
img {
  width: 100%;
  height: auto;
}
span {
  margin: 5px;
}
</style>

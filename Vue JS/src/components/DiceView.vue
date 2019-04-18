<template>
  <div>
    <div class="dieTitle">{{title}}</div>
    <div id="dice-view">
      <span v-for="die in diceData" :key="die.id">
          <img :src="die.address" :style="diceStyle">
      </span>
    </div>
  </div>
</template>

<script>
export default {
  name: 'dice-view',
  props: {
    // [{value:'1', color:'red'},{value:'1', color:'red'},{value:'1', color:'red'}], value options are 1-6 and color options are green, yellow, and red
    dice: Array,
    size: String,
    title: String
  },
  data() {
    return {
      // This is only here so Vue will pack the images with the component Javascript.
      // The code will be dynamically creating the file names
      dieImages: {
        green: [
          require('../assets/dieGreenSuccess.svg'),
          require('../assets/dieGreenWarning.svg'),
          require('../assets/dieGreenError.svg')
        ],
        red: [
          require('../assets/dieRedSuccess.svg'),
          require('../assets/dieRedWarning.svg'),
          require('../assets/dieRedError.svg')
        ],
        yellow: [
          require('../assets/dieYellowSuccess.svg'),
          require('../assets/dieYellowWarning.svg'),
          require('../assets/dieYellowError.svg')
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
          address: this.getImageAddress(this.dice[i].compileType.toLowerCase(), this.dice[i].dieType.toLowerCase())
        })
      }
      return data;
    },
    diceStyle(vm) {
      return `width: ${vm.size}`
    }
  },
  methods: {
    getImageAddress(compileType, dieType) {
      let result = '';
      if(dieType === 'green'){
        if(compileType === 'success'){
          result = this.dieImages.green[0];
        }
        else if(compileType === 'warning'){
          result = this.dieImages.green[1];
        }
        else if(compileType === 'error'){
          result = this.dieImages.green[2];
        }
      }
      else if(dieType === 'red'){
        if(compileType === 'success'){
          result = this.dieImages.red[0];
        }
        else if(compileType === 'warning'){
          result = this.dieImages.red[1];
        }
        else if(compileType === 'error'){
          result = this.dieImages.red[2];
        }
      }
      else if(dieType === 'yellow'){
      //   result = this.dieImages.yellow[value-1];
        if(compileType === 'success'){
          result = this.dieImages.yellow[0];
        }
        else if(compileType === 'warning'){
          result = this.dieImages.yellow[1];
        }
        else if(compileType === 'error'){
          result = this.dieImages.yellow[2];
        }
      }
      return result;
    }
  },
  beforeCreate() {
    this.size = '80%';
  }
}
</script>

<style scoped>
#dice-view {
  display: flex;
  flex-direction: row;
  justify-content: center;
  flex-wrap: wrap;
}
#dice-view img {
  height: auto;
  widows: auto;
}
#dice-view span {
  width: 45px;  
  margin: 5px;
}
.dieTitle {
  text-align: center;
  font-size: 20px;
  font-weight: 600;
}
</style>

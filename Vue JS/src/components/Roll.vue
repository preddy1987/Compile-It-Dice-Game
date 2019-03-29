<template>
    <span>
        <input type="button" value="Roll Dice" @click="rollDice">
    </span>
</template>

<style scoped>
span input {
  margin: 10px;
}
</style>

<script>
import {eventHandler} from '@/main.js';

export default {
  name: 'roll',
  methods: {
    rollDice() {
        eventHandler.$emit('roll-dice');
    }
  }
}
</script>
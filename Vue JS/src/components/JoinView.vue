<template>
  <div>
    <form @submit.prevent="addPlayer">
      <input type="text" name="name" v-model="name" placeholder="Name">
      <input type="submit" value="Join">
    </form>
  </div>
</template>

<script>
import {serverUrl} from '@/main.js';
export default {
  name:"JoinView",
  data() {
      return {
          name: ""
      }
  },
  methods: {
    addPlayer() {
      const player = {};
      player.name = this.name;

      let ajaxURL = serverUrl + "api/player";

      //http://localhost:50260/api/player
      fetch(ajaxURL, {
          method: 'post',
          headers: {
              "Content-Type": "application/json"
          },
          body: JSON.stringify(player)
      })
      .then((response) => {
          return response.json();
      })
      .then((data) => {
          window.console.log(data);
          this.$emit('playerAdded', data);
      })
      .catch((error) => {
          window.console.log('Error:', error);
      });
    }
  }
}
</script>

<style scoped>

</style>

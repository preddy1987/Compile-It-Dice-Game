<template>
  <div>
    <form @submit.prevent="addPlayer">
      <input type="text" name="name" v-model="name" placeholder="Name">
      <input type="submit" value="Join">
    </form>
  </div>
</template>

<script>
import {APIService} from '@/APIService';
import {globals} from '@/main.js';
const apiService = new APIService();
export default {
  name:"JoinView",
  data() {
      return {
          name: ""
      }
  },
  methods: {
    addPlayer() {
      globals.playerName = this.name;
      apiService.addPlayer(this.name).then((data) => {
        window.console.log(data);
        this.$router.push({ name: 'landing' });
      })
      .catch((error) => {
        window.console.log('Error:', error);
        globals.playerName = "";
      });
    }
  }
}
</script>

<style scoped>

</style>

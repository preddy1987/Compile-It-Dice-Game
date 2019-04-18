<template>
  <div id="join">
    <div>
      <input v-model="name" type="text" class="form-control" placeholder="What shall we call you?" aria-label="Recipient's username with two button addons" aria-describedby="button-addon4">
      <div>{{error}}</div>    
    </div>
    <div>
      <button @click="join" class="btn btn-primary" type="button">Join</button>
      <button @click="cancel" class="btn btn-secondary" type="button">Cancel</button>
    </div>
  </div>
</template>

<script>
import {APIService} from '@/APIService';
import {globals} from '@/main.js';
const apiService = new APIService();
export default {
  name:"join-view",
  data() {
      return {
          name: "",
          error: ""
      }
  },
  methods: {
    join() {
      globals.playerName = this.name;
      apiService.addPlayer(this.name).then(() => {
        this.$router.push({ name: 'landing' });
      })
      .catch((error) => {
        window.console.log('Error:', error);
        globals.playerName = "";
        this.error = "This name is already taken."
      });
    },
    cancel() {
      this.$router.go(-1);
    }    
  }
}
</script>

<style scoped>
#join {
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 100%;
  padding: 10px;
  flex-direction: column;
}

#join input {
  margin-top: 50%;
}

#join button {
  margin: 5px;
}
</style>

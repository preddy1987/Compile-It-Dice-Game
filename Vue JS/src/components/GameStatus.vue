<template>
  <div id="game-status">
    <div>
      <div>Name</div>
      <div>Round</div>
      <div>Score</div>
      <div>Place</div>
    </div>
    <div v-for="player in players" :key="player.name">
      <div :class="(player.current === true ? 'current-player':'')">{{player.name}}</div>
      <div :class="(player.current === true ? 'current-player':'')">{{player.round}}</div>
      <div :class="(player.current === true ? 'current-player':'')">{{player.score}}</div>
      <div :class="(player.current === true ? 'current-player':'')">{{player.place}}</div> 
    </div>
  </div>
</template>

<script>
export default {
  name: "game-status",
  props: {
    players: Array
  }
};
</script>

<style scoped>
#game-status {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding-top: 5px;
  padding-bottom: 5px;
  background-color: lightgoldenrodyellow;
}

#game-status .current-player {
  color: darkorchid; 
}

#game-status > div div {
  font-weight: 500;
  font-size: 20px;
}

#game-status div {
  display: flex;
  flex-direction: row;
  justify-content: space-evenly;
  width: 100%;
}
</style>

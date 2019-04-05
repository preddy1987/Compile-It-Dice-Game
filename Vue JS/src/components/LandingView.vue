<template>
    <div class = 'landing-container'>
    <img class ='title-image' src ='../assets/CompileIt.svg'/>
    <p>Welcome to our game. There are 13 dice that are colored red, 
        yellow and green that are rolled 3 at a time. The dice have a
        success, warning, and error. The goal 
        is to collect 13 successes to win. If you get 3 errors
        then the successes that you have collected that turn will
        not be banked. You can end your turn anytime to bank your 
        successes. As you collect successes and errors those
        dice are replaced with dice from your cup.</p>
    <button>Join</button>
   
    <ul class="player-list">
                <h4>Players</h4>
                <li class="player-item" v-for="player in playersList" :key="player.id" :class="{ current: player.current }">{{player.name}}</li>
            </ul>
  
    </div>
</template>

<script>

export default {
name: 'landing-view',    
data() {
    players: []
},

}



</script>

<style>
.landing-container {
    margin : 3%;
}


</style>

<template>
    <div class="game-status">
        <h4>Scoreboard</h4>
        <ul class="player-container">
            <li class="player" v-for="player in playersList" :key="player.id" :class="{ current: player.current }">{{player.name}}
                <span class="round">Round: {{player.round}}</span>
                <span class="score">Score: {{player.score}}</span>
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name:'game-status',
    props: {
        players: Array,
    },
    computed: {
        playersList() {
            let people = [];
            for(let i = 0; i < this.players.length; i++){                
                    people.push({
                        id: i,
                        name: this.players[i].name,
                        current: this.players[i].current,
                        score: this.players[i].score,
                        round: this.players[i].round            
                    })
            }
            return people;
        }
    }
}
</script>

<style scoped>
div {
    border: solid 2px black;
    padding: 5px;
}
.current{
    font-weight:bold;
    color: seagreen;
}
.player-container{
    display:grid;
    grid-template-columns: 1fr 1fr 1fr;
    grid-template-areas:
    "player round score"
}
.player{
    grid-area: player;
}
.score{
    grid-area: score;
}
.round{
    grid-area: round;
}
</style>

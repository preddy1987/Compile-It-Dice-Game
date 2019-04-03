<template>
    <div>
        <h4>Scoreboard</h4>
        <div class="game-status">
            <ul class="player list-group list-group-flush">
                <li class="list-group-item">Players</li>
                <li class="list-group-item" v-for="player in playersList" :key="player.id" :class="{ current: player.current }">{{player.name}}</li>
            </ul>
            <ul class="round list-group list-group-flush">
                <li class="list-group-item">Round</li>
                <li class="list-group-item" v-for="player in playersList" :key="player.id" :class="{ current: player.current }">{{player.round}}</li>
            </ul>
            <ul class="score list-group list-group-flush">
                <li class="list-group-item">Score</li>
                <li class="list-group-item" v-for="player in playersList" :key="player.id" :class="{ current: player.current }">{{player.score}}</li>
            </ul>
        </div>
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
div > h4{
    text-align: center;
    margin:auto;
}
.game-status{
    display:grid;
    grid-template-columns: auto auto auto;
    grid-gap: 20px 20px;
}
.player{
 
}
/* .score{
    grid-area: score;
}
.round{
    grid-area: round;
} */
</style>

<template>
    <div>
        <h4>Scoreboard</h4>
        <div class="game-status">
            <ul class="player list-group list-group-flush">
                <span>Players</span>
                <li class="list-group-item" v-for="player in playersList" :key="player.id" :class="{ current: player.current }">{{player.name}}</li>
            </ul>
            <ul class="round list-group list-group-flush">
                <span >Round</span>
                <li class="list-group-item" v-for="player in playersList" :key="player.id" :class="{ current: player.current }">{{player.round}}</li>
            </ul>
            <ul class="score list-group list-group-flush">
                <span >Score</span>
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
.current{
    font-weight:bold;
    color: seagreen;
}
div{
    text-align: center;
    justify-content: center;
    margin:auto;
}
div > h4{
    text-align: center;
    margin:auto;
    background-color: seagreen;
    color: white;
    border-top: solid 2px black;
    border-left: solid 2px black;
    border-right: solid 2px black;
    padding: 5px;
}
.game-status{
    display:grid;
    justify-items: space-evenly;
    align-content: space-evenly;
    grid-template-columns: auto auto auto;
    grid-gap: 20px 60px;
    border: solid 2px black;
    padding: 5px;
}
ul :first-child{
    font-weight: bolder;
    font-size: 18px;
}
</style>

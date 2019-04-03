<template>
    <div class="game-status">
        <h4>Game Status</h4>
        <ul>
            <li v-for="player in playersList" :key="player.id">{{player.name}}</li>
        </ul>
    </div>
</template>

<script>
export default {
    name:'game-status',
    props: {
        players: Array
    },
    computed: {
        playersList() {
            let people = [];
            for(let i = 0; i < this.players.length; i++){
                people.push({
                    id: i,
                    name: this.players[i].name
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
</style>

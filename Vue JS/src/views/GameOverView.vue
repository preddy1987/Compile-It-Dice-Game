<template>
    <div id="game-over">
        <div>GAME OVER</div>
        <div>Winner: <span>{{winner}}</span></div>
        <div>
            <button @click="leave" class="btn btn-secondary" type="button">Continue</button>
        </div>
    </div>
</template>

<script>
import {globals} from '@/main.js';

export default {
    name: 'game-over-view',
    methods: {
        leave() {
            this.$router.push({ name: 'credits' });
        }
    },
    computed: {
        winner() {
            let winner = globals.playerName;
            let players = globals.players;
            let successes = 0;
            players.forEach(player => {
                if(player.totalSuccesses > successes) {
                    winner = player.name;
                    successes = player.totalSuccesses;
                }
            });    
            return winner;            
        }
    }
}
</script>

<style scoped>
#game-over {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-between;
}
#game-over div:nth-child(1) {
    font-size: 40px;
    color: rebeccapurple;
}
#game-over div:nth-child(2) {
    font-size: 30px;
    color: darkblue;
}

#game-over div:nth-child(2) span{
    color: tomato;
}
/* #game-over button {
} */
</style>

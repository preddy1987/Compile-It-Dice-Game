<template>
    <div class="player-status">
        <h2>{{ gameStatus.currentPlayer }}</h2>
        <h4>Total Successes: {{ turnStatus.totalSuccesses }}</h4>
        <h4>Round: {{ turnStatus.round }}</h4>
        <ul>
            <li class="successes">Turn Successes: {{ turnStatus.turnSuccesses }}</li>
            <li class="warnings">Turn Warnings: {{ turnStatus.turnWarnings }}</li>   
            <li class="errors">Turn Errors: {{ turnStatus.turnErrors }}</li>              
        </ul>
    </div>
</template>

<script>
export default {
    name: 'player-status',
    props: {
        gameStatus: {},
        turnStatus: {}
    }
}
</script>

<style scoped>
.successes{
    color: green;
}
.warnings{
    color: yellow;
}
.errors{
    color: red;
}
</style>

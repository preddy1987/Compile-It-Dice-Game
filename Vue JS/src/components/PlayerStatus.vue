<template>
    <div class="player-status">
        <h2>{{ gameStatus.currentPlayer }}</h2>
        <h3>{{ turnStatus.totalSuccesses }}</h3>
        <ul>
            <li>{{ turnStatus.turnSuccesses }}</li>
            <li>{{ turnStatus.turnWarnings }}</li>   
            <li>{{ turnStatus.turnErrors }}</li>              
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

<style>

</style>

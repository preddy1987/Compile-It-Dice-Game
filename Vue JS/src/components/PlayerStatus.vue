<template>
    <div class="player-status">
        <ul class="successes list-group list-group-flush">
            <li class="list-group-item">Successes</li>
            <li class="list-group-item">{{ turnStatus.turnSuccesses }}</li>
        </ul>
        <ul class="warnings list-group list-group-flush">
            <li class="list-group-item">Warnings</li>
            <li class="list-group-item">{{ turnStatus.turnWarnings }}</li>
        </ul>
        <ul class="errors list-group list-group-flush">  
            <li class="list-group-item">Errors</li> 
            <li class="list-group-item">{{ turnStatus.turnErrors }}</li>              
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
.player-status{
    display:grid;
    grid-template-columns: auto auto auto;
    grid-gap: 20px 20px;
    border: solid 2px black;
    padding: 5px;
}
ul :first-child{
    font-weight: bolder;
}

</style>

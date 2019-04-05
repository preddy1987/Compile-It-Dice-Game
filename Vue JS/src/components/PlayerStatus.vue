<template>
    <div class="player-status">
        <button class="btn btn-primary" @click="$emit('roll')" id="roll-button">Roll Dice</button>
        <button class="btn btn-warning" @click="$emit('pass')" id="pass-button">Pass Turn</button>
        <ul class="successes list-group list-group-flush">
            <span>Successes</span>
            <li class="list-group-item">{{ turnStatus.turnSuccesses }}</li>
        </ul>
        <ul class="warnings list-group list-group-flush">
            <span >Warnings</span>
            <li class="list-group-item">{{ turnStatus.turnWarnings }}</li>
        </ul>
        <ul class="errors list-group list-group-flush">  
            <span >Errors</span> 
            <li class="list-group-item">{{ turnStatus.turnErrors }}</li>              
        </ul>
    </div>
</template>

<script>
export default {
    name: 'player-status',
    props: {
        turnStatus: {}
    }
}
</script>

<style scoped>
div{
    text-align: center;
    justify-content: center;
    margin:auto;
}
.player-status{
    display:grid;
    justify-items: space-evenly;
    align-content: space-evenly;
    grid-template-columns: auto auto auto auto auto auto;
    grid-gap: 10px 20px;
    border-top: solid 2px black;
    border-left: solid 2px black;
    border-right: solid 2px black;
    padding: 5px;
}
ul :first-child{
    font-weight: bolder;
}
#roll-button{
    grid-column-start: 1;
    grid-column-end: 3;
}
#pass-button{
    grid-column-start: 4;
    grid-column-end: 6;
}
.successes{
    grid-column-start: 1;
    grid-column-end: 2;
}
.warnings{
    grid-column-start: 3;
    grid-column-end: 4;
}
.errors{
    grid-column-start: 5;
    grid-column-end: 6;
}

</style>

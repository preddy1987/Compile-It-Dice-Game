<template>
    <div id="directions">
        <div>
            <div class="dir-center dir-title"><div>Directions</div></div>
            <ul>
                <li>There are 13 dice that are colored red, yellow and green that are rolled 3 at a time.</li>
                <li>The dice have a success, warning, and error</li>
                <li>The goal is to collect 13 successes to win</li>
                <li>If you get 3 errors then the successes that you have collected that turn will not be banked</li> 
                <li>You can end your turn anytime to bank your successes</li>
                <li>As you collect successes and errors those dice are replaced with dice from your cup</li>
            </ul>
        </div>
        <div class="dir-center"><button class="btn btn-primary" @click="back">Back</button></div> 
    </div>
</template>

<script>
export default {
    name: 'directions-view',
    methods: {
        back() {
            this.$router.go(-1);
        }
    }
}    
</script>

<style>
/* ul {
    list-style-type: none;
} */
#directions {
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-direction: column;
  width: 100%;
  padding-right: 15px;
}

#directions button {
    margin: 5px;
}

.dir-title > div {
  font-size: 20px;
  font-weight: bold;
  padding-top: 10px;
}

.dir-center {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
}
</style>

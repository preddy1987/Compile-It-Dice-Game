<template>
  <div id="dashboard">
    <div class="roll-section">
      <game-status :players="players"/>
      <div class="dv-roll">
        <div>
          <span>
            <dice-view class :dice="diceData" title="Last Roll"/>
          </span>
          <span>
            <dice-view class :dice="successDiceData" title="Successes"/>
          </span>
          <span>
            <dice-view class :dice="errorDiceData" title="Errors"/>
          </span>
        </div>
        <div>
          <dice-view :dice="remainingDiceData" title="Remaining Die"/>
        </div>
      </div>
    </div>
    <div class="dv-buttons">
      <button
        v-if="isPassButtonViewable"
        @click="passTurn"
        class="btn btn-primary"
        type="button"
      >Pass</button>
      <button
        v-if="errorDiceData.length < 3 && isCurrentPlayersTurn"
        @click="rollDice"
        class="btn btn-primary"
        type="button"
      >Roll</button>
      <button @click="quit" class="btn btn-secondary" type="button">Quit</button>
    </div>
  </div>
</template>

<script>
import { APIService } from "@/APIService";
import { globals } from "@/main.js";
import DiceView from "@/components/DiceView.vue";
import GameStatus from "@/components/GameStatus.vue";
const apiService = new APIService();

export default {
  name: "dashboard-view",
  components: {
    DiceView,
    GameStatus
  },
  computed: {
    isPassButtonViewable() {
      return (
        globals.playerName.length > 0 &&
        globals.currentPlayer == globals.playerName
      );
    },
    isRollButtonViewable() {
      return (
        globals.errorDiceData.length < 3 &&
        globals.playerName.length > 0 &&
        globals.currentPlayer == globals.playerName
      );
    },
    diceData() {
      return globals.rollDiceData;
    },
    successDiceData() {
      return globals.successDiceData;
    },
    errorDiceData() {
      return globals.errorDiceData;
    },
    remainingDiceData() {
      return globals.remainingDiceData;
    },
    isCurrentPlayersTurn(vm) {
      return globals.playerName === vm.currentPlayer;
    },
    playerName() {
      return globals.playerName;
    },
    players() {
      return this.getScoreBoardPlayers(globals.players);
    },
    currentPlayer() {
      return globals.currentPlayer;
    },
    isGameOver() {
      return globals.hasWinner;
    },
    isGameActive() {
      return globals.isGameActive;
    }
  },
  methods: {
    getScoreBoardPlayers(players) {
      const result = [];
      let count = 0;
      let place = 1;
      let foundActive = false;
      let foundCurrent = false;
      players.forEach(player => {
        let currentPlayer = player.name === globals.currentPlayer;
        let activePlayer = player.name === globals.playerName;

        if (
          currentPlayer || 
          activePlayer ||
          count < 1 ||
          (count < 2 && (foundActive || foundCurrent)) ||
          (count < 3 && (foundActive && foundCurrent))
        ) {
          const item = {
            score: player.totalSuccesses,
            round: player.roundCount,
            place: place,
            name: player.name,
            current: currentPlayer,
            active: activePlayer
          };
          result.push(item);
          count++;
          if (currentPlayer === true) {
            foundCurrent = true;
          }
          if (activePlayer === true) {
            foundActive = true;
          }
        }    
        place++;    
      });
      return result;
    },
    rollDice() {
      apiService
        .rollDice()
        .then()
        .catch(error => {
          window.console.log("Error:", error);
        });
    },
    passTurn() {
      apiService
        .passTurn()
        .then(data => {
          this.getPlayers();
          this.diceData = [];
          this.updateRemainingDice(data.turnStatus.remainingDice);
        })
        .catch(error => {
          window.console.log("Error:", error);
        });
    },
    quit() {
      if (globals.playerName.length > 0) {
        apiService
          .removeAllPlayers(globals.playerName)
          .then(() => {
            globals.playerName = "";
            this.$router.push({ name: "landing" });
          })
          .catch(error => {
            window.console.log("Error:", error);
            this.$router.push({ name: "landing" });
          });
      } else {
        this.$router.push({ name: "landing" });
      }
    }
  },
  created() {
    this.getPlayers();
  },
  watch: {
    playerName: function() {
      if (globals.playerName.length === 0) {
        this.$router.push({ name: "landing" });
      }
    },
    isGameOver: function() {
      this.$router.push({ name: "gameover" });
    },
    isGameActive: function() {
      if (!this.isGameActive) {
        this.$router.push({ name: "landing" });
      }
    }
  }
};
</script>

<style scoped>
#dashboard .dv-roll {
  display: flex;
  flex-direction: row;
  justify-content: center;
  height: 310px;
}

#dashboard .dv-buttons {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  padding: 5px;
}

#dashboard .dv-buttons button {
  margin: 5px;
}

#dashboard .dv-roll span {
  width: 50%;
}

#dashboard .dv-roll > div {
  width: 50%;
}

#dashboard > .roll-section {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

#dashboard {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  background-color: lightblue;
}
</style>

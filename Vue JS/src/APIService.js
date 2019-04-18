import axios from 'axios';
const API_URL = 'http://192.168.51.44:50260';

export class APIService{
    constructor(){
    }
    
    getPlayers() {
        const url = `${API_URL}/api/players`;
        return axios.get(url).then(response => response.data);
    }

    removePlayer(playerName) {
        const url = `${API_URL}/api/player/${playerName}`;
        return axios.delete(url).then(response => response.data);
    }

    removeAllPlayers() {
        const url = `${API_URL}/api/players`;
        return axios.delete(url).then(response => response.data);
    }

    addPlayer(playerName) {
        const url = `${API_URL}/api/player`;
        const player = {};
        player.name = playerName;
        return axios.post(url, player).then(response => response.data);        
    }

    rollDice() {
        const url = `${API_URL}/api/rolldice`;
        return axios.get(url).then(response => response.data);
    }

    passTurn() {
        const url = `${API_URL}/api/passturn`;
        return axios.get(url).then(response => response.data);
    }

    startGame() {
        const url = `${API_URL}/api/start`;
        return axios.get(url).then(response => response.data);
    }

    getStatus() {
        const url = `${API_URL}/api/status`;
        return axios.get(url).then(response => response.data);
    }
}
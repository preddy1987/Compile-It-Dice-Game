window.vndrServerUrl = "http://localhost:50260/";

document.addEventListener("DOMContentLoaded", (event) => {

    document.querySelector('#getPlayers').addEventListener('click', getPlayersClick);
    document.querySelector('#addPlayer').addEventListener('click', addPlayerClick);
    document.querySelector('#removePlayer').addEventListener('click', removePlayerClick);

});

function getPlayersClick() {
    let ajaxURL = window.vndrServerUrl + "api/players"; 

    fetch(ajaxURL)          // sends an HTTP request to the relative path 'demo.txt'
    .then( (response) => {          // the Promise contains the Response object
        return response.json();     // The Response.json() method returns another Promise
    })
    .then( (data) => {     // this is a bit of magic for now, just know that response is a Response object
        console.log(data.message);  // this block is where we write code to handle the HTTP response, here we're just logging the response object
        displayPlayers(data);
    });

    alert('i have moved on');
}

function removePlayers() {
    // get the node we want to attach to
    const insertHere = document.querySelector('section');

    // remove pre-existing children
    const children = Array.from(insertHere.children);
    children.forEach((element) => {
        insertHere.removeChild(element);
    });
}

function displayPlayers(data) {
    removePlayers();

    if(data.gamePlayers.length > 0)
    {
        // get the node we want to attach to
        const insertHere = document.querySelector('section');

        // loop through the array of names
        data.gamePlayers.forEach( (element) => {
            // create the new node we want to attach
            const nameNode = document.createElement('p');
            // modify the new node with the data we want
            nameNode.innerText = element;
            // attach the new node
            insertHere.insertAdjacentElement('beforeend', nameNode);
        });
    }
    else {
        alert(data.message);
    }
}

function addPlayerClick() {
    let player = {};
    player.name = document.getElementById('playerName').value;
    console.log(player.name);

    let ajaxURL = window.vndrServerUrl + "api/player";

    //http://localhost:50260/api/player
    fetch(ajaxURL, {
        method: 'post', // *GET, POST, PUT, DELETE, etc.
        // mode: 'cors', // no-cors, cors, *same-origin
        headers: {
            "Content-Type": "application/json"
            // "Content-Type": "application/x-www-form-urlencoded"
        },
        // cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
        // credentials: "same-origin", // include, *same-origin, omit
        // redirect: "follow", // manual, *follow, error
        // referrer: "no-referrer", // no-referrer, *client
        body: JSON.stringify(player)
    })
    .then(response => response.json())
    .then( (data) => {     // this is a bit of magic for now, just know that response is a Response object
        console.log(data.message);  // this block is where we write code to handle the HTTP response, here we're just logging the response object
        getPlayersClick();
    })
    .catch(error => console.error('Error:', error));
     
}

function removePlayerClick() {
    let name = document.getElementById('removePlayerName').value;
    console.log(name);

    let ajaxURL = window.vndrServerUrl + `api/player/${name}`;

    //http://localhost:50260/api/player/{name}
    fetch(ajaxURL, {
        method: 'delete',
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then(response => response.json())
    .then( (data) => {     // this is a bit of magic for now, just know that response is a Response object
        console.log(data.message);  // this block is where we write code to handle the HTTP response, here we're just logging the response object
        getPlayersClick();
    })
    .catch(error => console.error('Error:', error));
     
}
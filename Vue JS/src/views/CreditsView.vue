<template>
    <div id="credits-view">
        <div>Chris Rupp</div>
        <img src="https://media.licdn.com/dms/image/C5603AQGkCOjV52c_iQ/profile-displayphoto-shrink_200_200/0?e=1560988800&v=beta&t=Nujhi-0DM7DDRwDQLvtUktAAZVmFAeivwVct2QjRjkw"/>
        <div>Patrick Reddy</div>
        <img src="https://media.licdn.com/dms/image/C4E03AQG57lrbny_xmA/profile-displayphoto-shrink_800_800/0?e=1560988800&v=beta&t=_3mrPaorFIqOxujYj40QKeS3QSfVd7KdjgmdpXS2guI"/>
        <div>Terri Ulloa</div>
        <img src="https://media.licdn.com/dms/image/C4E03AQEkNpCQneqzTQ/profile-displayphoto-shrink_800_800/0?e=1560988800&v=beta&t=MCdPJuBv90JK0fwB9WWuLvpLWHkonZHV99QdhSSZe-Q"/>
        <div>
            <button @click="leave" class="btn btn-secondary" type="button">Continue</button>
        </div>
    </div>
</template>

<script>
export default {
    name:'credits-view',
    methods: {
        leave() {
            this.$router.push({ name: 'landing' });
        }
    },
}
</script>

<style>
#credits-view {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-between;
}

#credits-view img {
    width: 100px;
    animation-name: imageMove;
    animation-duration: 2s;
    animation-iteration-count: infinite;
}

#credits-view div:nth-child(1), #credits-view div:nth-child(3), #credits-view div:nth-child(5) {
    font-size: 30px;
    color:indianred;    
    animation-name: colorShift;
    animation-duration: 10s;
    animation-iteration-count: infinite;
}

@keyframes colorShift {
  from {color: white;}
  to {color: darkblue;}
}

@keyframes imageMove {
  0%   {left:0px; position:relative;}
  25%  {left:125px; position:relative;}
  50%  {left:0px; position:relative;}
  75%  {left:-125px; position:relative;}
  100% {left:0px; position:relative;}
}

</style>

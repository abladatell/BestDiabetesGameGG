<template>
    <div>
<<<<<<< HEAD
        <router-view/>
        <nav-bar></nav-bar>
=======
        <nav-bar></nav-bar>
        <router-view/>
    
>>>>>>> f740980a3ddd7fa830109fbc3dfa10595f1aaa3c
    </div>
</template>

<script>
import Home from "./components/pages/Home.vue";
import NavBar from "./components/NavBar.vue";
<<<<<<< HEAD
=======
import Game from "./components/Game.vue";

>>>>>>> f740980a3ddd7fa830109fbc3dfa10595f1aaa3c

//TODO: animations in transitions
export default {
    components: {
        appHome: Home,
<<<<<<< HEAD
        navBar: NavBar
=======
        navBar: NavBar,
        game: Game
>>>>>>> f740980a3ddd7fa830109fbc3dfa10595f1aaa3c
    }
}
</script>


<style>
body {
  margin: 0;
  padding: 0;
  font-family: sans-serif;
  background: linear-gradient(to left, rgba(7,27,82,1) 0%, rgba(0,128,128,1) 100%); /* w3c */
}

</style>

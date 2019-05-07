<template>
    <div>
        <nav-bar></nav-bar>
        <router-view/>
        <google></google>
    </div>
</template>

<script>
import Home from "./components/pages/Home.vue";
import NavBar from "./components/NavBar.vue";
import Game from "./components/Game.vue";
import GoogleLogin from "./components/pages/GoogleSignin.vue";


//TODO: animations in transitions
export default {
    components: {
        appHome: Home,
        navBar: NavBar,
        game: Game,
        google: GoogleLogin
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

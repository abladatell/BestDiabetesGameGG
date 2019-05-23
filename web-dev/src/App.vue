<template>
    <div>
        <nav-bar></nav-bar>
        <router-view/>
    </div>
</template>

<script>
import Home from "./components/pages/Home.vue";
import NavBar from "./components/NavBar.vue";
import Signup from "./components/auth/Signup.vue";
import Signin from "./components/auth/Signin.vue";

export default {
    components: {
        appHome: Home,
        navBar: NavBar,
    }
};
</script>


<style>
body {
    margin: 0;
    padding: 0;
    font-family: sans-serif;
    background: linear-gradient(
        to left,
        rgba(7, 27, 82, 1) 0%,
        rgba(0, 128, 128, 1) 100%
    );
    /* background: linear-gradient(to left, rgb(88, 0, 0) 0%, darkred 100%); */
}
</style>

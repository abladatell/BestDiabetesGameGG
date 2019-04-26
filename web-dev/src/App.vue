<template>
    <div>
        <app-home></app-home>
        <nav-bar></nav-bar>
    </div>
</template>

<script>
import Home from "./components/Home.vue";
import NavBar from "./components/NavBar.vue";

export default {
    components: {
        appHome: Home,
        navBar: NavBar
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

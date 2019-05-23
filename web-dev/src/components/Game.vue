<template>
    <div class="webgl-content">
        <div id="unityContainer" style="width: 1200px; height: 600px"></div>
        <div class="footer">
            <div class="webgl-logo"></div>
            <div class="fullscreen" onclick="unityInstance.SetFullscreen(1)"></div>
            <div class="title">Core</div>
        </div>
        <br>
        <br>
        <b-button @click="reload">Reload</b-button>
    </div>
</template>

<script>
export default {
    mounted() {
        if (localStorage.getItem('reloaded')) {
            // The page was just reloaded. Clear the value from local storage
            // so that it will reload the next time this page is visited.
            localStorage.removeItem('reloaded');
        } else {
            // Set a flag so that we know not to reload the page twice.
            localStorage.setItem('reloaded', '1');
            location.reload();
        }
    },
    //particles UI disabled for game for performance
    created() {
        let e = document.querySelector("#particles-js");
        e.style.display = "none";
    },
    //reload particles
    destroyed() {
        let e = document.querySelector("#particles-js");
        e.style.display = "block";
        location.reload(); //for disabling game sound when moved to another page
    },
    methods: {
        reload() {
            location.reload();
        }
    }
};
</script>


<style>
</style>

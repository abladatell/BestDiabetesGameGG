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
    created() {
        let e = document.querySelector("#particles-js");
        e.style.display = "none";
    },
    destroyed() {
        let e = document.querySelector("#particles-js");
        e.style.display = "block";
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

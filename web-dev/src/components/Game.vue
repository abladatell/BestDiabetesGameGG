<template>
    <div class="webgl-content">
        <div id="unityContainer" style="width: 960px; height: 600px"></div>
        <div class="footer">
            <div class="webgl-logo"></div>
            <div class="fullscreen" onclick="unityInstance.SetFullscreen(1)"></div>
            <div class="title">Core</div>
        </div><br><br>
        <b-button @click="reload">Reload</b-button>
    </div>
</template>

<script>
export default {
    created() {
        document.getElementById('particles-js').remove();
    },
    destroyed() {
        let e = document.createElement("div");
        e.setAttribute("id", "particles-js");
        e.style.position = "fixed";
        e.style.marginTop = "-50%";
        e.style.width = "200%";
        e.style.height = "200%";
        e.style.zIndex = "-2";
        document.body.appendChild(e);
        particlesJS.load('particles-js', 'particles.json');
    },
    methods: {
        reload() {
            location.reload();
        }
    }
}
</script>


<style>
</style>

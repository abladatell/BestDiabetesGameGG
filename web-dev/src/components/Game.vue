<template>
    <div class="webgl-content">
        <div id="unityContainer" style="width: 960px; height: 600px"></div>
        <div class="footer">
            <div class="webgl-logo"></div>
            <div class="fullscreen" onclick="unityInstance.SetFullscreen(1)"></div>
            <div class="title">Core</div>
        </div>
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
        document.body.appendChild(e);
        particlesJS.load('particles-js', 'particles.json');
    }
}
</script>


<style>
</style>

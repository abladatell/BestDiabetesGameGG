<template>
    <div>
        <h1>Diabetes Mobile</h1>
        <p>
            Click <a href="./mobile.apk" style="color: yellow" download>here</a> to download mobile version! 😃
        </p>
    </div>
</template>

<script>
export default {
    name: "MobileGame"
};
</script>

<style scoped>
@font-face {
    font-family: "SEGA LOGO FONT";
    font-style: normal;
    font-weight: normal;
    src: local("SEGA LOGO FONT"), url("../assets/SEGA.woff") format("woff");
}

h1 {
    font-family: "SEGA LOGO FONT";
    font-weight: 200;
    color: #0ccac4;
}

p {
    color: azure;
    font-size: 14pt;
    margin-top: 50px;
    margin-left: 50px;
}

a:hover {
    color: rebeccapurple;
}
</style>

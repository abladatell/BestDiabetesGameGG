<template>
    <div>
        <h1>Welcome Aboard!</h1>
        <br>
        <br>
        <h3>Instructions</h3>
        <ol>
            <li>Try out the game by clicking the Game tab</li>
            <li>Read more helpful information about Diabetes after completing the game!</li>
        </ol>
    </div>
</template>

<script>
export default {
    name: "Home"
};
</script>

<style scoped>
@font-face {
    font-family: "SEGA LOGO FONT";
    font-style: normal;
    font-weight: normal;
    src: local("SEGA LOGO FONT"), url("../../assets/SEGA.woff") format("woff");
}

h1,
h3 {
    font-family: "SEGA LOGO FONT";
    font-weight: 200;
    color: #0ccac4;
}
ol {
    color: azure;
}
</style>

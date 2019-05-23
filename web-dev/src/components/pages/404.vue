<template>
    <div>
        <h1>Oops, 404 Error!<br>Page is not found</h1>

        <p>
            Click
            <span @click="downloadLink">here</span> to redirect to the homepage.
        </p>
    </div>
</template>

<script>
export default {
    methods: {
        //helper methods for links
        link() {
            return this.$router.push({path: "/"});
        },
        downloadLink() {
            return this.$router.push({path: "/"})
        }
    }
};
</script>

<style scoped>
@font-face {
    font-family: "SEGA LOGO FONT";
    font-style: normal;
    font-weight: normal;
    src: local("SEGA LOGO FONT"), url("../../assets/SEGA.woff") format("woff");
}

p {
    color: azure;
    margin-top: 50px;
    margin-left: 50px;
    font-size: 14pt;

}
h1 {
    font-family: "SEGA LOGO FONT";
    font-weight: 200;
    color: #0ccac4;
}

span {
    cursor: pointer;
    color: yellow;
}

span:hover {
    color: rebeccapurple;
}
</style>

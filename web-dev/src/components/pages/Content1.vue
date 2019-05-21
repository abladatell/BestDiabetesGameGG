<template>
    <div>
        <b-jumbotron id="JUMBO">
            <h3>What is Diabetes?</h3>
            <ul>
                <li>It's when the body cant produce or properly use insulin.</li>
                <li>Insulin is responsible for regulating the Sugar in the blood.</li>
                <li>Too much sugar in the blood can cause organ and nerve damage.</li>
                <li>11 million Canadians are living with some form of diabetes.</li>
                <li>That is about 1/3 of all Canadians.</li>
            </ul>

            <br>

            <h2>Types of diabetes</h2>
            <br>
            <h3>Type 1</h3>
            <ul>
                <li>It's an autoimmune disease.</li>
                <li>It prevents production of insulin.</li>
                <li>Develops in childhood, but can sometimes develop in adulthood</li>
                <li>Around 10% of all diabetes cases</li>
            </ul>
            <h3>Type 2</h3>
            <ul>
                <li>Insulin produced isn't used properly or isn't in sufficient quantity.</li>
                <li>It can be managed with proper diet and exercise, however may also require medication.</li>
                <li>Mostly appears in adulthood, but can sometimes develop in childhood.</li>
                <li>About 90% of all diabetes.</li>
            </ul>
            <h3>Gestational Diabetes</h3>
            <ul>
                <li>Is a temporary form of diabetes.</li>
                <li>Occurs during pregnancy.</li>
                <li>Somewhere between 3-20% of pregnant woman develop it.</li>
            </ul>
        </b-jumbotron>
    </div>
</template>

<script>
export default {};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css?family=Abel%27");
div {
    width: 70%;
    margin: auto;
}
#JUMBO {
    background-color: rgba(50, 180, 180, 0.5);
    color: #ffffff;
    font-family: "Abel", sans-serif;
}

li {
    font-size: 120%;
}

@media only screen and (max-width: 900px) {
    div {
        width: 95%;
        margin: auto;
    }
    #JUMBO {
        background-color: rgba(50, 180, 180, 0.5);
        color: #ffffff;
        font-family: "Abel", sans-serif;
    }

    li {
        font-size: 80%;
    }
}
</style>

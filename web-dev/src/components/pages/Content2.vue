<template>
    <div>
        <b-jumbotron id="JUMBO">
            <h3>Risks of Having Diabetes</h3>
            <ul>
                <li>Kidney disease</li>
                <li>Retinopathy</li>
                <li>Stroke</li>
                <li>Anxiety</li>
                <li>Nerve damage</li>
                <li>Amputation</li>
                <li>Erectile Dysfunction</li>
            </ul>

            <br>

            <h3>Risk Factors</h3>
            <ul>
                <li>Overweight/Obese, "Chance to develop diabetes doubles for every 20% increase over desirable body weight."</li>
                <li>Sedentary lifestyle</li>
                <li>Family hisory</li>
                <li>High blood pressure</li>
                <li>Low levels of HDL cholesterol</li>
            </ul>

            <br>

            <h3>Symptoms of Diabetes</h3>
            <ul>
                <li>Extreme thirst</li>
                <li>Weight loss</li>
                <li>Hunger</li>
                <li>Exhaustion</li>
                <li>Skin problems</li>
                <li>Slow to heal</li>
                <li>Increased trips to the washroom</li>
                <li>Yeast infection</li>
                <li>Numbness of the extremitites</li>
                <li>Nausea</li>
                <li>Vomitin</li>
                <li>Frequent infections</li>
            </ul>
        </b-jumbotron>
    </div>
</template>

<script>
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

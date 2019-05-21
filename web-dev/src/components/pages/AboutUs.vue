<template>
    <div>
        <h1>About Us</h1>

        <div id="centeredDiv">
            <img src="Team.jpg">
            <p style="font-family: 'Cute Font', cursive; font-size: 26px">
                It was a rainy day on Sep 17th 2018, I remember as if it was yesterday. The harsh rumble of delivery trucks as they passed by my home. The sweet and solemn smell of rain that kissed the local children as they played outside. The bitter taste of hawaii ka’u fresh from the pot. There, alone, silhouetted against the social static of Kingdom Hearts HD 2.8 Final Chapter Prologue: was me. It was my birthday, and there was only one person on this planet I deemed worthy enough to celebrate the occasion with. My guiding light on this planet, my stable rock against the tidal waves of life, my mother.
                <br>However, the trucks began to screech, the rain stopped falling and the coffee turned sour as I received that fateful phone call. “How could you.” I whisper into the phone, my eyes glazed with rejection. “It. Is. My. Birthday.” “Yeah so the pharmacy at SuperStore is closed, so I’ll just quickly pop by Shoppers for my insulin shot.” Her voice betrays all I thought I knew about this woman I spent my life with. So callous. So uncaring. So cold. “It’s-” I choke on the razor blades that threaten my perfect day. “I’m sorry honey, can you speak up? I don’t think you’re -” BEEP. Its over.
                <br>I can’t bare the lead chains around my chest any longer. The rug stains black, presenting the dark reflection of 2% and splenda to which I stare into. A pact. Signed in grape scented markers. Like the red hot lust of a prowling panther stalking a wounded gazelle, I would use my talents I head spent years cultivating at the bottom of a mountain of hot cheeto bags. Combined, my passion for gaming, and the affliction of my darkest day, could revolutionize the ignorant degenerates of our society toward a righteous cause. Behold, before you lay the fruit of my labours, a herculean task of titanic consequences, over 20 hours spent in development! Journey Into The Absurd, and with it, the death of that beast that has haunted me.
                <br>No more mama. No more.
            </p>

            <p style="font-family: 'Stylish', sans-serif; font-size: 18px">
                <b>Anadi Mishra</b>: He is really good at asking questions, but that's perhaps his weakness that he is "really good" at asking questions.
                When Anadi asks a question it brings in a lot of clarity and bring awareness to the problems which people might not have thought of, however
                this constant erratic questioning can derail the whole conversation and eventually you would wonder, what was the question in the first place. A wild Anadi
                can make it or break your product/service, so some caution and extra poke balls are recommended to catch this absurdity.
                Anadi was responsible for making all the 2d character design of monsters, bosses and the protagonist. He also handled the Game UI/UX, the sound design as well as enemy pathing.
            </p>
            <p style="font-family: 'Stylish', sans-serif; font-size: 18px">
                <b>Devin Spray-Wiegert</b>: Devin once ran into the pepper spray he had used downwind from himself. Analogous for his work ethic, he drives ever harder to make life more difficult for himself, never looking more than one step, or gust of wind, ahead.
                Created the animations, mesh, texture, and most scripts for the player character. Created all Gameworld objects and props, as well as the models for consumable items. Also spent additional time assisting team members with all other modelling and animating, including reworking the fat monster and eye boss. Designed all textures for monsters and objects.
            </p>
            <p style="font-family: 'Stylish', sans-serif; font-size: 18px">
                <b>Garrett Tailby:</b>Who is the dashing overweight knight that will save your night? If you answered Garrett Hunter God damned Tailby, you'd only be half right. This glorious sun praisin', moon worshipin', prideful warrior is the one who does a little bit of everything. A little arcane code here, a bit of scientific tweaking there, and a whole heap of coffee leads to this generalist having a small hand on everything.
                I did the projectiles, sending unity data to database, a bit of 3d modeling, and a whole hell of a lot of scripting for the enemies and the etirety of the boss fight.
            </p>
            <p style="font-family: 'Stylish', sans-serif; font-size: 18px">
                <b>Jake Lim:</b> I do not have an intriguing story, but I developed the website for this fantastic game.<br>
                I did the UI, components, and logic of the website.
            </p>
            <p style="font-family: 'Stylish', sans-serif; font-size: 18px">
                <b>Micheal Kim:</b>I also helped!
            </p>

            <p style="font-family: 'Pacifico', cursive; font-size: 30px">
                <b>
                    <center>Thank you for playing our Game!!!</center>
                </b>
            </p>
        </div>
    </div>
</template>

<script>
export default {
    name: "AboutUs"
};
</script>

<style scoped>
@font-face {
    font-family: "SEGA LOGO FONT";
    font-style: normal;
    font-weight: normal;
    src: local("SEGA LOGO FONT"), url("../../assets/SEGA.woff") format("woff");
}

h1 {
    font-family: "SEGA LOGO FONT";
    font-weight: 200;
    color: #0ccac4;
}

@import url("https://fonts.googleapis.com/css?family=Cute+Font|Pacifico|Stylish&display=swap");
* {
    box-sizing: border-box;
}
body {
    background: radial-gradient(#000, #111), #000;
    min-height: 100vh;
}
canvas {
    position: fixed;
    height: 100vh;
    width: 100vw;
}

#centeredDiv {
    margin: 0 auto;
    width: 50%;
    text-align: center;
    background: white;
    color: black;
    padding-bottom: 10px;
}
</style>

<template>
    <div>
        <button @click="fetchData">fetchtest</button>
        <button @click="showCurrent">displaytoconsole</button>
    </div>
</template>

<script>
import axios from "axios";
export default {
    data() {
        return {
            scores: []
        }
    },
    methods: {
        fetchData() {
            let board = [];
            
            axios.get("https://bestdiabetesgamegg.firebaseio.com/UserRecords.json")
                .then(res => {
                    Object.keys(res.data).forEach(userId => {
                        // console.log(userId, res.data[userId]);
                        let result = res.data[userId];
                        // board.push({ID: userId});
                        Object.keys(result).forEach(key => {
                            // console.log(result[key])
                            let userScores = result[key];
                            if (userScores.Date) {
                                board.push({
                                    id: userId,
                                    date: userScores.Date,
                                    highSugarTime: userScores.highSugarTime,
                                    lowSugarTime: userScores.lowSugarTime,
                                    insulinUsed: userScores.insulinUsed
                                });
                            }
                        })
                    });
                });
                
                let board2 = board;
                this.$store.commit("pushData", board2);
        },
        showCurrent() {
            console.log(this.$store.state.board);
        }
    }
}
</script>

<style>

</style>

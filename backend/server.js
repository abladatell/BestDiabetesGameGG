const express = require("express");
const bodyParser = require("body-parser");
const knex = require("knex");

const app = express();

app.use(bodyParser.json());

const db = knex({
    client: 'mysql',
    connection: {
        host: '127.0.0.1',
        user: 'devuser',
        password: '',
        database: 'diabetesgame'
    }
});



// db("GameData").insert({
//     userNo: 3,
//     userName: 'betteruser',
//     saveState: "savestate22",
//     LSTime: "02:03:04",
//     HSTime: "03:03:04",
//     totalTime: "05:04:05",
//     firstName: "Jack",
//     password: "22"
// }).then(result => {
//     console.log(result);
// });

// console.log(database.select("*").from("UserSave"));
db.select("*").from("GameData").then(data => {
    console.log(data);
});


app.get("/", (req, res) => {
    res.send("this is working");
});

app.listen(3002, () => {
    console.log("app is running on port 3002");
});
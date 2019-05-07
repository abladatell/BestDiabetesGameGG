const express = require("express");
const bodyParser = require("body-parser");
const app = express();
const knex = require("knex");

const db = knex({
    client: 'mysql',
    connection: {
        host: '127.0.0.1',
        user: 'devuser',
        password: '',
        database: 'diabetesgame'
    }
});

db("UserSave").insert({
    UserNo: 22,
    SaveState: "a322"
    
});

// console.log(database.select("*").from("UserSave"));
db.select("*").from("UserSave").then(data => {
    console.log(data);
});


app.get("/", (req, res) => {
    res.send("this is working");
});

app.listen(3002, () => {
    console.log("app is running on port 3002");
});
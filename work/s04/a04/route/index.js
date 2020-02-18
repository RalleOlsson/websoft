/**
 * General routes.
 */
"use strict";

var express = require('express');
var router = express.Router();

// Add a route for the path /
router.get('/', (req, res) => {
    res.send("Hello World");
});

// Add a route for the path /about
router.get("/about", (req, res) => {
    res.send("About something");
});

router.get("/lotto", (req, res) => {

    let data = {};

    if ("row" in req.query) {
        data.userRow = req.query.row.split(",");
    }

    data.numbers = [];

    for (let i = 0; i < 7; i++) {
        while (true) {
            var randomNbr = Math.floor(Math.random() * 35) + 1;
            if (data.numbers.indexOf(randomNbr) == -1) {
                data.numbers[i] = randomNbr;
                break;
            }
        }
    }

    data.numbers.sort(function(a, b) {
        return a - b;
    });

    res.render("lotto", data);

});

router.get("/lotto-json", (req, res) => {

    let rows;

    if ("row" in req.query) {
        rows = req.query.row.split(",");
    } else {
        rows = [];
        rows[0] = 0;
    }

    let generatedRow = [];

    let correctNbrs = [];
    let nbrOfCorrectAnsr = 0;

    for (let i = 0; i < 7; i++) {
        generatedRow[i] = (Math.floor(Math.random() * 35) + 1);

        for (let n = 0; n < 7; n++) {
            if (generatedRow[i] == rows[n]) {
                correctNbrs.push(rows[n]);
                nbrOfCorrectAnsr++;
            }
        }
    }

    res.json({
        generatedRow: generatedRow,
        userInputedRow: rows,
        correctNbrs: correctNbrs,
        nbrOfCorrectAnsr: nbrOfCorrectAnsr
    });

});




module.exports = router;
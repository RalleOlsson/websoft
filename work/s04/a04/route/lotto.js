/**
 * Route for today.
 */
"use strict";

var express = require("express");
var router = express.Router();

router.get("/lotto", (req, res) => {
    let data = {};

    data.numbers = [];

    for (let i = 0; i < 9; i++) {
        data.numbers[i] = Math.floor(Math.random() * 35) + 1;
    }

    res.render("lotto", data);
});

module.exports = router;
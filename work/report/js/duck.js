"use strict";

(function() {

    var element = document.getElementById("duck");

    var duck = {
        speed: 20,

        moveLeft: function() {
            if (element.offsetLeft > 0) {
                element.style.left = element.offsetLeft + this.speed + "px";
            }
        },
        moveRight: function() {
            if (element.offsetLeft <= window.innerWidth - 128) {
                element.style.left = element.offsetLeft + this.speed + "px";
                console.log(element.style.left);
            }
        },
        printPosX: function() {
            console.log("printPosX: " + element.style.left);
        },
        hide: function() {
            element.hidden = true;
            setTimeout(function() {
                element.hidden = false;
            }, 1000);
        },

    };

    element.addEventListener("click", function() {

        duck.hide();

        console.log("duck clicked");
    });

    element.addEventListener("mouseover", function() {

        duck.moveRight();
        duck.printPosX();

        //console.log("duck: " + duck.speed);
        //console.log(element.clientLeft);
        //console.log("mouseover");
    });

    console.log(element);
    console.log("duck ready");
})();
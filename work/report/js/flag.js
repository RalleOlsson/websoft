(function() {

    'use strict';

    var swedenLink = document.getElementById("draw_sweden");
    var franceLink = document.getElementById("draw_france");
    var denmarkLink = document.getElementById("draw_denmark");

    var flag_container = document.getElementById("flag_container");

    function drawSweden() {
        var flag = '<div class="flag_sweden"><div class="sweden_crossp1"></div><div class="sweden_crossp2"></div></div>';

        flag_container.innerHTML = flag;
        //console.log(flag_container.innerHTML);
        console.log("drawing sweden");
    }

    function drawFrance() {
        var flag = '<div class="flag_france"><div class="france_crossp1"></div><div class="france_crossp2"></div></div>';

        flag_container.innerHTML = flag;
        console.log("drawing france");
    }

    function drawDenmark() {
        var flag = '<div class="flag_denmark"><div class="denmark_crossp1"></div><div class="denmark_crossp2"></div></div>';

        flag_container.innerHTML = flag;
        console.log("drawing denmark");
    }

    swedenLink.addEventListener("click", function() {
        drawSweden();
    })

    franceLink.addEventListener("click", function() {
        drawFrance();
    })

    denmarkLink.addEventListener("click", function() {
        drawDenmark();
    })

})();
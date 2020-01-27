
"use strict";

(function () {
    var element = document.getElementById("duck");

    element.addEventListener("click", function() {
        element.innerHTML = element.innerHTML + "<p>TEST</p>"
        console.log("duck clicked");
    });

    element.addEventListener("mouseover", function() {

       // element.style.left = ;
       element.style.left = element.offsetLeft + 20 + "px";
       console.log(element.style.left);
       console.log(element.clientLeft);
       console.log("mouseover");
    });

    console.log(element);
    console.log("duck ready");
})();
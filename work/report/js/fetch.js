document.getElementById("fill_btn").addEventListener("click", function() {

    'use strict';

    var value = document.getElementById("json_name").value;

    //fetch('https://api.scb.se/UF0109/v2/skolenhetsregister/sv/kommun/1291')
    console.log('data/' + value + '.json');
    fetch('data/' + value + '.json')
        .then((response) => {
            return response.json();
        })
        .then((myJson) => {
            console.log(myJson);
            fillTable(myJson);
        });

});

function fillTable(json) {

    var schools = json.Skolenheter;

    var col = [];
    for (var i = 0; i < schools.length; i++) {
        for (var key in schools[i]) {
            //console.log(col.indexOf(key));
            if (col.indexOf(key) === -1) {
                //console.log("key: " + key);
                col.push(key);
            }
        }
    }

    var table = document.createElement("table");

    var tr = table.insertRow(-1);

    for (var i = 0; i < col.length; i++) {
        var th = document.createElement("th");
        th.innerHTML = col[i];
        tr.appendChild(th);
    }

    for (var i = 0; i < schools.length; i++) {

        tr = table.insertRow(-1);

        for (var j = 0; j < col.length; j++) {
            var tabCell = tr.insertCell(-1);
            tabCell.innerHTML = schools[i][col[j]];
        }
    }

    var tableContainer = document.getElementById("table_container");
    tableContainer.innerHTML = "";
    tableContainer.appendChild(table);
};
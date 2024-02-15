"use strict";
//Update de cookie order met de aangepaste hoeveelheden
document.getElementById('update-caddy').onclick = function () {
    // Create a JSON string using all the data elements on screen - Straight black magic wizardry
    const arr_winkelmand = [];
    const pizza_boxes = document.getElementsByClassName('pizza-info');
    for (const pizza_box of pizza_boxes) {
        let jsonLine = pizza_box.dataset.order_object;
        jsonLine = jsonLine.replace('_', ' ').slice(0, -1);
        const newAantal = pizza_box.querySelector('#inputAantal').value;
        if (newAantal > 0) {
            arr_winkelmand.push(JSON.parse(jsonLine));
            arr_winkelmand[arr_winkelmand.length - 1].aantal = newAantal
        }
    }
    document.cookie = "order=" + JSON.stringify(arr_winkelmand);
    window.location.href = "afrekenen";
}
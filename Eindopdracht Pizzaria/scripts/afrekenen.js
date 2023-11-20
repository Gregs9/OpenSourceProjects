"use strict";

document.getElementById('wijzig-adres').onclick = function () {
    document.getElementById('wijzig-info').style.display = 'block';
    document.getElementById('lever-info').style.display = 'none';
}

document.getElementById('annuleren').onclick = function () {
    document.getElementById('wijzig-info').style.display = 'none';
    document.getElementById('lever-info').style.display = 'block';
}

//Update de cookie met de aangepaste hoeveelheid
document.getElementById('update-caddy').onclick = function () {
    //Straight black magic wizardry
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
    window.location.href = "afrekenen.php";
}

document.getElementById('bestel-link').onclick = function () {
    document.cookie = "name=" + document.getElementById('full-name').innerText;
    document.cookie = "address=" + document.getElementById('address').innerText;
    document.cookie = "city=" + document.getElementById('city').innerText;
    document.cookie = "comment=" + document.getElementById('comment').value;
}
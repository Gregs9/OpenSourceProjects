"use strict";

document.getElementById('wijzig-adres').onclick = function () {
    document.getElementById('wijzig-info').style.display = 'block';
    document.getElementById('lever-info').style.display = 'none';
}

document.getElementById('annuleren').onclick = function () {
    document.getElementById('wijzig-info').style.display = 'none';
    document.getElementById('lever-info').style.display = 'block';
}
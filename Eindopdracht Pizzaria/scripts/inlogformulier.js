"use strict";

const checkbox = document.getElementById('checkbox');
const registratieForm = document.getElementById('include-register');
checkbox.onchange = function () {
    if (registratieForm.style.display === 'block') {
        registratieForm.style.display = 'none';
    } else {
        registratieForm.style.display = 'block';
    }
}

const input_postcode = document.getElementById('reg_postcode');
input_postcode.oninput = function() {
    if (input_postcode.value.length == 4) {
        console.log('full postcode');
    }
}
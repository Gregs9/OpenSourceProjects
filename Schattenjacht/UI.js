"use strict";

haalInstellingeOp();

document.getElementById('win-again').onclick = function () {
    location.reload();
}
document.getElementById('lose-again').onclick = function () {
    location.reload();
}
document.getElementById('difficulty').onchange = function () {
    switch (document.getElementById('difficulty').value) {
        case '4':
            this.style.backgroundColor = "green";
            break;
        case '3':
            this.style.backgroundColor = "yellow";
            break;
        case '2':
            this.style.backgroundColor = "red";
            break;
        case '1':
            this.style.backgroundColor = "purple";
            break;
    }
    sessionStorage.setItem('difficulty', document.getElementById('difficulty').value);
}
document.getElementById('hoogte').oninput = function () {
    document.getElementById('n_hoogte').innerText = this.value;
    sessionStorage.setItem('hoogte', this.value);
}
document.getElementById('breedte').oninput = function () {
    document.getElementById('n_breedte').innerText = this.value;
    sessionStorage.setItem('breedte', this.value);
}
document.getElementById('music_volume').oninput = function () {
    document.getElementById('m_volume').innerText = this.value;
    sfx.changeMusicVolume(this.value);
    sessionStorage.setItem('music_volume', this.value);
}
document.getElementById('sfx_volume').oninput = function () {
    document.getElementById('s_volume').innerText = this.value;
    sfx.changeSfxVolume(this.value);
    sessionStorage.setItem('sfx_volume', this.value);
}



//  Functie van het opslaan van de geselecteerde instelling
function haalInstellingeOp() {
    const ele_difficulty = document.getElementById('difficulty');
    const ele_hoogte = document.getElementById('hoogte');
    const ele_hoogte_n = document.getElementById('n_hoogte');
    const ele_breedte = document.getElementById('breedte');
    const ele_breedte_n = document.getElementById('n_breedte');
    const ele_music_volume = document.getElementById('music_volume');
    const ele_music_volume_m = document.getElementById('m_volume');
    const ele_sfx_volume = document.getElementById('sfx_volume');
    const ele_sfx_volume_n = document.getElementById('s_volume');

    if (sessionStorage.getItem("difficulty")) {
        ele_difficulty.value = sessionStorage.getItem('difficulty');
        switch (ele_difficulty.value) {
            case '4':
                ele_difficulty.style.backgroundColor = "green";
                break;
            case '3':
                ele_difficulty.style.backgroundColor = "yellow";
                break;
            case '2':
                ele_difficulty.style.backgroundColor = "red";
                break;
            case '1':
                ele_difficulty.style.backgroundColor = "purple";
                break;
        }
    }

    if (sessionStorage.getItem('hoogte')) {
        ele_hoogte.value = sessionStorage.getItem('hoogte');
        ele_hoogte_n.innerText = sessionStorage.getItem('hoogte');
    }

    if (sessionStorage.getItem('breedte')) {
        ele_breedte.value = sessionStorage.getItem('breedte');
        ele_breedte_n.innerText = sessionStorage.getItem('breedte');
    }

    if (sessionStorage.getItem('music_volume')) {
        ele_music_volume.value = sessionStorage.getItem('music_volume');
        ele_music_volume_m.innerText = sessionStorage.getItem('music_volume');
    }

    if (sessionStorage.getItem('sfx_volume')) {
        ele_sfx_volume.value = sessionStorage.getItem('sfx_volume');
        ele_sfx_volume_n.innerText = sessionStorage.getItem('sfx_volume');
    }
}
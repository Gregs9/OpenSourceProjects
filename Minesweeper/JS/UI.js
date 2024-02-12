'use strict';

loadSettings();

$('#win-again').click(function () { location.reload(); });
$('#lose-again').click(function () { location.reload(); });


$('#bombs').on("input", function () {
    $('#n_bombs').text(this.value);
    sessionStorage.setItem('bombs', this.value);
});

$('#height').on("input", function () {
    $('#n_height').text(this.value);
    sessionStorage.setItem('height', this.value);
});

$('#width').on("input", function () {
    $('#n_width').text(this.value);
    sessionStorage.setItem('width', this.value);
});

$('#music_volume').on("input", function () {
    $('#n_music_volume').text(this.value);
    sessionStorage.setItem('music_volume', this.value);
});

$('#sfx_volume').on("input", function () {
    $('#n_sfx_volume').text(this.value);
    sessionStorage.setItem('sfx_volume', this.value);
});






function loadSettings() {

    if (sessionStorage.getItem('bombs')) {
        $('#bombs').val(sessionStorage.getItem('bombs'));
        $('#n_bombs').text(sessionStorage.getItem('bombs'));
    }

    if (sessionStorage.getItem('height')) {
        $('#height').val(sessionStorage.getItem('height'));
        $('#n_height').text(sessionStorage.getItem('height'));
    }

    if (sessionStorage.getItem('width')) {
        $('#width').val(sessionStorage.getItem('width'));
        $('#n_width').text(sessionStorage.getItem('width'));
    }

    if (sessionStorage.getItem('music_volume')) {
        $('#music_volume').val(sessionStorage.getItem('music_volume'));
        $('#n_music_volume').text(sessionStorage.getItem('music_volume'));
    }

    if (sessionStorage.getItem('sfx_volume')) {
        $('#sfx_volume').val(sessionStorage.getItem('sfx_volume'));
        $('#n_sfx_volume').text(sessionStorage.getItem('sfx_volume'));
    }
}
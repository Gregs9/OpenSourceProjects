"use strict";

$('#search-favorited-creators').on('input', function() {

    const query = $('#search-favorited-creators').val().toLowerCase();

    $('.creator-box').each(function() {
        
        if ($(this).find('.creator-name').text().toLowerCase().includes(query) || $(this).find('.creator-alias').text().toLowerCase().includes(query)) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });

});
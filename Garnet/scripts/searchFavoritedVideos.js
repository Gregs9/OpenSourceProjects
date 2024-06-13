"use strict";

const csrfToken = 'a19e6ab21ff4ecf98a288be53fbd9acf45bc190a8f0824bd690ad1c7c3a8d1b9';

$('#search-favorited-videos').on('input', function () {

    const query = $('#search-favorited-videos').val().toLowerCase();

    const dataToSend = {
        user_id: $('#search-favorited-videos').data('userid'),
        search_query: query
    };

    getVideoData(dataToSend, $(this));


});

function getVideoData(dataToSend, element) {
    fetch('api.php?action=search_favorited_video', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-CSRF-Token': csrfToken
        },
        body: JSON.stringify(dataToSend) // Convert data to JSON string
    })
        .then(response => {
            if (!response.ok) {
                return response.json().then(errorData => {
                    throw new Error(errorData.error || 'Unknown error occurred');
                });
            }
            // Return the parsed JSON data if the response is ok
            return response.json();
        })
        .then(data => {
            apply_results(data);
        })
        .catch(error => {
            console.log(error.message);
        });
}

function apply_results(arr_video_ids) {
    $('.thumbnail-container, .thumbnail-container-extension').each(function() {
        !arr_video_ids.includes(parseInt($(this).data('id'))) ? $(this).fadeOut() : $(this).fadeIn();
    });
}
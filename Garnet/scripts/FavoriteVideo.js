"use strict";

$("#favorite").click(function () {

    const dataToSend = {
        user_id: $(this).data('userid'),
        video_id: $(this).data('videoid')
    }

    if ($('#favorite').hasClass('favorited')) {
        unfavoriteVideo(dataToSend);
    } else {
        favoriteVideo(dataToSend);
    }
});

function favoriteVideo(dataToSend) {
    fetch('api.php?action=favorite_video', {
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
            flash(data.message, 'success');
            $('#favorite').attr('title', 'Click to unfavorite this video');
            $('#favorite').attr('src', 'assets/unfavorite.png');
            $('#favorite').addClass('favorited');
        })
        .catch(error => {
            flash(error.message, 'error');

        });
}


function unfavoriteVideo(dataToSend) {
    fetch('api.php?action=unfavorite_video', {
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
            $('#favorite').attr('title', 'Click to unfavorite this video');
            $('#favorite').attr('src', 'assets/favorite.png');
            $('#favorite').removeClass('favorited');
            flash(data.message, 'success');
        })
        .catch(error => {
            flash(error.message, 'error');
        });
}



function flash(data, type) {

    const options = {
        progress: true,
        interactive: true,
        timeout: 5000,
        appear_delay: 200,
        container: '.flash-container',
        theme: 'default',
        classes: {
            container: 'flash-container',
            flash: 'flash-message',
            visible: 'is-visible',
            progress: 'flash-progress',
            progress_hidden: 'is-hidden'
        }
    };

    if (type == 'success') {
        window.FlashMessage.success(data, options);
    } else {
        window.FlashMessage.error(data, options);
    }
}
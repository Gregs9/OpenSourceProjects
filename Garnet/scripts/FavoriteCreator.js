"use strict";

const csrfToken = 'a19e6ab21ff4ecf98a288be53fbd9acf45bc190a8f0824bd690ad1c7c3a8d1b9';

$(".HeartAnimation").click(function () {
    const element = $(this);

    const dataToSend = {
        user_id: $(this).data('userid'),
        creator_id: $(this).data('creatorid')
    }

    if ($(this).hasClass('favorited')) {
        unfavoriteCreator(dataToSend, element);
    } else {
        favoriteCreator(dataToSend);
    }
});

function favoriteCreator(dataToSend) {
    fetch('api.php?action=favorite_creator', {
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
            $('.HeartAnimation').addClass("animate");
            $('.HeartAnimation').addClass('favorited');
            $('.HeartAnimation').attr('title', 'Click to favorite this creator');
        })
        .catch(error => {
            flash(error.message, 'error');

        });
}


function unfavoriteCreator(dataToSend, element) {
    fetch('api.php?action=unfavorite_creator', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json', // Specify the content type
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
            element.removeClass('favorited');
            element.removeClass('animate');
            element.attr('title', 'Click to unfavorite this creator');
            
            if (element.parent('.creator-box')) {
                element.parent('.creator-box').fadeOut();
            }
        })
        .catch(error => {
            flash(error.message, 'error')
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
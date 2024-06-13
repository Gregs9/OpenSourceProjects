//hide score button if user has already scored in the last 8 hours
"use strict";

const dataToSend = {
    user_id: parseInt($('#score').data('userid'))
};

fetch('api.php?action=get_last_score', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'X-CSRF-Token': csrfToken //token variable already imported from video_AddOrRemoveTag.js
    },
    body: JSON.stringify(dataToSend)
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
        //if returned data is true, hide score button, else show score button
        if (JSON.parse(data) == 1) {
            $('#score').css('display', 'block');
        } else {
            $('#score').css('display', 'none');
        }
    })
    .catch(error => {
        $('#score').css('display', 'none');
        flash(error.message, 'error');
    });






//score onclick event
$('#score').on('click', function () {
    const dataToSend = {
        user_id: parseInt($('#score').data('userid')),
        video_id: parseInt($('#score').data('videoid'))
    };
    api_addVideoScore(dataToSend);
})



function api_addVideoScore(dataToSend) {
    fetch('api.php?action=add_score', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-CSRF-Token': csrfToken //token variable already imported from video_AddOrRemoveTag.js
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
            hide_score_button();
            $('#video-score').text(parseInt($('#video-score').text()) + 1);
        })
        .catch(error => {
            flash(error.message, 'error');
        });
}

function show_feedback(data) {
    //delete the feedback element if it already exists
    if ($("#feedback").length) {
        $("#feedback").remove();
    }

    let feedback_element = $("<p></p>", {
        id: "feedback",
        text: data,
        css: {
            display: 'block',
        }
    });

    // Make the feedback color red if it contains the word "error"
    if (data.toLowerCase().includes("error")) {
        feedback_element.css('color', 'red');
    } else {
        feedback_element.css('color', 'green');
    }

    // Hide feedback element when it is clicked
    feedback_element.on("click", function () {
        $(this).css('display', 'none');
    });

    // Add feedback element as the first child on the wrapper element
    $("#video-content").prepend(feedback_element);
}

function hide_score_button() {
    //fade effect
    function removeFadeOut(el, speed) {
        var seconds = speed / 1000;
        el.style.transition = "opacity " + seconds + "s ease";

        el.style.opacity = 0;
        setTimeout(function () {
            el.parentNode.removeChild(el);
        }, speed);
    }
    removeFadeOut(document.getElementById('score'), 1000);
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
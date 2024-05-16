//hide score button if user has already scored in the last 8 hours
"use strict";

const dataToSend = {
    user_id: parseInt($('#score').data('userid'))
};

fetch('api.php?action=get_last_score', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'X-CSRF-Token': 'a19e6ab21ff4ecf98a288be53fbd9acf45bc190a8f0824bd690ad1c7c3a8d1b9'
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
        console.log(error.message);
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
            'X-CSRF-Token': 'a19e6ab21ff4ecf98a288be53fbd9acf45bc190a8f0824bd690ad1c7c3a8d1b9'
        },
        body: JSON.stringify(dataToSend) // Convert data to JSON string
    })
        .then(response => {
            console.log(response);
            if (!response.ok) {
                return response.json().then(errorData => {
                    throw new Error(errorData.error || 'Unknown error occurred');
                });
            }
            // Return the parsed JSON data if the response is ok
            return response.json();
        })
        .then(data => {
            show_feedback(data.message);
            hide_score_button();
            $('#video-score').text(parseInt($('#video-score').text()) + 1);
        })
        .catch(error => {
            console.log(error.message);
            alert('Error: ' + error.message);
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
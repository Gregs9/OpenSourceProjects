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
            'X-CSRF-Token': 'a19e6ab21ff4ecf98a288be53fbd9acf45bc190a8f0824bd690ad1c7c3a8d1b9'
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
            console.log(data.message);
            show_feedback(data.message);
            $('#favorite').attr('title', 'Click to unfavorite this video');
            $('#favorite').attr('src', 'assets/unfavorite.png');
            $('#favorite').addClass('favorited');
        })
        .catch(error => {
            console.log(error.message);
            show_feedback(error.message);

        });
}


function unfavoriteVideo(dataToSend) {
    fetch('api.php?action=unfavorite_video', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-CSRF-Token': 'a19e6ab21ff4ecf98a288be53fbd9acf45bc190a8f0824bd690ad1c7c3a8d1b9'
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
            console.log(data.message);
            $('#favorite').attr('title', 'Click to unfavorite this video');
            $('#favorite').attr('src', 'assets/favorite.png');
            $('#favorite').removeClass('favorited');
            show_feedback(data.message)
        })
        .catch(error => {
            console.log(error.message);
            show_feedback(error.message);

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
            textAlign: 'center',
            marginTop: '1rem',
            cursor: 'pointer'
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
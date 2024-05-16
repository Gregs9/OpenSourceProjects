"use strict";

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
            $('.HeartAnimation').addClass("animate");
            $('.HeartAnimation').addClass('favorited');
            $('.HeartAnimation').attr('title', 'Click to favorite this creator');
        })
        .catch(error => {
            console.log(error.message);
            show_feedback(error.message);

        });
}


function unfavoriteCreator(dataToSend, element) {
    fetch('api.php?action=unfavorite_creator', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json', // Specify the content type
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
            element.removeClass('favorited');
            element.removeClass('animate');
            element.attr('title', 'Click to unfavorite this creator');
            
            if (element.parent('.creator-box')) {
                element.parent('.creator-box').fadeOut();
            }
        })
        .catch(error => {
            console.log('Error: ' + error);
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
            marginBottom: '1rem',
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
    $(".wrapper").prepend(feedback_element);
}
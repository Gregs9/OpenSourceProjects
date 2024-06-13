"use strict";
const csrfToken = 'a19e6ab21ff4ecf98a288be53fbd9acf45bc190a8f0824bd690ad1c7c3a8d1b9';
const data = {
    'user_id': $('#score').data('userid')
};

let previous_videos = [];
let current_index = 0;
let allow_scroll = true;

getVideo();

$(document).on('mousewheel', function (event) {
    user_input(event);
});

$(document).keydown(function(event) {
    user_input(event);
});

$('#tutorial').on('click', function() {
    $(this).fadeOut();
})

function user_input(event) {
    if (allow_scroll) {

        //  on mousewheel down or arrow key down
        if ((event.originalEvent.deltaY > 0) || (event.which === 40)) {
            if (current_index >= 0) {

                /*event.preventDefault();*/
                current_index++;
                allow_scroll = false;
                if (current_index < (previous_videos.length - 1)) {
                    display_video(previous_videos[current_index]);
                } else {
                    getVideo();
                }
            }
        }

        //on mousewheel up
        if ((event.originalEvent.deltaY < 0) || (event.which === 38)) {
            if (current_index > 0) {
                /*event.preventDefault();*/
                current_index--;
                display_video(previous_videos[current_index]);
            }
        }

        //on arr
    }
}


function pushToArray(value) {
    // Push the value to the array
    previous_videos.push(value);
    const max_history_length = 20;

    // Check if the length of the array is greater than 50
    if (previous_videos.length > max_history_length) {
        current_index = max_history_length - 1;
        // Remove the first element
        previous_videos.shift();
    }
}

//fetch a random video with a duration less than 30 seconds and with vertical recording
function getVideo() {
    fetch('api.php?action=get_short', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-CSRF-Token': csrfToken
        },
        body: JSON.stringify(data)
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
            let video_data = data.message;
            pushToArray(video_data);
            display_video(video_data)
        })
        .catch(error => {
            console.log(error.message);
            alert(error.message);
        });
}

function display_video(video_data) {

    $('#short').attr('src', video_data.source);
    $('#score').attr('data-videoid', video_data.id);
    $('#creators-container').empty();
    resizeVid();

    //if video is already favorited,
    if (video_data.is_favorited == true) {
        $('#favorite').addClass('favorited');
        $('#favorite').attr('src', 'assets/unfavorite.png');
    } else {
        $('#favorite').attr('src', 'assets/favorite.png');
        $('#favorite').removeClass('favorited');
    }
    $('#favorite').attr('data-videoid', video_data.id);
    $('#favorite').attr('data-userid', data.user_id);

    $('#video-score').text(video_data.score);
    $('#video-views').text(video_data.views);

    for (let creator of video_data.creators) {
        add_creator(creator);
    }


    sleep(500).then(() => {
        allow_scroll = true;
    });
}

function sleep(time) {
    return new Promise((resolve) => setTimeout(resolve, time));
}

function resizeVid() {
    $('#short').height('100%');
    $('#short-container').height('100%');
}

function add_creator(creator) {
    //create an <a> element to link the image to the creator page
    let link = $("<a>");
    link.attr("href", "creator?creator=" + creator.id);


    //create an img element
    let imgElement = $('<img>');
    imgElement.attr('src', creator.profile_pic);
    imgElement.attr('class', 'creator');

    link.append(imgElement);
    $('#creators-container').append(link);
}
"use strict";
const video_id = $('#add-tag').data('videoid');
const user_id = $('#add-tag').data('userid');

$('#add-tag').on('click', function () {
    $(this).remove();
    let tagInput = $('<input>').attr({
        'type': 'text',
        'placeholder': 'Add tag..',
        'class': 'tageditor'
    });

    // Create button tag
    let buttonAdd = $('<button>').attr({
        'type': 'button',
        'class': 'button tiny_button'
    }).text('+');

    // Attach click event handler to button
    buttonAdd.click(function () {
        const dataToSend = {
            user_id: user_id,
            video_id: video_id,
            tag_name: tagInput.val()
        };
        api_AddTag(dataToSend);
    });

    // Append input and button to container
    $('#container-add-tag-label').append(tagInput).append(buttonAdd);

});

$('#remove-tag').on('click', function () {
    $(this).remove();
    let tagInput = $('<input>').attr({
        'type': 'text',
        'placeholder': 'Remove tag..',
        'class': 'tageditor'
    });

    // Create button tag
    let buttonRemove = $('<button>').attr({
        'type': 'button',
        'class': 'button tiny_button'
    }).text('-');

    // Attach click event handler to button
    buttonRemove.click(function () {
        const dataToSend = {
            user_id: user_id,
            video_id: video_id,
            tag_name: tagInput.val()
        };

        api_RemoveTag(dataToSend);
    });

    // Append input and button to container
    $('#container-remove-tag-label').append(tagInput).append(buttonRemove);
});

function api_AddTag(dataToSend) {
    fetch('api.php?action=add_tag', {
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
            alert(data.message);
        })
        .catch(error => {
            console.log(error.message);
            alert('Error: ' + error.message);
        });
}

function api_RemoveTag(dataToSend) {
    fetch('api.php?action=remove_tag', {
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
            alert(data.message);
        })
        .catch(error => {
            console.log(error.message);
            alert('Error: ' + error.message);
        });
}
"use strict";
const csrfToken = 'a19e6ab21ff4ecf98a288be53fbd9acf45bc190a8f0824bd690ad1c7c3a8d1b9';

const video_id = $('#add-tag').data('videoid');
const user_id = $('#add-tag').data('userid');

$('#add-tag').on('click', function () { 
    toggleVisibility($('#add-tag'), $('#add-new-tag-input-container'));
});

$('#remove-tag').on('click', function () { 
    toggleVisibility($('#remove-tag'), $('#remove-new-tag-input-container'));
});


$('#add-new-tag-submit').on('click', function() {
    const suggestedTag = validateInput($('#add-new-tag-input'));
    if (suggestedTag) {
        const dataToSend = {
            user_id: user_id,
            video_id: video_id,
            tag_name: suggestedTag
        };
        api_edit_tag('add_tag', dataToSend);
    }
    $('#add-new-tag-input').val('');
    toggleVisibility($('#add-tag'), $('#add-new-tag-input-container'));
})

$('#remove-new-tag-submit').on('click', function() {
    const suggestedTag = validateInput($('#remove-new-tag-input'));
    if (suggestedTag) {
        const dataToSend = {
            user_id: user_id,
            video_id: video_id,
            tag_name: suggestedTag
        };
        api_edit_tag('remove_tag', dataToSend);
    }
    $('#remove-new-tag-input').val('');
    toggleVisibility($('#remove-tag'), $('#remove-new-tag-input-container'));
})

function api_edit_tag(action, dataToSend) {
    fetch(`api.php?action=${action}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-CSRF-Token': csrfToken
        },
        body: JSON.stringify(dataToSend)
    })
    .then(response => {
        if (!response.ok) {
            return response.json().then(errorData => {
                throw new Error(errorData.error || 'Unknown error occurred');
            });
        }
        return response.json();
    })
    .then(data => {
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
function toggleVisibility(button, container) {
    if (button.hasClass('toggle-hidden')) {
        button.removeClass('toggle-hidden').addClass('toggle-visible');
        button.parent().removeClass('toggle-hidden').addClass('toggle-visible')
    } else {
        button.removeClass('toggle-visible').addClass('toggle-hidden');
        button.parent().removeClass('toggle-visible').addClass('toggle-hidden');
    }

    if (container.hasClass('toggle-hidden')) {
        container.removeClass('toggle-hidden').addClass('toggle-visible');
    } else {
        container.removeClass('toggle-visible').addClass('toggle-hidden');
    }
}
function validateInput(input, minLength = 2, maxLength = 25) {
    const value = input.val();
    if (value.length >= minLength && value.length <= maxLength) {
        return value;
    } else {
        flash(`The suggested tag must be between ${minLength} and ${maxLength} characters long.`, 'error');
        return null;
    }
}
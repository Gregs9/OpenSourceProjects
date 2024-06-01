

//Get possible selected tag from url
const urlParams = new URLSearchParams(window.location.search);
let tag_in_link = urlParams.get('tag');

updateVideoList();

$('#selected-tags a').on('click', function () {
    $(this).remove();
    updateVideoList();
});


$('#tag-list a').on('click', function () {
    let already_exists = false;
    const clicked_tag = $(this);

    $('#selected-tags a').each(function () {
        if (clicked_tag.text().substring(1) === $(this).text()) {
            already_exists = true;
            return false; //Exit the loop early since we already found a match
        }
    });

    if (($('#selected-tags a').length < 5) && (already_exists === false)) {
        let selected_tag_element = $('<a></a>');
        selected_tag_element.text($(this).text().replace('+', ''));
        selected_tag_element.addClass('tag');
        $('#selected-tags').append(selected_tag_element);

        //add event handlers -- make sure they're not added multiple times
        $('#selected-tags a').on('click', function () {
            $(this).remove();
            updateVideoList();
        });

        updateVideoList();

    }
});

//If there is a parameter in the url
if (tag_in_link) {
    //Get element with the parameter name
    $('#tag-list a').each(function () {
        if ($(this).text().toLowerCase() == '+' + tag_in_link.toLowerCase()) {
            //Simulate a click on this link if parameter is found
            $(this).click();
            return false;
        }
    });
}

function updateVideoList() {
    //update hidden inputbox for php request
    const hidden_input_field = $('#input-selected-tags');
    hidden_input_field.val('');

    $('#selected-tags>.tag').each(function () {
        hidden_input_field.val(hidden_input_field.val() + $(this).text() + ';')
    });

    hidden_input_field.val(hidden_input_field.val().slice(0, -1));
}

"use strict";

//Load all available creators given by PHP
let available_creators = $('#available-creators>.creator');
let creator_list = [];


//get creators and their info require for the creator builder
fetch('api.php?action=fetch_creator_data', {
    method: 'GET',
    headers: {
        'Content-Type': 'application/json',
        'X-CSRF-Token': 'a19e6ab21ff4ecf98a288be53fbd9acf45bc190a8f0824bd690ad1c7c3a8d1b9'
    }
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

        creator_list = data.message;

        //populate already submitted creators
        for (const creatorName of $('#creators-line').val().split(';')) {
            for (const creator of creator_list) {
                if (creatorName.toLowerCase() == creator['creator_name'].toLowerCase()) {
                    createSubmittedCreator(creator);
                }
            }
        }

        reloadAvailableCreators();

    })
    .catch(error => {
        console.log(error.message);
    });



















$('#search-creators').on('input', function () {
    const searchValue = $('#search-creators').val().toLowerCase();

    $('#available-creators>.creator').each(function () {
        const creatorName = $(this).text().toLowerCase();
        const creatorAlias = $(this).data('alias') ? $(this).data('alias').toLowerCase() : '';
        if (creatorName.includes(searchValue) || (creatorAlias.includes(searchValue))) {
            $(this).css('display', 'flex');
        } else {
            $(this).css('display', 'none');
        }
    });
});



function createSubmittedCreator(creatorData) {

    let submittedCreatorElement = $('<a></a>');
    let submittedCreatorImg = $('<img>');

    submittedCreatorImg.attr('src', creatorData['creator_profile_pic']);
    submittedCreatorElement.text(creatorData["creator_name"]);
    submittedCreatorElement.attr('data-alias', creatorData["creator_alias"]);
    submittedCreatorElement.addClass('creator');

    submittedCreatorElement.on('click', function () {
        $(this).remove();
        updateCreatorLine();
        reloadAvailableCreators();
    });

    submittedCreatorElement.prepend(submittedCreatorImg);
    $('#submitted-creators').append(submittedCreatorElement);
}
function createAvailableCreator(creatorData) {
    let availableCreatorElement = $('<a></a>');
    let availableCreatorImg = $('<img>');

    availableCreatorImg.attr('src', creatorData['creator_profile_pic']);
    availableCreatorElement.text(creatorData['creator_name']);
    availableCreatorElement.attr('data-alias', creatorData['creator_alias']);
    availableCreatorElement.addClass('creator');

    availableCreatorElement.on('click', function () {
        createSubmittedCreator(creatorData);
        updateCreatorLine();
        $(this).remove();
    });

    availableCreatorElement.prepend(availableCreatorImg);
    if (creatorData['creator_id'] == 0 || creatorData['creator_id'] == 423 || creatorData['creator_id'] == 424) {
        $('#search-creators').after(availableCreatorElement);
    } else {
        $('#available-creators').append(availableCreatorElement);
    }

}
function reloadAvailableCreators() {
    //remove all available tags

    $('#available-creators > .creator').remove();

    let arr_creators_in_creatorline = $('#creators-line').val().split(";");

    for (const available_creator of creator_list) {
        if (!arr_creators_in_creatorline.includes(available_creator['creator_name'])) {
            createAvailableCreator(available_creator);
        }
    }

    $('#search-creators').val('');

}
function updateCreatorLine() {

    $('#creators-line').val('');

    $('#submitted-creators a').each(function () {
        $('#creators-line').val($('#creators-line').val() + $(this).text() + ';');
    });

    $('#creators-line').val($('#creators-line').val().slice(0, -1));
}


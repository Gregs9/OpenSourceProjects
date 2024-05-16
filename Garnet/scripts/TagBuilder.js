"use strict";
//Load all available tags given by PHP
const tag_list = [];
$('#available-tags>.tag').each(function () {
    tag_list.push($(this).text());
});

reloadAvailableTags();

//for each tag in tagline, add it to the selected tags, tagline is loaded in by PHP in this hidden element
for (const tagName of $('#tags').val().split(';')) {
    tagName ? createSubmittedTag(tagName) : null;
}

function createSubmittedTag(tagname) {
    let submittedTagElement = $('<a></a>');
    submittedTagElement.text(tagname);
    submittedTagElement.addClass('tag');

    submittedTagElement.click(function () {
        $(this).remove();
        updateTagLine();
        reloadAvailableTags();
    });

    $('#submitted-tags').append(submittedTagElement);
}

function createAvailableTag(tagname) {
    let availableTagElement = $('<a></a>');
    availableTagElement.text(tagname);
    availableTagElement.addClass('tag');

    availableTagElement.click(function () {
        createSubmittedTag(tagname);
        updateTagLine();
        $(this).remove();
    });

    $('#available-tags').append(availableTagElement);
}

function reloadAvailableTags() {
    //remove all available tags
    $('#available-tags>.tag').each(function () {
        $(this).remove();
    });


    const tag_in_tagline = $('#tags').val().split(";");

    for (const available_tag of tag_list) {
        if (!tag_in_tagline.includes(available_tag)) {
            createAvailableTag(available_tag);
        }
    }

    $('#search-tags').val('');
}

function updateTagLine() {
    $('#tags').val('');

    $('#submitted-tags a').each(function () {
        $('#tags').val($('#tags').val() + $(this).text() + ';');
    });

    $('#tags').val($('#tags').val().slice(0, -1));
}

$('#search-tags').on('input', function () {
    $('#available-tags>.tag').each(function () {
        if ($(this).text().toLowerCase().includes($('#search-tags').val().toLowerCase())) {
            $(this).css('display', 'flex')
        } else {
            $(this).css('display', 'none')
        }
    });
});
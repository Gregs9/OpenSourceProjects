"use strict";


//Get possible selected tag from url
const urlParams = new URLSearchParams(window.location.search);
let tag_in_link = urlParams.get('tag');
let page_no = 1;
let fetchTimeout;




$('.tag-list a').on('click', function () {
    let already_exists = false;
    const clicked_tag = $(this);

    //check that this tag wasn't already selected
    $('#selected-tags a').each(function () {
        if (clicked_tag.text().substring(1) === $(this).text()) {
            already_exists = true;
            return false;
        }
    });

    //only add tag if there are less than 5, and doesn't already exist
    if (($('#selected-tags a').length < 5) && (already_exists === false)) {
        let selected_tag_element = $('<a></a>');
        selected_tag_element.text($(this).text().replace('+', ''));
        selected_tag_element.addClass('tag');
        $('#selected-tags').append(selected_tag_element);

        //add event handlers -- make sure they're not added multiple times
        $('#selected-tags a').on('click', function () {
            $(this).remove();
            updateSelectedTags();
        });

        updateSelectedTags();

    }
});

$('#selected-tags a').on('click', function () {
    $(this).remove();
    updateSelectedTags();
});


//If there is a parameter in the url
if (tag_in_link) {
    //Get element with the parameter name
    $('.tag-list a').each(function () {
        if ($(this).text().toLowerCase() == '+' + tag_in_link.toLowerCase()) {
            //Simulate a click on this link if parameter is found
            $(this).click();
            return false;
        }
    });
} else {
    updateSelectedTags();
}

function updateSelectedTags() {
    
    //update hidden inputbox for php request
    const hidden_input_field = $('#input-selected-tags');
    hidden_input_field.val('');

    $('#selected-tags>.tag').each(function () {
        hidden_input_field.val(hidden_input_field.val() + $(this).text() + ';')
    });

    hidden_input_field.val(hidden_input_field.val().slice(0, -1));
    filter_onChange();
}


/*Debounce to prevent the fetch from triggering too quickly*/
function debounceFetch(func, wait) {
    
    return function(...args) {
        clearTimeout(fetchTimeout);
        fetchTimeout = setTimeout(() => func.apply(this, args), wait);
    };
}



$('#search').on('input', filter_onChange);
$('#order-by').on('change', filter_onChange);
$('#exclude-shorts').on('change', filter_onChange);

function filter_onChange() {
    page_no = 1;
    debounceFetch(fetchVideoList(), 500);
}

function fetchVideoList() {

    $('main.video-list').empty();
    showLoadingAnimation();


    const selected_tags = $('#input-selected-tags').val().split(';');

    const dataToSend = {
        selected_tags: selected_tags,
        query: $('#search').val(),
        order_by: $('#order-by').val(),
        exclude_shorts: $('#exclude-shorts').prop('checked'),
        page_no: page_no
    };

    fetch('api.php?action=getAllVideosPerPageWithFilter', {
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
            displayVideoResults(data.result, data.total_records);
            displayPagination(data.total_records, data.total_pages);
        })
        .catch(error => {
            console.log(error.message);
        });
}

function displayVideoResults(data, total_records) {

    const container = $('main.video-list');

    if (total_records === 0) {
        displayNoResults();
        return;
    }


    for (const video of data) {

        let video_container = $('<a></a>');

        if (video.aspectRatio < 1) {

            video_container.addClass('thumbnail-container-extension');
            video_container.attr('data-id', video.id);
            video_container.attr('href', 'video?id=' + video.id);

            let vertical_img_1 = $('<img>');
            let vertical_img_2 = $('<img>');
            let vertical_img_3 = $('<img>');

            vertical_img_1.addClass('thumbnail-extension');
            vertical_img_1.attr('src', video.thumbnail);
            vertical_img_1.attr('loading', 'lazy');
            vertical_img_2.addClass('thumbnail-extension');
            vertical_img_2.attr('src', video.thumbnail);
            vertical_img_2.attr('loading', 'lazy');
            vertical_img_3.addClass('thumbnail-extension');
            vertical_img_3.attr('src', video.thumbnail);
            vertical_img_3.attr('loading', 'lazy');

            video_container.append(vertical_img_1);
            video_container.append(vertical_img_2);
            video_container.append(vertical_img_3);

        } else {

            video_container.addClass('thumbnail-container');
            video_container.attr('data-id', video.id);
            video_container.attr('href', 'video?id=' + video.id);

            let thumbnail = $('<img>');
            thumbnail.attr('loading', 'lazy');
            thumbnail.addClass('thumbnail');
            thumbnail.attr('src', video.thumbnail);

            video_container.append(thumbnail);

        }

        let video_duration = $('<span></span>');
        video_duration.addClass('duration-on-thumbnail');

        //clean trailing zero's
        let duration_formatted = '';
        if (video.duration.substr(0, 2) == '00') {
            duration_formatted = video.duration.substr(3, 7);
        } else {
            duration_formatted = video.duration;
        }

        video_duration.text(duration_formatted);

        //now append all elements
        video_container.append(video_duration);
        container.append(video_container);
    }

    //scroll video-list back to top
    document.querySelector('main').scrollTop = 0;
    $('.loading-icon').remove();


}

function displayPagination(total_records, total_pages) {
    const pagination_container = $('.pagination');
    $('#total-results').text(total_records + ' Results');
    
    // Clear the pagination container before appending new elements
    pagination_container.empty();
    
    // Calculate the start and end page numbers
    let start_page = page_no;
    let end_page = Math.min(total_pages, page_no + 5);
    
    // If page_no is not on the first page, create a back arrow
    if (page_no > 1) {
        let previous_page = $('<a></a>');
        previous_page.on('click', previousPage);
        previous_page.text('<');
        pagination_container.append(previous_page);
    }
    
    // Always show the first page
    let first_page = $('<a></a>');
    first_page.on('click', () => setPage(1));
    first_page.text(1);
    if (page_no === 1) {
        first_page.addClass('active-page');
    }
    pagination_container.append(first_page);
    
    // Add an ellipsis if there's a gap between the first page and the start page
    if (start_page > 2) {
        let ellipsis = $('<span></span>').text('...');
        pagination_container.append(ellipsis);
    }
    
    for (let i = start_page; i <= end_page; i++) {
        if (i === 1) continue; // Skip the first page as it is already added
        let page = $('<a></a>');
        page.on('click', () => setPage(i));
        page.text(i);
        if (i === page_no) {
            page.addClass('active-page');
        }
        pagination_container.append(page);
    }
    
    // Always show the final page if it's not already included
    if (end_page < total_pages) {
        // Add an ellipsis if there's a gap between the end_page and the final page
        if (end_page < total_pages - 1) {
            let ellipsis = $('<span></span>').text('...');
            pagination_container.append(ellipsis);
        }
        let final_page = $('<a></a>');
        final_page.on('click', () => setPage(total_pages));
        final_page.text(total_pages);
        pagination_container.append(final_page);
    }
    
    // If current page_no is smaller than the total amount of pages, show next button
    if (page_no < total_pages) {
        let next_page = $('<a></a>');
        next_page.on('click', nextPage);
        next_page.text('>');
        pagination_container.append(next_page);
    }
}

function previousPage() {
    page_no--;
    fetchVideoList();
}

function nextPage() {
    page_no++;
    fetchVideoList();
}

function setPage(value) {
    page_no = value;
    fetchVideoList();
}

function displayNoResults() {
    let message_container = $('<div></div>')
    let message = $('<h1></h1>');
    message.text('No results found');
    let message_detailed = $('<h2></h2>');
    message_detailed.text('Try adjusting your filters');
    message_container.append(message);
    message_container.append(message_detailed);
    message_container.addClass('message-container');

    $('.video-list').append(message_container);
    $('.loading-icon').remove();
}

function showLoadingAnimation() {
    let loading_icon = $('<img>');
    loading_icon.attr('src', 'assets/loading.gif');
    loading_icon.addClass('loading-icon');
    $('.video-list').append(loading_icon);
}
"use strict";

let page_no = 1;

fetchVideoList();

$('#filter').on('click', function () {
    page_no = 1;
    fetchVideoList();
});




function fetchVideoList() {

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
    //empty old results first
    container.empty();

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
}

function displayPagination(total_records, total_pages) {
    const pagination_container = $('#page_numbers');
    $('#total-results').text(total_records + ' Results');

    //Clear the pagination container before appending new elements
    pagination_container.empty();

    //if page_no is not on the first page, create a back arrow
    if (page_no > 1) {
        let previous_page = $('<a></a>');
        previous_page.on('click', previousPage);
        previous_page.text('<');
        pagination_container.append(previous_page);
    }

    for (let i = 1; i <= total_pages; i++) {
        let page = $('<a></a>');
        page.on('click', () => setPage(i));
        page.text(i);
        if (i === page_no) {
            page.addClass('active-page');
        }
        pagination_container.append(page);

    }

    //if current page_no is smaller than the total amount of pages, show next button
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

    $('main.video-list').append(message_container);
}
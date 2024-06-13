"use strict";

let page_no = 1;

/*Debounce to prevent the fetch from triggering too quickly*/
let fetchTimeout;
function debounceFetch(func, wait) {
    return function(...args) {
        clearTimeout(fetchTimeout);
        fetchTimeout = setTimeout(() => func.apply(this, args), wait);
    };
}
const debouncedFetchCreatorList = debounceFetch(fetchCreatorList, 300);


fetchCreatorList();


$('#search-creator').on('input', function() {
    page_no = 1;
    debouncedFetchCreatorList();
});

$('#creator-order-by').on('change', function() {
    page_no = 1;
    debouncedFetchCreatorList();
});




function fetchCreatorList() {

    $('#creator-list').empty();
    showLoadingAnimation();

    const dataToSend = {
        query: $('#search-creator').val(),
        order_by: $('#creator-order-by').val(),
        page_no: page_no
    };

    fetch('api.php?action=getAllCreatorsPerPageWithFilter', {
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
            displayCreatorResults(data.result, data.total_records);
            displayPagination(data.total_records, data.total_pages);
        })
        .catch(error => {
            console.log(error.result);
        });
}

function displayCreatorResults(data, total_records) {

    const container = $('#creator-list');

    if (total_records === 0) {
        displayNoResults();
        return;
    }


    for (const creator of data) {

        let creator_container = $('<div></div>');
        creator_container.addClass('creator-container');

        let creator_name = $('<h2></h2>');
        creator_name.text(creator.name);

        let creator_link = $('<a></a>');
        creator_link.attr('href', 'creator?creator=' + creator.id);

        let creator_profile_pic = $('<img>');
        creator_profile_pic.addClass('creator-img')
        creator_profile_pic.attr('src', creator.profile_pic);

        let creator_videos_amount = $('<p></p>');
        creator_videos_amount.addClass('creator-starred');
        creator_videos_amount.text('Starred in ' + creator.starred_in + ' videos');

        creator_link.append(creator_profile_pic);

        creator_container.append(creator_name);
        creator_container.append(creator_link);
        creator_container.append(creator_videos_amount);

        container.append(creator_container);

    }

    //scroll creator-list back to top
    document.querySelector('.creator-container').scrollTop = 0;
    $('#loading_icon').remove();
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
    fetchCreatorList();
}

function nextPage() {
    page_no++;
    fetchCreatorList();
}

function setPage(value) {
    page_no = value;
    fetchCreatorList();
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

    $('#creator-list').append(message_container);
    $('#loading_icon').remove();
}

function showLoadingAnimation() {
    let loading_icon = $('<img>');
    loading_icon.attr('src', 'assets/loading.gif');
    loading_icon.attr('id', 'loading_icon');
    $('#creator-list').append(loading_icon);
}
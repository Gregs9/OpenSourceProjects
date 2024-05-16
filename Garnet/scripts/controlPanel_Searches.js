"use strict";

//For searching the log
$('#search-log').on('input', function() {
    const searchTerm = $(this).val().toLowerCase();
    $('#table-log-info tr').each(function() {
        const row = $(this);
        let matchingRow = false;
        row.find('td').each(function() {
            const cellText = $(this).text().toLowerCase();
            if (cellText.includes(searchTerm)) {
                matchingRow = true;
                return false; 
            }
        });
        row.toggle(matchingRow); // Show or hide the row based on whether there's a match
    });
});

//For searching the creators
$('#search-creators').on('input', function() {
    const searchTerm = $(this).val().toLowerCase();
    $('#table-creator-info tr').each(function() {
        const row = $(this);
        let matchingRow = false;
        row.find('td').each(function() {
            const cellText = $(this).text().toLowerCase();
            if (cellText.includes(searchTerm)) {
                matchingRow = true;
                return false;
            }
        });
        row.toggle(matchingRow); // Show or hide the row based on whether there's a match
    });
});

//For searching the tags
$('#search-tags').on('input', function() {
    const searchTerm = $(this).val().toLowerCase();
    $('#table-tag-info tr').each(function() {
        const row = $(this);
        let matchingRow = false;
        row.find('td').each(function() {
            const cellText = $(this).text().toLowerCase();
            if (cellText.includes(searchTerm)) {
                matchingRow = true;
                return false;
            }
        });
        row.toggle(matchingRow); // Show or hide the row based on whether there's a match
    });
});

//For searching users
$('#search-users').on('input', function() {
    const searchTerm = $(this).val().toLowerCase();
    $('#table-user-info tr').each(function() {
        const row = $(this);
        let matchingRow = false;
        row.find('td').each(function() {
            const cellText = $(this).text().toLowerCase();
            if (cellText.includes(searchTerm)) {
                matchingRow = true;
                return false;
            }
        });
        row.toggle(matchingRow); // Show or hide the row based on whether there's a match
    });
});

//For searching videos
$('#search-videos').on('input', function() {
    const searchTerm = $(this).val().toLowerCase();
    $('#table-videos tr').each(function() {
        const row = $(this);
        let matchingRow = false;
        row.find('td').each(function() {
            const cellText = $(this).text().toLowerCase();
            if (cellText.includes(searchTerm)) {
                matchingRow = true;
                return false;
            }
        });
        row.toggle(matchingRow); // Show or hide the row based on whether there's a match
    });
});
"use strict";

//For searching the log
$('#search').on('input', function() {
    const searchTerm = $(this).val().toLowerCase();
    $('table tbody tr').each(function() {
        const row = $(this);
        let matchingRow = false;
        row.find('td').each(function() {
            const cellText = $(this).text().toLowerCase();
            if (cellText.includes(searchTerm)) {
                matchingRow = true;
                return false; 
            }
        });

    
        row.toggle(matchingRow); //show or hide the row based on whether there's a match
    });
});
<div id="search-log-container">
    <input class="input-element" type="search" id="search" placeholder="Search..">
</div>

<script>
    "use strict";

    //For searching the log
    $('input[type=search]').on('input', function () {
        const searchTerm = $(this).val().toLowerCase();
        $('table tr:gt(0)').each(function () {
            const row = $(this);
            let matchingRow = false;
            row.find('td').each(function () {
                const cellText = $(this).text().toLowerCase();
                if (cellText.includes(searchTerm)) {
                    matchingRow = true;
                    return false;
                }
            });
            row.toggle(matchingRow); // Show or hide the row based on whether there's a match
        });
    });
</script>
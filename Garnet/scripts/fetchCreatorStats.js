"use strict";

const queryString = window.location.search;

//Get creator_id
const urlParams = new URLSearchParams(queryString);
const creator = urlParams.get('creator');

const dataToSend = {
    creator_id: urlParams.get('creator')
};

fetch('api.php?action=fetch_creator_stats', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'X-CSRF-Token': csrfToken
    },
    body: JSON.stringify(dataToSend) // Convert data to JSON string
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
        $('#statistics').append(data.message);
        $('#loading').remove();

    })
    .catch(error => {
        console.log(error.message);
    });


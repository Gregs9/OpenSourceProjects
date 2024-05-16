"use strict";

//For automatically scaling the videoplayer to video's aspect ratio
const video = $('#video')[0];
if (video) {
    if (video.readyState >= 1) {
        resizeVideo(); // If metadata is already loaded, resize immediately
    }
    video.addEventListener('loadedmetadata', resizeVideo);
    $(window).on('resize', resizeVideo);
}

function resizeVideo() {

    // Get initial dimensions
    let videoHeight = Math.round($('#video').height());
    let videoWidth = Math.round($('#video').width());

    // Calculate viewport dimensions based on window height
    const viewportHeight = Math.round(window.innerHeight * 0.80);
    const viewportWidth = Math.round(window.innerWidth * 0.58);

    // Adjust video size to fit within the viewport height
    if (videoHeight !== viewportHeight) {

        // Calculate new width maintaining aspect ratio
        let newVideoWidth = Math.round(videoWidth * viewportHeight / videoHeight);

        // Apply new dimensions
        $('#video').css('height', viewportHeight + 'px');
        $('#video-container, #video-info').css('width', newVideoWidth + 'px');

        // Update dimensions variables
        videoHeight = viewportHeight;
        videoWidth = newVideoWidth;
    }

    // Adjust video width if it's still wider than the viewport
    if (videoWidth > viewportWidth) {

        // Calculate new height maintaining aspect ratio
        let newVideoHeight = Math.round(videoHeight * viewportWidth / videoWidth);

        // Apply new dimensions
        $('#video').css('height', newVideoHeight + 'px');
        $('#video-container, #video-info').css('width', viewportWidth + 'px');

    }


    $('#recommended a').css('width', '100%', 'important');
    $('#recommended a').css('height', $('#recommended a').width() * 0.5625, 'important');
    $('#recommended a').css('height', $('#recommended a').width() * 0.5625, 'important');


}
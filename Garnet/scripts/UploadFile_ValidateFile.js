"use strict";
//automatically add the short/long video tag depending on video length
function AutoAddShortLongTag(seconds) {

    //if video is longer than 59 seconds, add long video tag
    let search_for = seconds > 59 ? 'long video' : 'short video';

    $('#available-tags>.tag').each(function () {
        if ($(this).text().toLowerCase() === search_for) {
            $(this).click();
            return false;
        }
    });
}

function AutoAddVerticalRecordingTag(aspectRatio) {
    //if video's aspect ratio is less than 0.75, it is considered vertical recording
    if (aspectRatio < 0.75) {
        $('#available-tags>.tag').each(function () {
            $(this).text().toLowerCase() === 'vertical recording' ? $(this).click() : null;
        });
    }
    return false;
}

function clearAll() {
    //clear textboxes
    $('#title, #description, #extension, #duration, #filesize').val('');

    //clear video preview
    $('#videoPreviewContainer').css('display', 'none');
    $('#videoPreviewContainer').attr('src', '');
    $('#videoPreview')[0].load();

    //clear thumbnail preview
    $('#thumbnailPreview').attr('src', ''); //might have to put an hashtag here
    $('#thumbnailPreview').css('display', 'none');
    $('#thumbnailPreviewContainer').css('display', 'none');

    $('#first_appeared').val('');
}

function convertSecondsToDuration(seconds) {

    let hours = Math.floor(seconds / 3600);
    let minutes = Math.floor((seconds % 3600) / 60);
    let remainingSeconds = Math.floor(seconds % 60);

    // Add leading zero if needed
    hours = (hours < 10) ? '0' + hours : hours;
    minutes = (minutes < 10) ? '0' + minutes : minutes;
    remainingSeconds = (remainingSeconds < 10) ? '0' + remainingSeconds : remainingSeconds;

    return hours + ':' + minutes + ':' + remainingSeconds;

}

//EVENTS
$('#fileToUpload').on('change', function () {
    const selectedFile = $('#fileToUpload')[0].files[0];


    if (selectedFile !== undefined) {
        const fileSize = selectedFile.size / 1024 / 1024; // in kB
        const allowedTypes = ['video/mp4', 'video/webm', 'video/x-matroska'];

        let validFile = true;

        if (!allowedTypes.includes(selectedFile.type)) {
            clearAll();
            validFile = false;
            alert('Invalid file type. Please upload an MP4, WEBM or MKV file.');
        }

        if (fileSize > 2048) {
            clearAll();
            validFile = false;
            alert('File is too large. You can only upload files up to 2GB.');
        }


        if (validFile) {
            let dotSplits = selectedFile.name.split(".");

            //Only count the last part of the filename as the extension
            $('#title').val('');
            for (let i = 0; i < (dotSplits.length - 1); i++) {
                $('#title').val($('#title').val() + dotSplits[i]);
            }

            //get extention (last part of the string)
            $('#extension').val('.' + dotSplits[dotSplits.length - 1]);

            //get filesize
            $('#filesize').val(Math.round(selectedFile.size / 1024));

            //preview video
            $('#videoPreviewContainer').css('display', 'block');

            //Get duration of video
            const video = $('#videoPreview')[0];
            video.preload = 'metadata';

            video.onloadedmetadata = function () {
                window.URL.revokeObjectURL(video.src); // Release the object URL
                const duration = video.duration;
                $('#duration').val(convertSecondsToDuration(duration))
                AutoAddShortLongTag(duration);
                AutoAddVerticalRecordingTag(video.videoWidth / video.videoHeight);
            };

            //Load video
            $('#sourcePreview').attr('src', URL.createObjectURL(selectedFile));
            $('#videoPreview')[0].load();

            reloadAvailableTags();
            reloadAvailableCreators();

        } else {
            clearAll();
        }
    } else {
        clearAll();
    }
});

$('#thumbnailToUpload').on('change', function () {
    const selectedFile = $('#thumbnailToUpload')[0].files[0];
    if (selectedFile !== undefined) {

        const fileSize = selectedFile.size / 1024 / 1024; // in MiB
        const allowedTypes = ['image/webp', 'image/png', 'image/jpeg', 'image/jpg'];
        let validFile = true;

        if (!allowedTypes.includes(selectedFile.type)) {
            validFile = false;
            $('#thumbnailToUpload').val('');
            alert('Invalid file type. Only PNG, JPG & WEBP files are allowed as thumbnails.');
        }

        if (fileSize > 20) {
            validFile = false;
            $('#thumbnailToUpload').val('');
            alert('File is too large. You can only upload thumbnails up to 20MB.');
        }

        if (validFile) {
            //preview image
            $('#thumbnailPreviewContainer').css('display', 'block');
            $('#thumbnailPreview').css('display', 'block');
            $('#thumbnailPreview').attr('src', URL.createObjectURL(selectedFile));
        } else {
            clearAll();
        }
    } else {
        clearAll();
    }
});

// $('#upload').on('click', function () {
//     if ($('#creators').val() == '') {
//         const options = {
//             progress: true,
//             interactive: true,
//             timeout: 5000,
//             appear_delay: 200,
//             container: '.flash-container',
//             theme: 'default',
//             classes: {
//                 container: 'flash-container',
//                 flash: 'flash-message',
//                 visible: 'is-visible',
//                 progress: 'flash-progress',
//                 progress_hidden: 'is-hidden'
//             }
//         };
//         window.FlashMessage.error('Please select at least one creator.', options);
//     }
// });
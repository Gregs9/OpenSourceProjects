"use strict";

//  Warn the user that changing the video's thumbnail will permanently delete the previous one
$('#thumbnailToUpload').on('input', function () {
    if (confirm("Changing the profile picture will permanently delete the previous profile picture. Are you sure you want to continue?") == true) {
        //thumbnailToUpload.onchange will trigger here
    } else {
        $('#thumbnailToUpload').val('');
    }
});


//  For displaying the thumbnail when another is selected
$('#thumbnailToUpload').on('change', function () {
    const selectedFile = $('#thumbnailToUpload')[0].files[0];
    if (selectedFile !== undefined) {
        const fileSize = selectedFile.size / 1024 / 1024; // in MiB
        const allowedTypes = ['image/webp'];
        let validFile = true;

        if (!allowedTypes.includes(selectedFile.type)) {
            validFile = false
            $('#thumbnailToUpload').val('');
            alert('Invalid file type. Only webp files are allowed as thumbnails.');
        }

        if (fileSize > 20) {
            validFile = false
            $('#thumbnailToUpload').val('');
            alert('File is too large. You can only upload thumbnails up to 20MB.');
        }

        if (validFile) {
            $('#thumbnail-preview').attr('src', URL.createObjectURL(selectedFile));
        }
    }
});
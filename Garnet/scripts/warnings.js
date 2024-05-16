"use strict";

//FOR DELETING VIDEOS
$('#delete-video-link').on('click', function () {
    confirm("Are you sure you want to delete this video?") ? window.location.href = 'edit-video.php?id=' + $('#video_ID').val() + '&deletevideo=' + $('#video_ID').val() : null;
});

//FOR DELETING PRIMARY TAGS
$('#delete-tag-link').on('click', function() {
    if (confirm("Are you sure you want to delete this primary tag? All videos containing this tag will have it removed.")) {
        window.location.href = 'controlpanel_tags.php?remove_tag=' + $('#tag_ID').val();
    }
});

//FOR DELETING CREATORS
$('#delete-creator-link').on('click', function () {
    if (confirm("Are you sure you want to delete this creator? This creator will be removed from every video she may be featured in.")) {
        window.location.href = 'controlpanel_creators?delete_creator=' + $('#creator_ID').val();
    }
});

//FOR DELETING USERS
$('.delete-user-link').on('click', function() {
    confirm("Are you sure you want to delete this user?") ? window.location.href = 'controlpanel_users.php?delete_user=' + $(this).data('userid') : null;
});
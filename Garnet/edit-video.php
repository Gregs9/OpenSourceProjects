<?php
session_start();
require_once ('data/autoloader.php');
require_once ('components/DBNameSnippet.php');
require_once ('components/authManager.php');


//Only execute code if user is an admin, and $_GET['id'] is set and not empty
if (($user->getRole() == 'admin') && isset($_GET['id']) && ($_GET['id'] !== '')) {

    //requires here
    $userSvc = new UserService();
    $videoSvc = new VideoService();
    $tagSvc = new TagService();
    $creatorSvc = new CreatorService();
    $reportSvc = new ReportService();

    $video = $videoSvc->getVideoById((int) $_GET['id']);

    if ($video == null) {
        //ADD FEEDBACK TO SESSION STORAGE
        $_SESSION['feedback'] = 'Video does not exist.';
        $_SESSION['feedback_color'] = 'red';

        //go to nice page
        header('location: controlpanel_videos');
        exit(0);
    }

    $str_existing_creators = '';
    foreach ($creatorSvc->getCreatorsByVideoId(intval($_GET['id'])) as $creator) {
        $str_existing_creators .= ($creator->getName() . ';');
    }
    $str_existing_creators = rtrim($str_existing_creators, ';');

    if (isset($_GET['action']) && $_GET['action'] == 'editvideo') {
        //update video here
        $date_uploaded = new DateTime($_POST['date_added']);

        //generate a new video object and update it
        //update tags
        $tagSvc->removeAllTagsFromVideo($video);
        $arr_tags = explode(';', $_POST['tags']);

        //for each tag in the post value, add it to the video again
        foreach ($arr_tags as $tag_name) {
            $obj_tag = $tagSvc->getTagByName($tag_name);
            if ($obj_tag !== null) {
                $videoSvc->addTagToVideo($obj_tag, $video);
            }
        }

        //update creators
        //delete all creators from video
        $creatorSvc->removeAllCreatorsFromVideo($video);
        $arr_creators = explode(';', $_POST['creators-line']);

        //for each creator in the post value, add it to the video again
        foreach ($arr_creators as $creator_name) {
            $obj_creator = $creatorSvc->getCreatorByName($creator_name);
            if ($obj_creator !== null) {
                $creatorSvc->addCreatorToVideo($obj_creator, $video);
            }
        }

        $video_score = (int) htmlspecialchars($_POST['score']);
        $video_description = (string) htmlspecialchars($_POST['description']);
        $video_views = (int) htmlspecialchars($_POST['views']);
        $video_title = (string) htmlspecialchars($_POST['title']);
        $video_filesize = (int) htmlspecialchars($_POST['filesize']);

        if (!is_numeric($video_score) || $video_score < 0) {
            $_SESSION['feedback'] = 'Video score must be greater than 0!';
            $_SESSION['feedback_color'] = 'red';
            header('location: edit-video?id=' . $video->getId());
            exit(0);
        }

        if (!is_numeric($video_views) || $video_views < 0) {
            $_SESSION['feedback'] = 'Video views must be greater than 0!';
            $_SESSION['feedback_color'] = 'red';
            header('location: edit-video?id=' . $video->getId());
            exit(0);
        }

        if (!is_numeric($video_filesize) || $video_filesize <= 10) {
            $_SESSION['feedback'] = 'Video filesize must be greater than 10 Kb!';
            $_SESSION['feedback_color'] = 'red';
            header('location: edit-video?id=' . $video->getId());
            exit(0);
        }

        //create a new video object to update all data
        $new_video_object = new Video($video->getId(), $video->getFilename(), $video->getExtension(), $date_uploaded, $video_score, $video_description, array(), $video_views, $video_title, $video->getDuration(), $video_filesize, $video->getUploadedBy());
        $videoSvc->updateVideo($new_video_object);


        //target thumbnail file
        $target_file_thumbnail = $contentPath . "/Temp/" . basename($_FILES["thumbnailToUpload"]["name"]);

        //move thumbnail to temporary folder to validate
        move_uploaded_file($_FILES["thumbnailToUpload"]["tmp_name"], $target_file_thumbnail);

        //rename thumbnail TO THE VIDEO'S MD5 HASH VALUE
        rename($target_file_thumbnail, $contentPath . "/Temp/" . $_POST['filename'] . '.webp');
        $target_file_thumbnail = $contentPath . "/Temp/" . $_POST['filename'] . '.webp';

        //add thumbnail to the correct location - it overwrites the current thumbnail by default
        rename($target_file_thumbnail, $contentPath . '/Thumbnails/' . $_POST['filename'] . '.webp');

        //ADD FEEDBACK TO SESSION STORAGE
        $_SESSION['feedback'] = 'Changes saved.';
        $_SESSION['feedback_color'] = 'green';

        //go to nice page

        header('location: edit-video?id=' . $video->getId());
        exit(0);
    }

    if (isset($_GET['deletevideo']) && $_GET['deletevideo'] !== '') {
        //Get video based on it's ID
        $video_in_question = $videoSvc->getVideoById((int) $_GET['deletevideo']);

        //Create the to be deleted paths
        $video_path = $contentPath . '/Videos/' . $video_in_question->getFilename() . $video_in_question->getExtension();
        $thumbnail_path = $contentPath . '/Thumbnails/' . $video_in_question->getFilename() . '.webp';
        //1. DELETE VIDEO FROM CONTENT
        file_exists($video_path) ? unlink($video_path) : null;

        //2. DELETE VIDEO FROM THUMBNAILS
        file_exists($thumbnail_path) ? unlink($thumbnail_path) : null;

        //3. DELETE VIDEO FROM DATABASE
        $videoSvc->deleteVideo($video_in_question);

        //go to nice page
        $_SESSION['feedback'] = 'Video successfully deleted.';
        $_SESSION['feedback_color'] = 'green';
        header('location: controlpanel_videos');
        exit(0);

    }

    require_once ('components/Notification.php');
    include ('presentation/VideoEditorForm.php');

} else {
    echo 'access denied.';
}
<?php
declare(strict_types=1);
session_start();
require_once ('components/authManager.php');
require_once ('data/autoloader.php');
require_once ('components/DBNameSnippet.php');

$VideoSvc = new VideoService();
$tagSvc = new TagService();
$creatorSvc = new CreatorService();
$logSvc = new LogService();

if (isset($_GET['action']) && $_GET['action'] == 'upload') {

    if ($user->getRole() !== 'admin') {
        $_SESSION['feedback'] = 'Given the challenges associated with content moderation, file uploads to the website are restricted to administrators.';
        $_SESSION['feedback_color'] = 'red';
        header("Location: upload");
        exit(0);
    }

    if (!isset($_POST['csrf_token']) || $_POST['csrf_token'] !== $_SESSION['csrf_token']) {
        $_SESSION['feedback'] = 'An error has occurred.';
        $_SESSION['feedback_color'] = 'red';
        header("Location: upload");
        exit(0);
    }

    //target video file 🎥
    $target_file_video = $contentPath . "/Temp/" . basename($_FILES["fileToUpload"]["name"]);

    //target thumbnail file 📷
    $target_file_thumbnail = $contentPath . "/Temp/" . basename($_FILES["thumbnailToUpload"]["name"]);

    //move video to temporary folder to validate
    move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file_video);

    //move thumbnail to temporary folder to validate
    move_uploaded_file($_FILES["thumbnailToUpload"]["tmp_name"], $target_file_thumbnail);

    //rename video file to it's md5 hash value
    $vid_hash = strtoupper(md5_file($target_file_video));
    $vid_extension = strtolower('.' . pathinfo($target_file_video, PATHINFO_EXTENSION));
    rename($target_file_video, $contentPath . "/Temp/" . $vid_hash . $vid_extension);

    //rename thumbnail TO THE VIDEO'S MD5 HASH VALUE
    rename($target_file_thumbnail, $contentPath . "/Temp/" . $vid_hash . '.webp');
    $target_file_thumbnail = $contentPath . "/Temp/" . $vid_hash . '.webp';

    //Check if video already exists by checking it's hash value
    if (file_exists($contentPath . '/Videos/' . $vid_hash . $vid_extension)) {
        //if the file already exists:

        //Tell user that this file already exist
        $_SESSION['feedback'] = 'This video already exists!';
        $_SESSION['feedback_color'] = 'red';

        //delete video in temp folder
        unlink($contentPath . "/Temp/" . $vid_hash . $vid_extension);

        //delete thumbnail in temp folder
        unlink($target_file_thumbnail);

        $logSvc->log(unserialize($_COOKIE['user'], ['User'])->getId(), 'Failed uploading video');

    } else {

        //add video the database
        $dateAdded = new DateTime('now');
        rename($contentPath . "/Temp/" . $vid_hash . $vid_extension, $contentPath . "/Videos/" . $vid_hash . $vid_extension);
        //add thumbnail to the correct location
        rename($target_file_thumbnail, $contentPath . '/Thumbnails/' . $vid_hash . '.webp');

        $uploaded_video_id = $VideoSvc->addVideo((string) $vid_hash, 0, (string) htmlspecialchars($_POST['extension']), (string) htmlspecialchars($_POST['description']), 0, (string) htmlspecialchars($_POST['title']), (string) htmlspecialchars($_POST['duration']), (int) htmlspecialchars($_POST['filesize']), (int) unserialize($_COOKIE['user'], ['User'])->getId());
        $video = $VideoSvc->getVideoById($uploaded_video_id);
        $logSvc->log(unserialize($_COOKIE['user'], ['User'])->getId(), 'Uploaded video', $uploaded_video_id);

        //get tags and their ID's and add em to videotags
        $tag_line = htmlspecialchars($_POST['tags']);
        $arr_tags = explode(";", $tag_line);

        if (count($arr_tags) > 0) {
            foreach ($arr_tags as $tag_name) {
                $tag = $tagSvc->getTagByName($tag_name);
                if ($tag !== null) {

                    $VideoSvc->addTagToVideo($tag, $video);
                }
            }
        }


        //get creators and their ID's and add em to videocreators
        $creator_line = htmlspecialchars($_POST['creators-line']);
        $arr_creators = explode(";", $creator_line);

        if (count($arr_creators) > 0) {
            foreach ($arr_creators as $creator_name) {
                $creator = $creatorSvc->getCreatorByName($creator_name);
                if ($creator !== null) {
                    $creatorSvc->addCreatorToVideo($creator, $video);
                }
            }
        }

        //Tell the user the video has been uploaded to the database
        $_SESSION['feedback'] = 'Your video has been uploaded! <a href="video?id=' . $uploaded_video_id . '">Go to video</a>';
        $_SESSION['feedback_color'] = 'green';
    }
    header("Location: upload.php");
    exit(0);
}

require_once ('components/Notification.php');
include ('presentation/UploadFileForm.php');
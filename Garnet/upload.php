<?php
declare(strict_types=1);
session_start();
require_once ('components/authManager.php');
require_once ('data/autoloader.php');
require_once ('components/DBNameSnippet.php');

$videoSvc = new VideoService;
$tagSvc = new TagService;
$creatorSvc = new CreatorService;
$logSvc = new LogService;

if (isset($_GET['action']) && $_GET['action'] == 'upload') {



    //DONT UPLOAD IF CSRF PROTECTION FAILS
    if (!isset($_POST['csrf_token']) || $_POST['csrf_token'] !== $_SESSION['csrf_token']) {
        $_SESSION['feedback'] = json_encode(['message' => 'Invalid CSRF token.', 'type' => 'error']);
        header("Location: upload");
        exit(0);
    }

    //DONT UPLOAD IF VERIFICATION FAILS
    //get creators and their ID's and add em to videocreators
    $creator_line = htmlspecialchars($_POST['hidden-creators-field']);
    
    $arr_creators = explode(";", $creator_line) ?? [];
    $arr_creator_objects = [];

    foreach ($arr_creators as $creator_name) {
        $creator = $creatorSvc->getCreatorByName($creator_name);
        $arr_creator_objects[] = $creator;
    }
    
    //if all checks succeed, upload file

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

    //get thumbnail's filetype
    $thumbnail_filetype = $_FILES["thumbnailToUpload"]["type"];

    switch ($thumbnail_filetype) {
        case "image/jpeg":
            $image = imagecreatefromjpeg($target_file_thumbnail);
            break;
        case "image/png":
            $image = imagecreatefrompng($target_file_thumbnail);
            break;
        case "image/webp":
            $image = imagecreatefromwebp($target_file_thumbnail);
            break;
        default:
            $_SESSION['feedback'] = json_encode(['message' => 'Invalid thumbnail file format.', 'type' => 'error']);
            header('location: edit-tag?id=' . $tag->getId());
            exit(0);
    }

    //convert image object to webp
    imagewebp($image, $target_file_thumbnail);

    //clean up memory
    imagedestroy($image);

    //rename thumbnail TO THE VIDEO'S MD5 HASH VALUE
    rename($target_file_thumbnail, $contentPath . "/Temp/" . $vid_hash . '.webp');
    $target_file_thumbnail = $contentPath . "/Temp/" . $vid_hash . '.webp';


    //Check if video already exists by checking it's hash value
    if (file_exists($contentPath . '/Videos/' . $vid_hash . $vid_extension)) {
        //if the file already exists:

        //Tell user that this file already exist and if they doubt my judgement they can go fuck themselves
        $_SESSION['feedback'] = json_encode(['message' => 'This video already exists!', 'type' => 'error']);

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

        $uploaded_video_id = $videoSvc->addVideo((string) $vid_hash, 0, (string) htmlspecialchars($_POST['extension']), (string) htmlspecialchars($_POST['description']), 0, (string) htmlspecialchars($_POST['title']), (string) htmlspecialchars($_POST['duration']), (int) htmlspecialchars($_POST['filesize']), (int) $user->getId());
        $video = $videoSvc->getVideoById($uploaded_video_id);
        $logSvc->log(unserialize($_COOKIE['user'], ['User'])->getId(), 'Uploaded video', $uploaded_video_id);

        //get tags and their ID's and add em to videotags
        $tag_line = htmlspecialchars($_POST['tags']);
        $arr_tags = explode(";", $tag_line) ?? [];

        foreach ($arr_tags as $tag_name) {
            $tag = $tagSvc->getTagByName($tag_name);
            $tag !== null ? $videoSvc->addTagToVideo($tag, $video) : null;
        }

        //add creators to video
        array_map(fn($creator) => $creatorSvc->addCreatorToVideo($creator, $video), $arr_creator_objects);

        //Tell the user the video has been uploaded to the database
        $_SESSION['feedback'] = json_encode(['message' => 'Your video has been uploaded! <a class="regular-link" href="video?id=' . $uploaded_video_id . '">Go to video</a>', 'type' => 'success']);

    }
    header("Location: upload.php");
    exit(0);
}


include ('presentation/UploadFileForm.php');
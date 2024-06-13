<?php
session_start();
require_once ('data/autoloader.php');
require_once ('components/DBNameSnippet.php');
require_once ('components/authManager.php');

//Only execute code if user is an admin, and $_GET['id'] is set and not empty
if ($user->getRole() == 'admin' && isset($_GET['id']) && ($_GET['id'] !== '')) {

    $creatorSvc = new CreatorService;
    $reportSvc = new ReportService;
    $creator = $creatorSvc->getCreatorById(intval($_GET['id']));


    if (!$creator) {
        //ADD FEEDBACK TO SESSION STORAGE           
        header('location: 404');
        exit(0);
    }

    if (isset($_GET['action']) && $_GET['action'] == 'editcreator') {

        //generate a new creator object and update it
        $new_creator_object = new Creator((int) $_POST['creator_ID'], (string) $_POST['creator_name'], (string) $_POST['creator_alias'], $_POST['creator_dob'], (string) $_POST['creator_nat'], (string) $_POST['social_in'], (string) $_POST['social_x'], (string) $_POST['creator_description']);

        $creatorSvc->updateCreator($new_creator_object);

        if (isset($_FILES["thumbnailToUpload"]) && $_FILES["thumbnailToUpload"]["error"] == UPLOAD_ERR_OK) {
            //target profile picture file
            $target_file_thumbnail = $contentPath . "/Temp/" . basename($_FILES["thumbnailToUpload"]["name"]);

            //move profile picture to temporary folder to validate
            move_uploaded_file($_FILES["thumbnailToUpload"]["tmp_name"], $target_file_thumbnail);

            //convert file to webp if it isn't already
            //get thumbnail's extension
            $thumbnail_extension = pathinfo($target_file_thumbnail, PATHINFO_EXTENSION);

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

            //rename profile picture TO THE CREATOR'S ID
            rename($target_file_thumbnail, $contentPath . "/Temp/" . $_POST['creator_ID'] . '.webp');
            $target_file_thumbnail = $contentPath . "/Temp/" . $_POST['creator_ID'] . '.webp';

            //add thumbnail to the correct location - it overwrites the current thumbnail by default
            rename($target_file_thumbnail, $contentPath . '/Creator/' . $_POST['creator_ID'] . '.webp');
        }
        //ADD FEEDBACK TO SESSION STORAGE
        $_SESSION['feedback'] = json_encode(['message' => 'Changes saved.', 'type' => 'success']);

        //go to nice page

        header('location: edit-creator?id=' . $creator->getId());
        exit(0);

    }

    include ('presentation/CreatorEditorForm.php');

} else {
    echo 'access denied.';
}
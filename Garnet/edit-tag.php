<?php
session_start();
require_once ('data/autoloader.php');
require_once ('components/authManager.php');

//Only execute code if user is an admin, and $_GET['id'] is set and not empty
if (($user->getRole() == 'admin') && isset($_GET['id']) && ($_GET['id'] !== '')) {
    include ('components/DBNameSnippet.php');

    $tagSvc = new TagService();
    $tag = $tagSvc->getTagById(intval($_GET['id']));


    if (isset($_GET['edit_tag']) && $_GET['edit_tag'] !== '') {

        $old_tag = $tagSvc->getTagById(intval($_GET['id']));

        //generate a new tag object and update it
        $new_tag_object = new Tag((int) $_POST['tag_ID'], (string) $_POST['tag_name'], (string) $_POST['tag_weight'], (string) $_POST['tag_description'], $_POST['tag_dateadded']);
        $tagSvc->updateTag($new_tag_object);

        //if tag is being renamed, change thumbnail file name
        if (str_replace(' ', '', strtolower($old_tag->getName())) !== str_replace(' ', '', strtolower($new_tag_object->getName()))) {
            if (file_exists($contentPath . '/Categories/' . str_replace(' ', '', strtolower($old_tag->getName())) . '.webp')) {
                rename(
                    $contentPath . '/Categories/' . str_replace(' ', '', strtolower($old_tag->getName())) . '.webp',
                    $contentPath . '/Categories/' . str_replace(' ', '', strtolower($new_tag_object->getName())) . '.webp',
                );
            }
        }

        if (isset($_FILES["thumbnailToUpload"]) && $_FILES["thumbnailToUpload"]["error"] == UPLOAD_ERR_OK) {
            //target profile picture file
            $target_file_thumbnail = $contentPath . "/Temp/" . basename($_FILES["thumbnailToUpload"]["name"]);

            //move profile picture to temporary folder to validate
            move_uploaded_file($_FILES["thumbnailToUpload"]["tmp_name"], $target_file_thumbnail);

            $thumbnailFilename = strtolower(preg_replace("/[^a-zA-Z0-9]/", "", $tag->getName()));

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
            rename($target_file_thumbnail, $contentPath . "/Temp/" . $thumbnailFilename . '.webp');
            $target_file_thumbnail = $contentPath . "/Temp/" . $thumbnailFilename . '.webp';

            //add thumbnail to the correct location - it overwrites the current thumbnail by default
            rename($target_file_thumbnail, $contentPath . '/Categories/' . $thumbnailFilename . '.webp');
        }

        //ADD FEEDBACK TO SESSION STORAGE
        $_SESSION['feedback'] = json_encode(['message' => 'Changes saved.', 'type' => 'success']);

        //go to nice page

        header('location: edit-tag?id=' . $tag->getId());
        exit(0);
    }

    include ('presentation/TagEditorForm.php');

} else {
    echo 'access denied.';
}
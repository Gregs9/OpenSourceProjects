<?php
session_start();
require_once ('data/autoloader.php');
require_once ('components/DBNameSnippet.php');
require_once ('components/authManager.php');


//Only execute code if user is an admin
if ($user->getRole() == 'admin') {

    $creatorSvc = new CreatorService;
    $videoSvc = new VideoService;

    if (isset($_GET['action']) && $_GET['action'] == 'add_creator') {

        if (!isset($_POST['csrf_token']) || $_POST['csrf_token'] !== $_SESSION['csrf_token']) {
            $_SESSION['feedback'] = json_encode(['message' => 'An error occurred.', 'type' => 'error']);
            header("Location: controlpanel-creators");
            exit(0);
        }



        //validation & cleaning given data for security
        $creator_name = htmlspecialchars($_POST['input-new-creator']);
        $creator_alias = htmlspecialchars($_POST['input-new-creator-alias']);
        $creator_dob = htmlspecialchars($_POST['input-new-creator-dob']);
        $creator_description = htmlspecialchars($_POST['input-new-creator-description']);
        $creator_nat = htmlspecialchars($_POST['creator_nat']);

        //check if creator doesn't already exist!
        if ($creatorSvc->getCreatorByName(ucwords(strtolower($creator_name)))) {
            $_SESSION['feedback'] = json_encode(['message' => ucwords(strtolower($creator_name)) . ' already exists!', 'type' => 'error']);
            header("Location: controlpanel-creators");
            exit(0);
        }

        $creator_social_in = '';
        $creator_social_x = '';

        if ($creatorSvc->verify_url($_POST['input-new-creator-social_in'])) {
            $creator_social_in = filter_var($_POST['input-new-creator-social_in'], FILTER_SANITIZE_URL);
        }
        if ($creatorSvc->verify_url($_POST['input-new-creator-social_x'])) {
            $creator_social_x = filter_var($_POST['input-new-creator-social_x'], FILTER_SANITIZE_URL);
        }

        //add creator name to database
        $added_creator_id = $creatorSvc->addCreator($creator_name, $creator_alias, $creator_dob, $creator_nat, $creator_social_in, $creator_social_x, $creator_description);

        //Only execute if a file thumbnail was uploaded
        if (isset($_FILES["thumbnailToUpload"]) && $_FILES["thumbnailToUpload"]["size"] > 0) {

            $target_file_thumbnail = $contentPath . "/Temp/" . basename($_FILES["thumbnailToUpload"]["name"]);

            //move thumbnail to temporary folder to validate
            move_uploaded_file($_FILES["thumbnailToUpload"]["tmp_name"], $target_file_thumbnail);

            $filename = $added_creator_id;

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

            rename($target_file_thumbnail, $contentPath . '/Creators/' . $filename . '.webp');

        }
        $_SESSION['feedback'] = json_encode(['message' => $_POST['input-new-creator'] . ' added as a a new creator!', 'type' => 'success']);
        header("Location: controlpanel-creators");
        exit(0);
    }






    if (isset($_GET['delete_creator']) && $_GET['delete_creator'] != "") {

        $creator = $creatorSvc->getCreatorById(intval($_GET['delete_creator']));

        $creatorSvc->deleteCreator($creator);

        //delete the thumbnail
        $filename = $creator->getId();

        //delete video in temp folder
        unlink($contentPath . '/Creators/' . $filename . '.webp');

        $_SESSION['feedback'] = json_encode(['message' => $creator->getName() . ' deleted!', 'type' => 'success']);
        header("Location: controlpanel-creators");
        exit(0);

    }

    include ('presentation/ControlPanelCreatorsForm.php');
} else {
    include ('denied.php');
}
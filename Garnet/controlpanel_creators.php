<?php
session_start();
require_once('data/autoloader.php');
require_once('components/DBNameSnippet.php');
require_once('components/authManager.php');


//Only execute code if user is an admin
if ($user->getRole() == 'admin') {
    
    $creatorSvc = new CreatorService();
    $videoSvc = new VideoService();


    if (isset($_GET['action']) && $_GET['action'] == 'add_creator') {

        if (!isset($_POST['csrf_token']) || $_POST['csrf_token'] !== $_SESSION['csrf_token']) {
            $_SESSION['feedback'] = 'An error has occurred.';
            $_SESSION['feedback_color'] = 'red';
            header("Location: controlpanel_creators");
            exit(0);
        }

        //validation & cleaning given data for security
        $creator_name = htmlspecialchars($_POST['input-new-creator']);
        $creator_alias = htmlspecialchars($_POST['input-new-creator-alias']);
        $creator_dob = htmlspecialchars($_POST['input-new-creator-dob']);
        $creator_description = htmlspecialchars($_POST['input-new-creator-description']);
        $creator_nat = htmlspecialchars($_POST['input-new-creator-nat']);

        $prefix_x = "https://twitter.com";
        $prefix_in = "https://www.instagram.com";

        $creator_social_in = '';
        $creator_social_x = '';

        if (strpos($_POST['input-new-creator-social_in'], $prefix_in) === 0) {
            $creator_social_in = filter_var($_POST['input-new-creator-social_in'], FILTER_SANITIZE_URL);
        }
        if (strpos($_POST['input-new-creator-social_x'], $prefix_x) === 0) {
            $creator_social_x = filter_var($_POST['input-new-creator-social_x'], FILTER_SANITIZE_URL);
        }

        //check if creator doesn't already exist!
        if ($creatorSvc->getCreatorByName(ucwords(strtolower($creator_name)))) {
            $_SESSION['feedback'] = ucwords(strtolower($creator_name)) . ' already exists!';
            $_SESSION['feedback_color'] = 'red';
            header("Location: controlpanel_creators");
            exit(0);
        }

        //add creator name to database
        $added_creator_id = $creatorSvc->addCreator($creator_name, $creator_alias, $creator_dob, $creator_nat, $creator_social_in, $creator_social_x, $creator_description);

        //the creator profile pic has the same variable name as the add tag thulbnail, change this if this causes issues
        //target thumbnail file
        //Only execute if a file thumbnail was uploaded
        if (isset($_FILES["thumbnailToUpload"]) && $_FILES["thumbnailToUpload"]["size"] > 0) {

            $target_file_thumbnail = $contentPath . "/Temp/" . basename($_FILES["thumbnailToUpload"]["name"]);

            //move thumbnail to temporary folder to validate
            move_uploaded_file($_FILES["thumbnailToUpload"]["tmp_name"], $target_file_thumbnail);

            $filename = $added_creator_id;

            rename($target_file_thumbnail, $contentPath . '/Creators/' . $filename . '.webp');
            $target_file_thumbnail = $contentPath . '/Creators/' . $filename . '.webp';
        }


        $_SESSION['feedback'] = $_POST['input-new-creator'] . ' added as a a new creator!';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_creators");
        exit(0);
        
        

    }






    if (isset($_GET['delete_creator']) && $_GET['delete_creator'] != "") {

        $creator = $creatorSvc->getCreatorById(intval($_GET['delete_creator']));

        $creatorSvc->deleteCreator($creator);

        //delete the thumbnail
        $filename = $creator->getId();

        //delete video in temp folder
        unlink($contentPath . '/Creators/' . $filename . '.webp');

        $_SESSION['feedback'] = 'Creator deleted.';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_creators");
        exit(0);

    }

    require_once('components/Notification.php');
    include ('presentation/ControlPanelCreatorsForm.php');
} else {
    include ('denied.php');
}
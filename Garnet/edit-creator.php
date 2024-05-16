<?php
session_start();
require_once('data/autoloader.php');
require_once('components/DBNameSnippet.php');
require_once('components/authManager.php');

//Only execute code if user is an admin, and $_GET['id'] is set and not empty
if ($user->getRole() == 'admin' && isset($_GET['id']) && ($_GET['id'] !== '')) {

    $creatorSvc = new CreatorService();
    $reportSvc = new ReportService();
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

        //target profile picture file
        $target_file_thumbnail = $contentPath . "/Temp/" . basename($_FILES["thumbnailToUpload"]["name"]);

        //move profile picture to temporary folder to validate
        move_uploaded_file($_FILES["thumbnailToUpload"]["tmp_name"], $target_file_thumbnail);

        //rename profile picture TO THE CREATOR'S ID
        rename($target_file_thumbnail, $contentPath . "/Temp/" . $_POST['creator_ID'] . '.webp');
        $target_file_thumbnail = $contentPath . "/Temp/" . $_POST['creator_ID'] . '.webp';

        //add thumbnail to the correct location - it overwrites the current thumbnail by default
        rename($target_file_thumbnail, $contentPath . '/Creators/' . $_POST['creator_ID'] . '.webp');

        //ADD FEEDBACK TO SESSION STORAGE
        $_SESSION['feedback'] = 'Changes saved.';
        $_SESSION['feedback_color'] = 'green';

        //go to nice page

        header('location: edit-creator?id=' . $creator->getId());
        exit(0);

    }


    require_once('components/Notification.php');
    include ('presentation/CreatorEditorForm.php');

} else {
    echo 'access denied.';
}
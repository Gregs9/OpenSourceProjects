<?php
session_start();
require_once ('data/autoloader.php');
require_once ('components/DBNameSnippet.php');
require_once ('components/authManager.php');




//Only execute code if user is an admin
if ($user->getRole() == 'admin') {

    $tagSvc = new TagService();

    if (isset($_GET['action']) && $_GET['action'] == 'add_tag') {

        if (!isset($_POST['csrf_token']) || $_POST['csrf_token'] !== $_SESSION['csrf_token']) {
            $_SESSION['feedback'] = 'An error has occurred.';
            $_SESSION['feedback_color'] = 'red';
            header("Location: controlpanel_tags");
            exit(0);
        }

        $tag_name = (string) htmlspecialchars($_POST['input-new-tag']);
        $tag_weight = (int) intval(htmlspecialchars($_POST['input-new-tag-weight']));
        $tag_description = (string) htmlspecialchars($_POST['input-new-tag-description']);

        $tagSvc->addPrimaryTag($tag_name, $tag_weight, $tag_description);

        //target thumbnail file
        $target_file_thumbnail = $contentPath . "/Temp/" . basename($_FILES["thumbnailToUpload"]["name"]);

        //move thumbnail to temporary folder to validate
        move_uploaded_file($_FILES["thumbnailToUpload"]["tmp_name"], $target_file_thumbnail);

        $filename = strtolower(preg_replace("/[^a-zA-Z]/", "", $tag_name));

        //rename thumbnail TO THE VIDEO'S MD5 HASH VALUE
        rename($target_file_thumbnail, $contentPath . '/Categories/' . $filename . '.webp');
        $target_file_thumbnail = $contentPath . '/Categories/' . $filename . '.webp';

        $_SESSION['feedback'] = $tag_name . ' added as a primary tag with weight ' . $tag_weight . ' and description "' . $tag_description . '".';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_tags.php");
        exit(0);

    }

    if (isset($_GET['remove_tag']) && $_GET['remove_tag'] != "") {
        $tag = $tagSvc->getTagById(intval($_GET['remove_tag']));

        $tagSvc->removePrimaryTagById($tag);

        //delete the thumbnail
        $filename = strtolower(preg_replace("/[^a-zA-Z]/", "", $tag->getName()));

        //delete video in temp folder
        unlink($contentPath . '/Categories/' . $filename . '.webp');

        $_SESSION['feedback'] = 'Tag deleted.';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_tags.php");
        exit(0);
    }

    require_once('components/Notification.php');
    include ('presentation/ControlPanelTagsForm.php');
} else {
    include ('denied.php');
}
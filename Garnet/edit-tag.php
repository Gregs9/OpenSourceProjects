<?php
session_start();
require_once('data/autoloader.php');
require_once('components/authManager.php');

//Only execute code if user is an admin, and $_GET['id'] is set and not empty
if (($user->getRole() == 'admin') && isset($_GET['id']) && ($_GET['id'] !== '')) {
    include('components/DBNameSnippet.php');
    
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

        //target profile picture file
        $target_file_thumbnail = $contentPath . "/Temp/" . basename($_FILES["thumbnailToUpload"]["name"]);

        //move profile picture to temporary folder to validate
        move_uploaded_file($_FILES["thumbnailToUpload"]["tmp_name"], $target_file_thumbnail);

        $thumbnailFilename = strtolower(preg_replace("/[^a-zA-Z0-9]/", "", $tag->getName()));

        //rename profile picture TO THE CREATOR'S ID
        rename($target_file_thumbnail, $contentPath . "/Temp/" . $thumbnailFilename . '.webp');
        $target_file_thumbnail = $contentPath . "/Temp/" . $thumbnailFilename . '.webp';

        //add thumbnail to the correct location - it overwrites the current thumbnail by default
        rename($target_file_thumbnail, $contentPath . '/Categories/' . $thumbnailFilename . '.webp');
        
        
        //ADD FEEDBACK TO SESSION STORAGE
        $_SESSION['feedback'] = 'Changes saved.';
        $_SESSION['feedback_color'] = 'green';

        //go to nice page
        
        header('location: edit-tag?id=' . $tag->getId());
        exit(0);   
    }


    require_once('components/Notification.php');
    include('presentation/TagEditorForm.php');

} else {
    echo 'access denied.';
}
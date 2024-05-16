<?php
require_once('data/autoloader.php');
require_once('components/DBNameSnippet.php');
require_once('components/authManager.php');

//Only execute code if user is an admin
if ($user->getRole() == 'admin') {
    session_start();
    $videoSvc = new VideoService();
    $userSvc = new UserService();

    //preload all user id's and their username to display as uploaded by, this increase performance from 20000ms -> 10000ms
    $arr_userIdsNamesList = $userSvc->getUserIdNameList();

    require_once('components/Notification.php');
    include('presentation/ControlPanelVideosForm.php');
} else {
    include('denied.php');
}
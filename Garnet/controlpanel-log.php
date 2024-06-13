<?php
session_start();
require_once('data/autoloader.php');
require_once('components/DBNameSnippet.php');
require_once('components/authManager.php');




//Only execute code if user is an admin
if ($user->getRole() == 'admin') {
    
    //Default action filter
    $filter = 'Login|Logged out';

    if (isset($_POST['filter']) && $_POST['filter'] !== '') {
        $filter = $_POST['filter'];
    }

    $logSvc = new LogService();
    $userSvc = new UserService();

    //preload all user id's and their username to display, this increase performance
    $arr_userIdsNamesList = $userSvc->getUserIdNameList();

    include ('presentation/ControlPanelLogForm.php');
} else {
    include ('denied.php');
}
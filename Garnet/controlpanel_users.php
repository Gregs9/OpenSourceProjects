<?php

require_once('data/autoloader.php');
require_once('components/DBNameSnippet.php');
require_once('components/authManager.php');


//Only execute code if user is an admin
if ($user->getRole() == 'admin') {
    session_start();
    $userSvc = new UserService();

    if (isset($_GET['block_id']) && $_GET['block_id'] != "") {
        $user = $userSvc->getUserById((int) $_GET['block_id']);
        $userSvc->blockUser($user);
        //ADD FEEDBACK TO SESSION STORAGE
        $_SESSION['feedback'] = 'User blocked.';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_users.php");
        exit(0);
    }

    if (isset($_GET['activate_id']) && $_GET['activate_id'] != "") {
        $user = $userSvc->getUserById((int) $_GET['activate_id']);
        $userSvc->unblockUser($user);
        //ADD FEEDBACK TO SESSION STORAGE
        $_SESSION['feedback'] = 'User activated.';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_users.php");
        exit(0);
    }

    if (isset($_GET['promote_id']) && $_GET['promote_id'] != "") {
        $user = $userSvc->getUserById((int) $_GET['promote_id']);
        $userSvc->promoteUser($user);
        $_SESSION['feedback'] = 'User promoted.';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_users.php");
        exit(0);
    }

    if (isset($_GET['demote_id']) && $_GET['demote_id'] != "") {
        $user = $userSvc->getUserById((int) $_GET['demote_id']);
        $userSvc->demoteUser($user);
        $_SESSION['feedback'] = 'User demoted.';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_users.php");
        exit(0);
    }

    if (isset($_GET['delete_user']) && $_GET['delete_user'] != "") {
        $userSvc->removeUser($_GET['delete_user']);
        $_SESSION['feedback'] = 'User deleted.';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_users.php");
        exit(0);
    }

    require_once('components/Notification.php');
    include('presentation/ControlPanelUsersForm.php');
} else {
    include('denied.php');
}
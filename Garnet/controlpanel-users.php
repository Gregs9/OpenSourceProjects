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
        $_SESSION['feedback'] = json_encode(['message' => 'User blocked.', 'type' => 'success']);
        header("Location: controlpanel-users.php");
        exit(0);
    }

    if (isset($_GET['activate_id']) && $_GET['activate_id'] != "") {
        $user = $userSvc->getUserById((int) $_GET['activate_id']);
        $userSvc->unblockUser($user);
        //ADD FEEDBACK TO SESSION STORAGE
        $_SESSION['feedback'] = json_encode(['message' => 'User activated.', 'type' => 'success']);
        header("Location: controlpanel-users.php");
        exit(0);
    }

    if (isset($_GET['promote_id']) && $_GET['promote_id'] != "") {
        $user = $userSvc->getUserById((int) $_GET['promote_id']);
        $userSvc->promoteUser($user);
        $_SESSION['feedback'] = json_encode(['message' => 'User promoted.', 'type' => 'success']);
        header("Location: controlpanel-users.php");
        exit(0);
    }

    if (isset($_GET['demote_id']) && $_GET['demote_id'] != "") {
        $user = $userSvc->getUserById((int) $_GET['demote_id']);
        $userSvc->demoteUser($user);
        $_SESSION['feedback'] = json_encode(['message' => 'User demoted.', 'type' => 'success']);
        header("Location: controlpanel-users.php");
        exit(0);
    }

    if (isset($_GET['delete_user']) && $_GET['delete_user'] != "") {
        $userSvc->removeUser($_GET['delete_user']);
        $_SESSION['feedback'] = json_encode(['message' => 'User deleted.', 'type' => 'success']);
        header("Location: controlpanel-users.php");
        exit(0);
    }

    include('presentation/ControlPanelUsersForm.php');
} else {
    include('denied.php');
}
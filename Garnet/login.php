<?php
declare(strict_types=1);
require_once('data/autoloader.php');

session_start();
$userSVC = new UserService;
$logSvc = new LogService;


//ACTIONS
//IF ACTION IS LOGOUT
if (isset($_GET["action"]) && $_GET["action"] === "logout") {
    $logSvc->log(unserialize($_COOKIE['user'], ['User'])->getId(), 'Logged out');
    setcookie('user', '', time() - 3600);
    header('Location: login');
    exit(0);
}

//IF USER IS ALREADY LOGGED IN
if (isset($_COOKIE['user']) && $_COOKIE['user'] !== '') {
    header('Location: home');
    exit(0);
}

//IF ACTION IS LOGIN
if (isset($_GET["action"]) && $_GET["action"] === "login") {
    
    $username = (string) htmlspecialchars(strtolower($_POST['log_username']));
    $password = (string) htmlspecialchars(strtolower($_POST['log_password']));

    if (!preg_match("/^[a-zA-Z0-9]*$/", $username)) {
        $_SESSION['feedback'] = 'Only letters and numbers are allowed in the username.';
        $_SESSION['feedback_color'] = 'red';
        header('Location: login');
        exit(0);
    }

    $user = $userSVC->validateUser($username, $password);


    if ($user !== null) {
        if ($userSVC->checkUserStatus($user)) {
            //generate & set CSRF token 🔒
            $_SESSION['csrf_token'] = bin2hex(random_bytes(32));
            setcookie('user', serialize($user), time() + 28800); //cookie expires after 8 hours
            /*Log the user logging in*/
            $logSvc->log($user->getId(), "Login");  
            header('Location: home');
            exit(0);  
        } else {
            $_SESSION['feedback'] = 'Your account has been suspended.';
            $_SESSION['feedback_color'] = 'red';
            header('Location: login');
            exit(0);
        }
    } else {
        $_SESSION['feedback'] = 'Unable to log in with these crendentials.';
        $_SESSION['feedback_color'] = 'red';
        header('Location: login');
        exit(0);
    }


}


//IF ACTION IS REGISTER
if (isset($_GET["action"]) && $_GET["action"] === "register") {

    $username = (string) htmlspecialchars(strtolower($_POST['reg_username']));
    $password = (string) htmlspecialchars($_POST['reg_password']);
    $password2 = (string) htmlspecialchars($_POST['reg_password2']);

    if ($userSVC->validatePasswordRepetition($password, $password2)) {
        if ($userSVC->validateUsername($username)) {
            $userSVC->addUser($username, password_hash($password, PASSWORD_DEFAULT));
            $_SESSION['feedback'] = 'Account created, you may now log in.';
            $_SESSION['feedback_color'] = 'green';
        } else {
            $_SESSION['feedback'] = 'This username already exists.';
            $_SESSION['feedback_color'] = 'red';
        }
    } else {
        $_SESSION['feedback'] = 'Passwords don\'t match.';
        $_SESSION['feedback_color'] = 'red';
    }
    header('Location: login');
    exit(0);
}


if (!isset($_COOKIE["accept-cookie"]) || $_COOKIE["accept-cookie"] == 'false') {
    include('components/cookie.html');
}

require_once('components/Notification.php');
include('presentation/LoginForm.php');

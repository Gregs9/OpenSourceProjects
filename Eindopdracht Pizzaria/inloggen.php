<?php
declare(strict_types=1);
require_once('data/autoloader.php');
session_start();
$toegelatenPostcodes = ['3600', '3530', '3520', '3500', '3590', '3740', '3550'];
$userSVC = new UserService();

//Redirect naar de juiste pagina als user al ingelogd is
if (isset($_COOKIE['user'])) {
    header('Location: home.php');
}

//Als action register is
if (isset($_GET["action"]) && $_GET["action"] === "register") {

    $familienaam = $_POST['reg_familienaam'];
    $voornaam = $_POST['reg_voornaam'];
    $adres = $_POST['reg_adres'];
    $postcode = $_POST['reg_postcode'];
    $gemeente = $_POST['reg_gemeente'];
    $tel = $_POST['reg_tel'];

    if (!in_array($postcode, $toegelatenPostcodes)) {
        $_SESSION['feedback'] = 'Wij leveren niet aan deze postcode. Onze excuses voor het ongemak.';
        $_SESSION['feedback_color'] = 'red';
        header('Location: inloggen.php');
        exit(0);
    }

    //als de gebruiker zich registreerd
    if ($_POST['reg_email'] !== '' && $_POST['reg_password'] !== '' && $_POST['reg_password2'] !== '') {
        $email = strtolower($_POST['reg_email']);
        $password = $_POST['reg_password'];
        $password2 = $_POST['reg_password2'];

        if ($userSVC->validatePasswordRepetition($password, $password2)) {
            if ($userSVC->validateEmail($email)) {
                $userSVC->addUser($familienaam, $voornaam, $adres, $postcode, $gemeente, $email, password_hash($password, PASSWORD_DEFAULT), $tel);
                $user = $userSVC->getUserByEmail($email);

                setcookie('user', serialize($user));
            } else {
                $_SESSION['feedback'] = 'Dit account bestaat al.';
                $_SESSION['feedback_color'] = 'red';
                header('Location: inloggen.php');
                exit(0);
            }
        } else {
            $_SESSION['feedback'] = 'De gegeven wachtwoorden komen niet overeen.';
            $_SESSION['feedback_color'] = 'red';
            header('Location: inloggen.php');
            exit(0);
        }
    } else {
        $plaatsSvc = new PlaatsService();
        $plaatsId = $plaatsSvc->getPlaatsByPostcode($postcode)->getPlaatsId();
        //als de gebruiker zich niet registreerd, maak een handmatige user met de gegeven info
        $user = new User(0, $familienaam, $voornaam, $adres, '', '', $tel, $plaatsId, 0);
        setcookie('user', serialize($user));
    }
    header('Location: afrekenen.php');
    exit(0);

}

if (isset($_GET["action"]) && $_GET["action"] === "login") {

    $toegelaten = $userSVC->validateUser((string) strtolower($_POST['log_email']), (string) $_POST["log_password"]);

    if ($toegelaten) {
        $user = $userSVC->getUserByEmail($_POST['log_email']);

        setcookie('user', serialize($user));
        header('Location: afrekenen.php');
        exit(0);

    } else {
        $_SESSION['feedback'] = 'We kunnen je niet inloggen met deze gegevens.';
        $_SESSION['feedback_color'] = 'red';
        header('Location: inloggen.php');
        exit(0);

    }
}

include('presentation/InlogForm.php');

if (isset($_SESSION['feedback'])) {
    $feedback = new CustomException($_SESSION['feedback'], $_SESSION['feedback_color']);
    echo $feedback->getFeedback();
    unset($_SESSION['feedback']);
    unset($_SESSION['feedback_color']);
}
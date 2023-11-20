<?php
declare(strict_types=1);
require_once('data/autoloader.php');
session_start();

//Als de user niet ingelogd is, redirect naar de inlogpagina
if (!isset($_COOKIE['user']) || $_COOKIE['user'] == '') {
    header('location: inloggen.php');
    exit(0);
}

//Als de user geen bestelling geselecteerd heeft, redirect naar de inlogpagina
if (!isset($_COOKIE['order']) || count(json_decode($_COOKIE['order'])) < 1) {
    $_SESSION['feedback'] = 'Gelieve eerst een selectie te maken alvorens te afrekenen.';
    $_SESSION['feedback_color'] = 'red';
    header('location: inloggen.php');
    exit(0);
}

//Haal nodige gegevens op
$BestellingSvc = new BestellingService();
$plaatsSvc = new PlaatsService();
$pizzaSvc = new PizzaService();
$user = unserialize($_COOKIE['user'], ['User']);

//Maak een array met stdClass objecten aan met alle gegevens van de bestelling
$Orders = new stdClass();
$Orders = json_decode($_COOKIE['order']);
$totaalBedrag = $BestellingSvc->getPriceOfOrder($Orders, $user->getKortingsTarief());
$teBetalen = $BestellingSvc->getTotalPriceOfOrder($Orders, $user->getKortingsTarief());

//Als de klant hun leveradres wil wijzigen
if (isset($_GET['action']) && $_GET['action'] == 'wijzigAdres') {

    //Lijst van toegelaten postcodes, in de werkelijkheid kunnen deze aangepast worden door een medewerker
    $toegelatenPostcodes = ['3600', '3530', '3520', '3500', '3590', '3740', '3550'];

    //Als de gegeven postcode niet in deze array zit, geef een melding dat dit geen geldige postcode is
    if (!in_array($_POST['wijzig_postcode'], $toegelatenPostcodes)) {
        $_SESSION['feedback'] = 'Wij leveren niet aan deze postcode. Onze excuses voor het ongemak.';
        $_SESSION['feedback_color'] = 'red';
        header('Location: afrekenen.php');
        exit(0);
    } else {
        //Als dit wel een geldige postcode is, overschrijf het huidige user object met deze nieuwe gegevens
        $postcode = $_POST['wijzig_postcode'];
        $plaatsId = $plaatsSvc->getPlaatsByPostcode($postcode)->getPlaatsId();
        $plaatsnaam = $plaatsSvc->getPlaatsByPostcode($postcode)->getNaam();
        $user = new User($user->getId(), $user->getFamilienaam(), $user->getVoornaam(), $_POST['wijzig_adres'], '', '', '', $plaatsId, $user->getKortingsTarief());
        $_SESSION['feedback'] = 'Adres gewijzigd!';
        $_SESSION['feedback_color'] = 'green';
    }
}



if (isset($_GET['action']) && $_GET['action'] == 'bestel') {
    //De data uit het overzicht word opnieuw opgeslagen in een cookie in het geval dat de gebruiker zijn/haar bestelling last minute wijzigt
    $afleveradres = $_COOKIE['name'] . ' ' . $_COOKIE['address'] . ' ' . $_COOKIE['city'];
    $opmerking = $_COOKIE['comment'];

    //Voeg een bestelbon toe aan de database en krijg het ID van de toegevoegde bestelbon terug
    $bestelbonId = $BestellingSvc->addBestelBon($user->getId(), $afleveradres, $opmerking, $teBetalen);

    //Voor elk item in de bestelling, voeg een lijn toe aan de table Bestellijnen, met het juist bestelbonnummer
    foreach ($Orders as $orderLine) {
        $BestellingSvc->addBestelLijn($bestelbonId, intval($orderLine->id), intval($orderLine->aantal));
    }

    //Verwijder de cookies door ze in te laten verlopen in het verleden
    setcookie("name", "", time() - 3600);
    setcookie("address", "", time() - 3600);
    setcookie("city", "", time() - 3600);
    setcookie("comment", "", time() - 3600);
    setcookie("order", "", time() - 3600);

    //Redirect de user naar de 'bestelling' geplaatst pagina
    header('location: bestellingGeplaatst.php');
    exit(0);
}

include('presentation/AfrekenenForm.php');

//Toon user eventuele feedback indien nodig
if (isset($_SESSION['feedback'])) {
    $feedback = new CustomException($_SESSION['feedback'], $_SESSION['feedback_color']);
    echo $feedback->getFeedback();
    unset($_SESSION['feedback']);
    unset($_SESSION['feedback_color']);
}

<?php
declare(strict_types=1);
require_once("business/PersoonService.php");
require_once("business/ModuleService.php");
require_once("business/ScoreService.php");

$persoonSvc = new PersoonService();
$personenLijst = $persoonSvc->getPersonen();

$moduleSvc = new ModuleService();
$moduleLijst = $moduleSvc->getModules();

$scoreSvc = new ScoreService();
$scoreLijst = $scoreSvc->getScores();

if (!isset($_GET['id']) || $_GET['id'] == '') {
    header('Location: overzicht.php');
    exit(0);
}

if ((isset($_GET['id']) && $_GET['id'] !== '') && (isset($_GET['action']) && $_GET['action'] == 'opslaan')) {
    for ($i = 1; $i <= 11; $i++) {
        if (isset($_POST[$i]) && $_POST[$i] !== '') {
            $scoreSvc->addScore((int) $i, (int) $_GET['id'], (int) $_POST[$i]);
        }
    }
    header("location: overzicht.php");
    exit(0);
}



include('presentation/PuntenIngevenForm.php');

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

include("presentation/OverzichtForm.php");
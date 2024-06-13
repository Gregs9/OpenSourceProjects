<?php
declare(strict_types=1);
session_start();
require_once('components/DBNameSnippet.php');
require_once('data/autoloader.php');
require_once('components/authManager.php');

if ($_GET['creator'] == 0 || $_GET['creator'] == 423 || $_GET['creator'] == 424) {
    header('Location: 404');
    exit(0);
}

$creatorSvc = new CreatorService;
$userSvc = new UserService;

$creator = $creatorSvc->getCreatorById(intval($_GET['creator']));

if ($creator) {
    $top_creator_categories = $creatorSvc->getCreatorsFavoriteCategory($creator);
    include('presentation/CreatorForm.php');
} else {
    header('Location: 404');
    exit(0);
}





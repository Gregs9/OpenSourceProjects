<?php
declare(strict_types=1);
session_start();
require_once ('data/autoloader.php');
require_once ('components/DBNameSnippet.php');
require_once ('components/authManager.php');

$tagSvc = new TagService();
$videoSvc = new VideoService();
$creatorSvc = new CreatorService();
$videoPerformanceDAO = new VideoPerformanceDAO();



if (isset($_GET['action']) && $_GET['action'] == 'random') {
    header('Location: video?id=' . $videoSvc->getRandomVideoId());
    exit(0);
}


/*Check if current date is the birthday of a creator*/
$arr_creators_with_birthday = $creatorSvc->getBirthday(date('Y-m-d'));

$recommendedVideos = $videoSvc->getRecommendedVideos($user->getId());

require_once ('components/Notification.php');
include ('presentation/HomeForm.php');
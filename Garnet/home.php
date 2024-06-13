<?php
declare(strict_types=1);
session_start();
require_once ('data/autoloader.php');
require_once ('components/DBNameSnippet.php');
require_once ('components/authManager.php');

$tagSvc = new TagService;
$videoSvc = new VideoService;
$creatorSvc = new CreatorService;



if (isset($_GET['action']) && $_GET['action'] == 'random') {
    header('Location: video?id=' . $videoSvc->getRandomVideoId());
    exit(0);
}


/*Check if current date is the birthday of a creator*/
$arr_creators_with_birthday = $creatorSvc->getBirthday(date('Y-m-d'));
/*Get recommended videos*/
$recommendedVideos = $videoSvc->getRecommendedVideos($user->getId());


include ('presentation/HomeForm.php');
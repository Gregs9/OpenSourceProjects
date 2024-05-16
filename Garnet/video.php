<?php
declare(strict_types=1);
session_start();
require_once('data/autoloader.php');
require_once('components/DBNameSnippet.php');
require_once('components/authManager.php');

$videoSvc = new VideoService();
$userSvc = new UserService();
$reportSvc = new ReportService();
$tagSvc = new TagService();
$creatorSvc = new CreatorService();
$logSvc = new LogService();

//for placing a report
if (isset($_GET['report_id']) && $_GET['report_id'] !== '') {
    $reportSvc->createReport(intval($_GET['report_id']), $_POST['report_reason'], $_POST['report_description']);
    $logSvc->log($user->getId(), 'Report', intval($_GET['report_id']));
    //Tell user that their report has been sent
    $_SESSION['feedback'] = 'Your report has been received and will be reviewed as soon as we are able to.';
    $_SESSION['feedback_color'] = 'green';
}

//redirect if video id isn't set
if (!isset($_GET['id']) || $_GET['id'] == '') {
    header('Location: home');
    exit(0); 
}




$playing_video = $videoSvc->getVideoById(intval($_GET['id']));

if (!$playing_video) {
    //ADD FEEDBACK TO SESSION STORAGE           
    header('location: 404');
    exit(0);
}


//Show how long ago the video was posted
$postedHowLongAgo = $videoSvc->getPostedTimeAgo($playing_video->getDateAdded());
$postedByWho = ucfirst($userSvc->getUserById($playing_video->getUploadedBy())->getUsername());
$recommendedVideos = $videoSvc->getSimilarVideos($playing_video);


//add 1 to amount of views when a video is correctly loaded
$videoSvc->addView($playing_video);
$logSvc->log($user->getId(), 'View', $playing_video->getId());



$src = $contentPath . '/Videos/' . $playing_video->getFilename() . $playing_video->getExtension();


include('presentation/VideoForm.php');
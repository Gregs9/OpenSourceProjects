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

//default filters
$results_per_page = 25;
$total_records = 0;
$order_by = 'date_added desc';
$excludeShorts = 'false';

/*Get page number*/
if (isset($_GET["page"])) {
    $page = intval($_GET["page"]);
} else {
    $page = 1;
}


// If the user just set their filters, save their filters to sessions
if (isset($_GET['action']) && $_GET['action'] == 'filter') {

    if (isset($_POST['input-selected-tags']) && $_POST['input-selected-tags'] !== '') {
        $_SESSION['request-tags'] = $_POST['input-selected-tags'];
    } else {
        unset($_SESSION['request-tags']);
    }

    if (isset($_POST['search']) && $_POST['search'] !== '') {
        $_SESSION['search'] = htmlspecialchars($_POST['search']);
    } else {
        unset($_SESSION['search']);
    }

    if (isset($_POST['order-by']) && $_POST['order-by'] !== '') {
        $_SESSION['order-by'] = $_POST['order-by'];
    } else {
        unset($_SESSION['order-by']);
    }

    // if exclude-shorts is set in post, it must be true
    if (isset($_POST['exclude-shorts'])) {
        $_SESSION['exclude-shorts'] = 'true';
    } else {
        unset($_SESSION['exclude-shorts']);
    }
}

$arr_requested_tags = [];
$search_filter = '';

if (isset($_SESSION['request-tags']) && ($_SESSION['request-tags'] !== '')) {
    $arr_tag_strings = explode(';', $_SESSION['request-tags']);
    foreach ($arr_tag_strings as $tag_name) {
        $tag_obj = $tagSvc->getTagByName($tag_name);
        array_push($arr_requested_tags, $tag_obj);
    }
}

if (isset($_SESSION['search']) && ($_SESSION['search'] !== '')) {
    $search_filter = htmlspecialchars($_SESSION['search']);
}

if (isset($_SESSION['order-by']) && ($_SESSION['order-by'] !== '')) {
    $order_by = $_SESSION['order-by'];
}

if (isset($_SESSION['exclude-shorts']) && ($_SESSION['exclude-shorts'] == 'true')) {
    $excludeShorts = 'true';
}

$video_list = $videoPerformanceDAO->getAllVideosPerPageWithFilter($page, $results_per_page, $arr_requested_tags, $search_filter, $order_by, $excludeShorts);
$total_records = $videoPerformanceDAO->getTotalRecordsPerPageWithFilter($arr_requested_tags, $search_filter, $excludeShorts);

$total_pages = ceil($total_records / $results_per_page);
$recommendedVideos = $videoSvc->getRecommendedVideos(intval(unserialize($_COOKIE['user'], ['User'])->getId()));

require_once ('components/Notification.php');
include ('presentation/HomeForm.php');
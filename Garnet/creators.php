<?php
declare(strict_types=1);
session_start();
require_once('data/autoloader.php');
require_once('components/DBNameSnippet.php');
require_once('components/authManager.php');

$creatorSvc = new CreatorService();
$creatorPerformanceDAO = new CreatorPerformanceDAO();

$results_per_page = 25;
$total_records = 0;
$order_by = 'occurrences desc';

/*Get page number*/
if (isset($_GET["page"])) {
    $page = intval($_GET["page"]);
} else {
    $page = 1;
}

//If post value is set (user request a new order-by), set the new session variable
if (isset($_POST['creator-order-by'])) {
    $_SESSION['creator-order-by'] = $_POST['creator-order-by'];
}

//if the session variable is set, and not empty, use it's value instead
if (isset($_SESSION['creator-order-by']) && ($_SESSION['creator-order-by'] !== '')) {
    $order_by = $_SESSION['creator-order-by'];
}

if (isset($_POST['search-creator'])) {
    $_SESSION['search-creator'] = htmlspecialchars($_POST['search-creator']);
}

$query = '';

if (isset($_SESSION['search-creator'])) {
    $query = htmlspecialchars($_SESSION['search-creator']);
}
if (isset($_POST['search-creator'])) {
    $query = htmlspecialchars($_POST['search-creator']);
}

//Get total records and calculate total pages required
$total_records = $creatorPerformanceDAO->getTotalRecords($query);
$creator_list = $creatorPerformanceDAO->getAllCreatorsPerPage($page, $results_per_page, $order_by, $query);
$total_pages = ceil($total_records / $results_per_page);




include ('presentation/CreatorsForm.php');

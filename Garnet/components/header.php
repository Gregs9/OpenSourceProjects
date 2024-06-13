<?php
require_once ('data/autoloader.php');
$currentFile = $_SERVER["PHP_SELF"];
$part_filenames = explode('/', $currentFile);
$currentPage = end($part_filenames);
$reportSvc = new ReportService;
?>

<!DOCTYPE HTML>
<html>

<head>
  <link rel="stylesheet" href="css/components/header.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
  <script src="scripts/UI.js" defer></script>
  <link rel="stylesheet" href="css/components/thumbnail.css">
</head>


<header class="menu">
  <a href="login" title="Back to home."><img src="assets/logo.png" id="logo" alt="logo"></a>
  <nav>
    <a id="home" class="<?= ($currentPage === 'home') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="home">Home</a>
    <a id="shorts" class="<?= ($currentPage === 'shorts') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="shorts">Shorts</a>
    <a id="categories" class="<?= ($currentPage === 'categories') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="categories">Categories</a>
    <a id="creators" class="<?= ($currentPage === 'creators') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="creators">Creators</a>
    <a id="upload" class="<?= ($currentPage === 'upload') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="upload">Upload</a>
    <a id="profile"
      class="<?= ($currentPage === 'profile_favorite_creators') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="#">Profile</a>
    <a id="logout" class="linkHeader" href="login?action=logout">Log out</a>
    <?php
    if (unserialize($_COOKIE['user'], ['User'])->getRole() == 'admin') { ?>
      <a id="control_panel"
        class="<?= ($currentPage === 'controlpanel-videos' || $currentPage === 'controlpanel-creators' || $currentPage === 'controlpanel-users' || $currentPage === 'controlpanel-tags.php' || $currentPage === 'controlpanel-reports.php') ? 'linkHeader activePage' : 'linkHeader'; ?>">
        <img id="controlpanelicon" src="assets/control_panel_icon.png" alt="control_panel">
      </a>
    <?php } ?>
  </nav>

</header>
<div id="control_panel_options" style="display: none;">
  <nav id="control_panel_menu">
    <a id="controlpanel-videos"
      class="<?= ($currentPage === 'controlpanel-videos') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="controlpanel-videos">Videos</a>
    <a id="controlpanel-creators"
      class="<?= ($currentPage === 'controlpanel-creators') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="controlpanel-creators">Creators</a>
    <a id="controlpanel-users"
      class="<?= ($currentPage === 'controlpanel-users') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="controlpanel-users">Users</a>
    <a id="controlpanel-tags"
      class="<?= ($currentPage === 'controlpanel-tags') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="controlpanel-tags">Tags</a>

    <a id="controlpanel-reports"
      class="<?= ($currentPage === 'controlpanel-reports') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="controlpanel-reports">
      Reports
      <?php if (count($reportSvc->getPendingReports()) > 0) { ?>
        <div id="notification-container">
          <img id="notification-icon" src="assets/notification.png">
          <span id="pending-amount"><?= count($reportSvc->getPendingReports()) ?></span>
        </div>
      <?php } ?>
    </a>

    <a id="controlpanel_log"
      class="<?= ($currentPage === 'controlpanel-log') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="controlpanel-log">Log</a>
  </nav>

</div>

<div id="profile_panel_options" style="display: none;">
  <nav id="profile_panel_menu">
    <a id="latest-scores" class="<?= ($currentPage === 'latest-scores') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="latest-scores">Latest Scores</a>
    <a id="history" class="<?= ($currentPage === 'history') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="history">Watch History</a>
    <a id="favorite-videos"
      class="<?= ($currentPage === 'favorite-videos') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="favorite-videos">Favorite Videos</a>
    <a id="favorite-creators"
      class="<?= ($currentPage === 'favorite-creators') ? 'linkHeader activePage' : 'linkHeader'; ?>"
      href="favorite-creators">Favorite Creators</a>
  </nav>
</div>
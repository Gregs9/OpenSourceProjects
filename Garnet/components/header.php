<?php
require_once('data/autoloader.php');
$currentFile = $_SERVER["PHP_SELF"];
$part_filenames = explode('/', $currentFile);
$currentPage = end($part_filenames);
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
    <a id="home" class="<?php echo ($currentPage === 'home') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="home">Home</a>
    <a id="shorts" class="<?php echo ($currentPage === 'shorts') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="shorts">Shorts</a>
    <a id="categories" class="<?php echo ($currentPage === 'categories') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="categories">Categories</a>
    <a id="creators" class="<?php echo ($currentPage === 'creators') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="creators">Creators</a>
    <a id="upload" class="<?php echo ($currentPage === 'upload') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="upload">Upload</a>
    <a id="profile" class="<?php echo ($currentPage === 'profile_favorite_creators') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="#">Profile</a>
    <a id="logout" class="linkHeader" href="login?action=logout">Log out</a>
    <?php
    if (unserialize($_COOKIE['user'], ['User'])->getRole() == 'admin') { ?>
      <a id="control_panel" class="<?php echo ($currentPage === 'controlPanel_videos' || $currentPage === 'controlPanel_creators' || $currentPage === 'controlPanel_users' || $currentPage === 'controlPanel_tags.php' || $currentPage === 'controlPanel_reports.php') ? 'linkHeader activePage' : 'linkHeader'; ?>">
      <img id="controlpanelicon" src="assets/control_panel_icon.png" alt="control_panel">
      </a>
    <?php } ?>
  </nav>
  
</header>
<div id="control_panel_options" style="display: none;">
  <nav id="control_panel_menu">
    <a id="controlpanel_videos" class="<?php echo ($currentPage === 'controlPanel_videos') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="controlpanel_videos">Videos</a>
    <a id="controlpanel_creators" class="<?php echo ($currentPage === 'controlPanel_creators') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="controlpanel_creators">Creators</a>
    <a id="controlpanel_users" class="<?php echo ($currentPage === 'controlPanel_users') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="controlpanel_users">Users</a>
    <a id="controlpanel_tags" class="<?php echo ($currentPage === 'controlPanel_tags') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="controlpanel_tags">Tags</a>
    <a id="controlpanel_reports" class="<?php echo ($currentPage === 'controlPanel_reports') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="controlpanel_reports">Reports</a>
    <a id="controlpanel_log" class="<?php echo ($currentPage === 'controlPanel_log') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="controlpanel_log">Log</a>
  </nav>
</div>

<div id="profile_panel_options" style="display: none;">
  <nav id="profile_panel_menu">
    <a id="latest-scores" class="<?php echo ($currentPage === 'latest-scores') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="latest-scores">Latest Scores</a>
    <a id="history" class="<?php echo ($currentPage === 'history') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="history">Watch History</a>
    <a id="favorite-videos" class="<?php echo ($currentPage === 'favorite-videos') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="favorite-videos">Favorite Videos</a>
    <a id="favorite-creators" class="<?php echo ($currentPage === 'favorite-creators') ? 'linkHeader activePage' : 'linkHeader'; ?>" href="favorite-creators">Favorite Creators</a>
  </nav>
</div>
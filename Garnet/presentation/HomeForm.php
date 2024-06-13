<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
  <link rel="stylesheet" href="css/GLOBAL.css">
  <link rel="stylesheet" href="css/pages/home.css">
  <link rel="stylesheet" href="css/components/thumbnail.css">
  <title>The Garnet: Home</title>
  <link rel="icon" href="assets/logo.ico" type="image/x-icon">
  <meta name="theme-color" content="#800000">

  <script src="scripts/home_filter.js" defer></script>

</head>

<body>

  <?php include ('components/header.php'); ?>

  <!--FOR DISPLAYING BIRTHDAYS-->
  <?php count($arr_creators_with_birthday) > 0 ? include ('components/birthday.php') : null; ?>

  <!--START WRAPPER-->
  <div class="wrapper">

    <h1 class="title">Tags</h1>


    <header class='tag-list'>
      <?php foreach ($tagSvc->getAllTags() as $tag) { ?>
        <a class="regular-link" title="<?= $tag->getDescription() ?>">+<?= $tag->getName() ?></a>
      <?php } ?>
    </header>

    <a href="home?action=random" id="random-video" class="button button--centered" title="Go to a random video.">Feeling
      lucky?</a>

    <h1 class="title">Filters</h1>

    <div class="filters">
      <label for="selected-tags">Selected tags</label>
      <!--Selected tags populated by scripts/home_filter.js-->
      <div id="selected-tags" name="selected-tags" title="Here are the tags you have selected."></div>

      <!--Hidden input element to mirror requested tags-->
      <input type=text id="input-selected-tags" name="input-selected-tags" readonly hidden required>

      <!--Searchbar for searching options-->
      <label for="search-container">Search</label>
      <div id="search-container" name="search-container">
        <input id="search" class="input-element" name="search" type="search" placeholder="Search.."
          title="Enter what you wish to search for." maxlength="100">
      </div>

      <label for="select-container">Order by</label>
      <!--Select for sorting options-->
      <div id="select-container" name="select-container">
        <select id="order-by" name="order-by">
          <option selected value="date_added desc">Newest first</option>
          <option value="date_added asc">Oldest first</option>
          <option value="views desc">Most views first</option>
          <option value="views asc">Least views first</option>
          <option value="score desc">Highest score first</option>
          <option value="score asc">Least score first</option>
        </select>
      </div>

      <label title="Exclude videos shorter than 30 seconds which have a vertical aspect ratio.">Exclude shorts</label>
      <input id="exclude-shorts" name="exclude-shorts" type="checkbox">
    </div>



    <!--amount of results populated by scripts/home_filter.js-->
    <h1 class="title" id="total-results"></h1>

    <!--video list populated by scripts/home_filter.js-->
    <main class="video-list">
    </main>

    <!--pagination populated by scripts/home_filter.js-->
    <div class="pagination">
    </div>


    <?php include ('components/recommendedVideosOnHomePage.php') ?>

  </div>
  <!--END WRAPPER-->
  <?php require_once ('components/Notification.php'); ?>
  <?php include ('components/footer.php'); ?>

</body>

</html>
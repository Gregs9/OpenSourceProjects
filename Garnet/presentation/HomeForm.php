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
  <script src="scripts/home_TagSelector.js" defer></script>
  <script src="scripts/home_Filter.js" defer></script>
</head>

<body>

  <?php include ('components/header.php'); ?>

  <!--FOR DISPLAYING BIRTHDAYS-->
  <?php count($arr_creators_with_birthday) > 0 ? include ('components/birthday.php') : null; ?>

  <!--START WRAPPER-->
  <div class="wrapper">


    <?php echo $feedback->getMessage(); ?>

    <h1 class="title">Tags</h1>


    <header id='tag-list'>
      <?php foreach ($tagSvc->getAllTags() as $tag) { ?>
        <a class="regular-link" title="<?php echo $tag->getDescription() ?>">+<?php echo $tag->getName() ?></a>
      <?php } ?>
    </header>

    <a href="home?action=random" id="random-video" class="button" title="Go to a random video.">Feeling lucky?</a>

    <h1 class="title">Filters</h1>


    <div id="search-by-tags">
      <label>Selected tags</label>

      <!--Selected tags populated with JS-->
      <div id="selected-tags" name="Here are the tags you have selected."></div>

      <!--Hidden input element to mirror requested tags in string format-->
      <input type=text id="input-selected-tags" name="input-selected-tags" readonly hidden>


      <!--Searchbar for searching options-->
      <label>Search</label>
      <div id="search-container">
        <input id="search" name="search" type="search" value="" placeholder="Search.." title="Enter what you wish to search for." maxlength="100">
      </div>

      <label>Order by</label>
      <!--Select for sorting options-->
      <div id="select-container">
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


      <!--Submit button-->
      <div id="submit-button-container">
        <input type=submit value="Go" id="filter" class="button">
      </div>

      <!--END FILTERS-->
    </div>



    <!--Amount of results populated by JS-->
    <h1 class="title" id="total-results"></h1>

    <!--Videos populated by JS-->
    <main class="video-list"></main>

    <!--Pagination populated by JS-->
    <div id="page_numbers"></div>


    <?php include ('components/recommendedVideosOnHomePage.php') ?>

  </div>
  <!--END WRAPPER-->

  <?php include ('components/footer.php'); ?>

</body>

</html>
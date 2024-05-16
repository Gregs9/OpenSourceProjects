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

    <!--Populated with JS-->
    <form id="search-by-tags" method="post" action="home.php?action=filter">
      <label>Selected tags</label>
      <div id="selected-tags" name="Here are the tags you have selected.">
        <?php
        if (isset($_SESSION['request-tags']) && $_SESSION['request-tags'] !== '') {
          $arr_ret_tags = explode(';', $_SESSION['request-tags']);
          foreach ($arr_ret_tags as $ret_tag) {
            echo '<a class="tag">' . $ret_tag . '</a>';
          }
        }
        ?>
      </div>
      <!--Hidden input element to mirror requested tags-->
      <input type=text id="input-selected-tags" name="input-selected-tags" readonly hidden required>


      <!--Searchbar for searching options-->
      <label>Search</label>
      <div id="search-container">
        <input id="search" name="search" type="search" value="<?php if (isset($_SESSION['search'])) {
          echo $_SESSION['search'];
        } ?>" placeholder="Search.." title="Enter what you wish to search for." maxlength="100">
      </div>

      <label>Order by</label>
      <!--Select for sorting options-->
      <div id="select-container">
        <select id="order-by" name="order-by">
          <option <?php echo $order_by == "date_added desc" ? 'selected' : '' ?> value="date_added desc">Newest first
          </option>
          <option <?php echo $order_by == "date_added asc" ? 'selected' : '' ?> value="date_added asc">Oldest first
          </option>
          <option <?php echo $order_by == "views desc" ? 'selected' : '' ?> value="views desc">Most views first</option>
          <option <?php echo $order_by == "views asc" ? 'selected' : '' ?> value="views asc">Least views first</option>
          <option <?php echo $order_by == "score desc" ? 'selected' : '' ?> value="score desc">Highest score first
          </option>
          <option <?php echo $order_by == "score asc" ? 'selected' : '' ?> value="score asc">Least score first</option>
        </select>
      </div>

      <label title="Exclude videos shorter than 30 seconds which have a vertical aspect ratio.">Exclude shorts</label>
      <input id="exclude-shorts" name="exclude-shorts" type="checkbox" <?php echo $excludeShorts == 'true' ? 'checked' : null; ?>>


      <!--Submit button-->
      <div id="submit-button-container">
        <input type=submit value="Go" id="get_requested_tags" class="button">
      </div>
    </form>




    <h1 class="title">
      <?php echo $total_records ?> Results
    </h1>
    <main class="video-list">
      <?php
      foreach ($video_list as $video) {
        include ('components/thumbnail.php');
      } ?>
    </main>

    <div id="page_numbers">
      <?php
      echo $page > 1 ? '<a href="home?page=' . ($page - 1) . '"> < </a>' : null;
      for ($i = 1; $i <= $total_pages; $i++) {
        echo '<a ' . ($i == $page ? 'class="active-page" ' : '') . 'href="home?page=' . $i . '">' . $i . '</a>';
      }
      echo $page < $total_pages ? '<a href="home?page=' . ($page + 1) . '"> > </a>' : null;
      ?>
    </div>


    <?php include ('components/recommendedVideosOnHomePage.php') ?>

  </div>
  <!--END WRAPPER-->

  <?php include ('components/footer.php'); ?>

</body>

</html>
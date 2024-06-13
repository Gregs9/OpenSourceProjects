<!DOCTYPE HTML>
<html>

<head>
  <title>The Garnet: Shorts</title>
  <link rel="icon" href="assets/logo.ico" type="image/x-icon">
  <meta name="theme-color" content="#800000">
  <meta charset="UTF-8">
  <link rel="stylesheet" href="css/GLOBAL.css">
  <link rel="stylesheet" href="css/pages/shorts.css">
  <script src="scripts/Shorts.js" defer></script>
  <script src="scripts/FavoriteVideo.js" defer></script>
  <script src="scripts/video_addScore.js" defer></script>

</head>

<body>
  <?php include ('components/header.php'); ?>

  <!--START WRAPPER-->
  <div class="wrapper">


    <!--Video element-->
    <div id="short-container">
      <video controls autoplay muted loop id="short">
        <source type="video/mp4" src="">
      </video>

      <!--Tutorial icon-->
      <div class="tutorial-image" id="tutorial">
        <img class="box bounce-2" src="assets/shorts_tutorial.png" title="Click to hide tutorial" alt="">
      </div>
        
      <!--Video info here-->
      <div id="video-info">

        <img id="score" class="glow" src="assets/cntrl_Score.png" title="Click to add a score to this video."
          data-userid="<?= $user->getId(); ?>">

        <img id="favorite" class="glow" src="assets/favorite.png" title="Click to favorite this video.">


        <div>
          <img id="star-icon" src="assets/star.png" alt="" title="The score of this video">
          <p id="video-score"></p>
        </div>

        <div>
          <img id="views-icon" src="assets/views.png" alt="" title="The amount of views this video has">
          <p id="video-views"></p>
        </div>

        <div id="creators-container">
        </div>

      </div>

    </div>





  </div>
  <?php require_once ('components/Notification.php'); ?>
  <?php include ('components/footer.php'); ?>
</body>
<!DOCTYPE HTML>
<html>

<head>
  <title>The Garnet: <?php echo $playing_video->getTitle() ?></title>
  <link rel="icon" href="assets/logo.ico" type="image/x-icon">
  <meta name="theme-color" content="#800000">
  <meta charset="UTF-8">
  <link rel="stylesheet" href="css/GLOBAL.css">
  <link rel="stylesheet" href="css/pages/video.css">
  <link rel="stylesheet" href="css/components/thumbnail.css">
  <script src="scripts/video_AddOrRemoveTag.js" defer></script>
  <script src="scripts/video_addScore.js" defer></script>
  <script src="scripts/FavoriteVideo.js" defer></script>
  <script src="scripts/video_fitToScreen.js" defer></script>
</head>

<body>
  <?php include ('components/header.php'); ?>

  <!--START WRAPPER-->
  <div class="wrapper">





    <!--Container for entire left side of page-->
    <div id="video-content">
      <h1 id='video-title' class="title">
        <?php echo nl2br(htmlspecialchars($playing_video->getTitle())) ?>
      </h1>


      <!--Video element-->
      <div id="video-container">
        <video controls autoplay muted loop id="video">
          <source type="video/mp4" src="<?php echo $src ?>">
        </video>
      </div>


      <!--Video info here-->
      <div id="video-info">

        <img id="score" class="glow" src="assets/cntrl_Score.png" title="Click to add a score to this video."
          data-videoid="<?php echo $playing_video->getId(); ?>" data-userid="<?php echo $user->getId(); ?>">

        <img id="favorite"
          class="<?php echo $userSvc->isVideoFavorited($user, $playing_video) ? 'glow favorited' : 'glow'; ?>"
          src="<?php echo $userSvc->isVideoFavorited($user, $playing_video) ? 'assets/unfavorite.png' : 'assets/favorite.png' ?>"
          title="Click to favorite this video." data-videoid="<?php echo $playing_video->getId(); ?>"
          data-userid="<?php echo $user->getId(); ?>">


        <div>
          <img id="star-icon" src="assets/star.png" alt="" title="The amount of scores this video has">
          <p id="video-score">
            <?php echo $playing_video->getScore(); ?>
          </p>
        </div>

        <div>
          <img id="views-icon" src="assets/views.png" alt="" title="The amount of views this video has">
          <p id="video-views">
            <?php echo $playing_video->getViews(); ?>
          </p>
        </div>

        <p id="posted" title="Posted on <?php echo $playing_video->getDateAdded()->format('j M o') ?>">
          <?php echo 'Uploaded ' . $postedHowLongAgo . ' by ' . $postedByWho ?>
        </p>

        <?php if (unserialize($_COOKIE['user'], ['User'])->getRole() == 'admin') { ?>
          <a id="edit-video-link" class="regular-link" href="edit-video?id=<?php echo $playing_video->getId() ?>">Edit
            video</a>
          </li>
        <?php } ?>

        <img id="report-video-icon" class="collapsible glow" src="assets/flag.png" title="Click to report this video">
      </div>





      <!--FOR REPORTING VIDEOS-->
      <form action="video.php?report_id=<?php echo $playing_video->getId(); ?>" method="post" id="report-video-form"
        class="report-container" style="display:none;">
        <select id="report_reason" name="report_reason" required>
          <option value="">Select reason</option>
          <option value="Copyright infringement">Copyright infringement</option>
          <option value="Duplicate content">Duplicate content</option>
          <option value="Hate speech">Hate speech</option>
          <option value="Misleading or fraudulent">Misleading metadata</option>
          <option value="Privacy infringement">Privacy concerns</option>
        </select>
        <input type="text" id="report_description" name="report_description"
          placeholder="Describe the problem with this video.." minlength="5" maxlength="255" required>
        <input class="button" type="submit" value="Submit">
      </form>


      <!--FOR DISPLAYING VIDEO DESCRIPTION-->
      <?php if ($playing_video->getDescription() !== '') { ?>
        <p id="video-description">
          <?php echo $playing_video->getDescription(); ?>
        </p>
      <?php } ?>


      <!--FOR DISPLAYING CREATORS-->
      <div id="video-creators">
        <?php foreach ($creatorSvc->getCreatorsByVideoId($playing_video->getId()) as $creator) { ?>
          <div class="creator-container">
            <a <?php echo !in_array($creator->getId(), [0, 423, 424]) ? 'href="creator?creator=' . $creator->getId() . '"' : null; ?>>
              <img class="creator-thumbnail" src="<?php echo $creator->getProfilePic(); ?>">
              <p class="creator-name">
                <?php echo $creator->getName(); ?>
              </p>
            </a>
          </div>
        <?php } ?>
      </div>


      <!--Video tags here-->
      <div id="video-tags">

        <?php
        //Display all video tags
        foreach ($playing_video->getTags() as $tag) {
          echo '<a class="tag" href="home?tag=' . $tag->getName() . '">' . $tag->getName() . '</a>';
        }

        ?>
      </div>
      <div id="tag-editor">
        <?php
        //Display an extra tag to allow the user to add one
        echo '<div id="container-add-tag-label"><a class="regular-link" data-userid="' . $user->getId() . '" data-videoid="' . $playing_video->getId() . '" class="tag-link" id="add-tag">+Add Tag</a></div>';

        //Display an extra tag to allow the user to remove one
        echo '<div id="container-remove-tag-label"><a class="regular-link" data-userid="' . $user->getId() . '" data-videoid="' . $playing_video->getId() . '" class="tag-link" id="remove-tag">-Remove Tag</a></div>';
        ?>
      </div>
    </div>
    <!--END VIDEO-CONTENT-->



    <aside id="recommended-container">
    <h1 id="morelikethis" class="title sticky" style="">More like this</h1>
      <div id="recommended">

        <?php foreach ($videoSvc->getSimilarVideos($playing_video) as $video) {

          include ('components/thumbnail.php');
        } ?>
      </div>
    </aside>


  </div>
  <!--END WRAPPER-->

  <?php include ('components/footer.php'); ?>

</body>

</html>
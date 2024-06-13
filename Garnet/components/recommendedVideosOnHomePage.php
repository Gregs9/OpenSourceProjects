<head>
  <link rel="stylesheet" href="css/components/recommendedVideos.css">
</head>

<?php if ($recommendedVideos !== null) { ?>
  <h1 class="title">Recommended for you</h1>
  <main class="video-list-recommended">
    <?php
    foreach ($recommendedVideos as $video) {
      include ('components/thumbnail.php');
    } ?>
  </main>

<?php } ?>
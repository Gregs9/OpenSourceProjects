<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/profile-favorite-videos.css">
    <title>The Garnet: Favorite Videos</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
    <script src="scripts/FavoriteVideo.js" defer></script>
    <script src="scripts/searchFavoritedVideos.js" defer></script>
</head>

<body>

    <?php include ('components/header.php'); ?>

    <!--START WRAPPER-->
    <div class="wrapper">
        <?php echo $feedback->getMessage(); ?>

        <!--Title-->
        <h1 class="title">Favorited Videos</h1>
        <div class="search-container">
            <label for="search-favorited-videos">Search</label>
            <input id="search-favorited-videos" name="search-favorited-videos" title="search for creators"
                placeholder="Search.." type="search">
        </div>


        <?php if (count($favorite_videos) > 0) { ?>
            <div class="video-list">
                <?php foreach ($favorite_videos as $video) { ?>
                    <?php include ('components/thumbnail.php'); ?>
                <?php } ?>
            </div>

        <?php } else { ?>
            <div class="info-container">
                <h1 class="title no-indent">No favorited videos yet!</h1>
                <p>Make sure to favorite the videos you really like and they will appear here.</p>
            </div>
        <?php } ?>

    </div>

</body>

<?php include ('components/footer.php'); ?>
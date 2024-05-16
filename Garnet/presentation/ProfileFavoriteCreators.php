<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/profile-favorite-creators.css">
    <title>The Garnet: Favorite Creators</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
    <script src="scripts/FavoriteCreator.js" defer></script>
    <script src="scripts/searchFavoritedCreators.js" defer></script>
</head>

<body>

    <?php include ('components/header.php'); ?>

    <!--START WRAPPER-->
    <div class="wrapper">
        <?php echo $feedback->getMessage(); ?>

        <!--Title-->
        <h1 class="title">Favorited Creators</h1>
        <div class="search-container">
            <label for="search-favorited-creators">Search</label>
            <input id="search-favorited-creators" name="search-favorited-creators" title="search for creators"
                placeholder="Search.." type="search">
        </div>

        <?php if (count($favorite_creators) > 0) { ?>
            <?php foreach ($favorite_creators as $creator) { ?>

                <div class="creator-box">

                    <!--creator profile pic-->
                    <a class="image-link" href="<?php echo "creator?creator=" . $creator->getId(); ?>">
                        <img class="profile-pic" src="<?php echo $creator->getProfilePic() ?>">
                    </a>


                    <!--creator name & aliases-->
                    <div class="creator-names">
                        <h1 class="creator-name"><?php echo $creator->getName() ?></h1>
                        <p class="creator-alias"><strong>
                                <?php echo $creator->getAlias() ? 'aka ' . $creator->getAlias() : null; ?>
                            </strong></p>
                    </div>

                    <!--FAVORITE BUTTON-->
                    <div data-userid="<?php echo $user->getId() ?>" data-creatorid="<?php echo $creator->getId() ?>"
                        class="HeartAnimation <?php echo $userSvc->isCreatorFavorited($user, $creator) ? 'favorited' : null; ?>"
                        title="<?php echo $userSvc->isCreatorFavorited($user, $creator) ? 'Click to unfavorite this creator.' : 'Click to favorite this creator.'; ?>">
                    </div>

                    <!--creator latetest videos-->
                    <h1 class="title">Latest Videos</h1>

                    <main class="latest-video-list">
                        <?php foreach ($creatorSvc->getLatestVideosByCreator($creator) as $video) {
                            include ('components/thumbnail.php');
                        } ?>
                    </main>

                </div>



            <?php } ?>
        <?php } else { ?>
            <div class="info-container">
                <h1 class="title no-indent">No favorited creators yet!</h1>
                <p>Make sure to favorite the creators you like and they will appear here.</p>
            </div>
        <?php } ?>

    </div>

</body>

<?php include ('components/footer.php'); ?>
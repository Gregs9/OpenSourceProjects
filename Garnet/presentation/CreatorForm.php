<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>



<head>
    <title>The Garnet: Creator</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
    <meta charset="UTF-8">
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/creator.css">
    <script src="scripts/FavoriteCreator.js" defer></script>
    <script src="scripts/fetchCreatorStats.js" defer></script>
</head>

<body>

    <?php include ('components/header.php'); ?>

    <div class="wrapper">

        <!--The creator's bio-->
        <main class="creator-bio">

            <!--Check admin priviliges, and display an edit option if so-->
            <?php if (unserialize($_COOKIE['user'], ['User'])->getRole() == 'admin') { ?>
                <a id="edit-creator-link" class="regular-link" href="edit-creator?id=<?php echo $creator->getId() ?>">
                    Edit creator</a></li>
            <?php } ?>


            <div id="profile-container">
                <!--The creator's profile pic-->
                <img id="creator-img" src="<?php echo $creator->getProfilePic() ?>">

                <!--The creator's socials-->
                <div id="socials">
                    <?php if ($creator->getSocialIn() !== '') { ?>
                        <a class="alt" href="<?php echo $creator->getSocialIn(); ?>"><img class="socials-link-img"
                                src="assets/i.png" alt="instagram link"></a>
                    <?php } ?>

                    <?php if ($creator->getSocialX() !== '') { ?>
                        <a class="alt" href="<?php echo $creator->getSocialX(); ?>"><img class="socials-link-img"
                                src="assets/x.png" alt="x link"></a>
                    <?php } ?>
                </div>

                <!--The creator's statistics, populated with JS fetch-->
                <div id="statistics">
                    <h2>Statistics</h2>
                    <br>
                    <img id="loading" src="assets/loading.gif">
                </div>
                <br>

                <?php if ($creator->getDateOfBirth()) { ?>
                    <p class="creator-dateOfBirth">
                        <?php echo ' (' . $creator->getAge() . ' years old)' ?>
                    </p>
                <?php } ?>
                <br>

                <img id="flag" title="<?php echo $creator->getNationality() ?>"
                    src="<?php echo $creator->getFlag(); ?>">

            </div>


            <!--The creator's about-->
            <div id="about">
                <h1 id="creator-name">
                    <?php echo $creator->getName(); ?>
                </h1>
                <p id="creator-alias"><strong>
                        <?php echo $creator->getAlias() ? 'aka ' . $creator->getAlias() : null; ?>
                    </strong></p>
                <p id="creator-description">
                    <?php echo nl2br(htmlspecialchars($creator->getDescription())); ?>
                </p>
            </div>

            <!--FAVORITE BUTTON-->
            <div data-userid="<?php echo $user->getId() ?>" data-creatorid="<?php echo $creator->getId() ?>"
                class="HeartAnimation<?php echo $userSvc->isCreatorFavorited($user, $creator) ? ' favorited' : null; ?>"
                title="<?php echo $userSvc->isCreatorFavorited($user, $creator) ? 'Click to unfavorite this creator.' : 'Click to favorite this creator.'; ?>">
            </div>

        </main>


        <!--The creator's top categories-->
        <h1 class="title">Top categories</h1>
        <div class="top-categories">
            <?php foreach ($top_creator_categories as $tag) { ?>
                <a class="tag" href="home.php?tag=<?php echo $tag->getName(); ?>">
                    <?php echo $tag->getName(); ?>
                </a>
            <?php } ?>
        </div>


        <h1 class="title">
            <?php echo $creator->getName(); ?>'s Videos
        </h1>
        <main class="video-list">
            <?php foreach ($creatorSvc->getAllVideosByCreator($creator) as $video) {
                include ('components/thumbnail.php');
            } ?>
        </main>
    </div>


    <?php include ('components/footer.php'); ?>

</body>

</html>
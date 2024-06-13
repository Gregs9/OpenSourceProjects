<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/categories.css">
    <title>The Garnet: Categories</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
</head>

<body>

    <?php include ('components/header.php'); ?>

    <div class="wrapper">
        <h1 class="title">Recommended categories</h1>
        <div id="recommended-categories">

            <?php foreach ($recommended_tags as $tag) { ?>
                <div class="category-info">

                    <h1><?= ucwords($tag->getName()) ?></h1>
                    <p>
                        <?= $arr_tag_occurences[$tag->getId()] ?? 0; ?> videos
                    </p>
                    <?= ($tagSvc->isNew($tag)) ? '<img class="new" src="assets/new.png" alt="new">' : null ?>

                    <a href="home?tag=<?= urlencode($tag->getName()) ?> ">
                        <img class="thumbnail" loading="lazy" src="<?= $tag->getThumbnail() ?>"
                            title="<?= $tag->getDescription() ?>">
                    </a>

                </div>
            <?php } ?>
        </div>

        <h1 class="title">Popular categories</h1>
        <div id="popular-categories">
            <?php
            foreach ($popular_tags as $tag) { ?>

                <div class="category-info">

                    <h1>
                        <?= $tag->getName() ?>
                    </h1>
                    <p>
                        <?= $arr_tag_occurences[$tag->getId()] ?? 0; ?> videos
                    </p>
                    <?= ($tagSvc->isNew($tag)) ? '<img class="new" src="assets/new.png" alt="new">' : null ?>

                    <a href="home?tag=<?= urlencode($tag->getName()) ?> ">
                        <img class="thumbnail" loading="lazy" src="<?= $tag->getThumbnail() ?>"
                            title="<?= $tag->getDescription() ?>">
                    </a>

                </div>
            <?php } ?>
        </div>

        <h1 class="title">All categories</h1>
        <div id="all-categories">

            <?php
            foreach ($all_tags as $tag) { ?>

                <div class="category-info">

                    <h1><?= $tag->getName() ?></h1>
                    <p><?= $arr_tag_occurences[$tag->getId()] ?? 0; ?> videos</p>

                    <?= ($tagSvc->isNew($tag)) ? '<img class="new" src="assets/new.png" alt="new">' : null ?>

                    <a href="home?tag=<?= urlencode($tag->getName()) ?> ">
                        <img class="thumbnail" loading="lazy" src="<?= $tag->getThumbnail() ?>"
                            title="<?= $tag->getDescription() ?>">
                    </a>

                </div>
            <?php } ?>
        </div>
    </div>
    <?php require_once ('components/Notification.php'); ?>
    <?php include ('components/footer.php'); ?>
</body>

</html>
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

                    <h1>
                        <?php echo $tag->getName() ?>
                    </h1>
                    <p>
                        <?php
                        if (array_key_exists($tag->getId(), $arr_tag_occurences)) {
                            echo $arr_tag_occurences[$tag->getId()] > 0 ? $arr_tag_occurences[$tag->getId()] : 0;
                        } else {
                            echo 0;
                        }
                        ?>
                        videos
                    </p>
                    <?php echo ($tagSvc->isNew($tag)) ? '<img class="new" src="assets/new.png" alt="new">' : null ?>

                    <a href="home?tag=<?php echo urlencode($tag->getName()) ?> ">
                        <img class="thumbnail" loading="lazy" src="<?php echo $tag->getThumbnail() ?>"
                            title="<?php echo $tag->getDescription() ?>">
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
                        <?php echo $tag->getName() ?>
                    </h1>
                    <p>
                        <?php
                        if (array_key_exists($tag->getId(), $arr_tag_occurences)) {
                            echo $arr_tag_occurences[$tag->getId()] > 0 ? $arr_tag_occurences[$tag->getId()] : 0;
                        } else {
                            echo 0;
                        }
                        ?>
                        videos
                    </p>
                    <?php echo ($tagSvc->isNew($tag)) ? '<img class="new" src="assets/new.png" alt="new">' : null ?>

                    <a href="home?tag=<?php echo urlencode($tag->getName()) ?> ">
                        <img class="thumbnail" loading="lazy" src="<?php echo $tag->getThumbnail() ?>"
                            title="<?php echo $tag->getDescription() ?>">
                    </a>

                </div>
            <?php } ?>
        </div>

        <h1 class="title">All categories</h1>
        <div id="all-categories">

            <?php
            foreach ($all_tags as $tag) { ?>

                <div class="category-info">

                    <h1>
                        <?php echo ucfirst($tag->getName()) ?>
                    </h1>
                    <p>
                        <?php
                        if (array_key_exists($tag->getId(), $arr_tag_occurences)) {
                            echo $arr_tag_occurences[$tag->getId()] > 0 ? $arr_tag_occurences[$tag->getId()] : 0;
                        } else {
                            echo 0;
                        }
                        ?>
                        videos
                    </p>
                    <?php echo ($tagSvc->isNew($tag)) ? '<img class="new" src="assets/new.png" alt="new">' : null ?>

                    <a href="home?tag=<?php echo urlencode($tag->getName()) ?> ">
                        <img class="thumbnail" loading="lazy" src="<?php echo $tag->getThumbnail() ?>"
                            title="<?php echo $tag->getDescription() ?>">
                    </a>

                </div>
            <?php } ?>
        </div>
    </div>

    <?php include ('components/footer.php'); ?>
</body>

</html>
<head>
    
</head>

<?php if ($video->getAspectRatio() < 1) { ?>
    <a class="thumbnail-container-extension" data-id="<?= $video->getId(); ?>"
        href="video?id=<?= $video->getId(); ?>">
        <img loading="lazy" class="thumbnail-extension" src="<?= $video->getThumbnail(); ?>">
        <img loading="lazy" class="thumbnail-extension" src="<?= $video->getThumbnail(); ?>">
        <img loading="lazy" class="thumbnail-extension" src="<?= $video->getThumbnail(); ?>">

    <?php } else { ?>

        <a class="thumbnail-container" data-id="<?= $video->getId(); ?>"
            href="video?id=<?= $video->getId(); ?>">
            <img loading="lazy" class="thumbnail" src="<?= $video->getThumbnail(); ?>">


        <?php } ?>



        <span class="duration-on-thumbnail">
            <?= $video->getDurationFormatted(); ?>
        </span>

        <!--I'm still on the fence about wether or not I wanne add video titles to the thumbnails-->
        <!--<p class="thumbnail-title"><?php #echo $video->getTitle() ?></p>-->

    </a>

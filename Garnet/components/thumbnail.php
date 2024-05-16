<head>
    
</head>

<?php if ($video->getAspectRatio() < 1) { ?>
    <a class="thumbnail-container-extension" data-id="<?php echo $video->getId(); ?>"
        href="video?id=<?php echo $video->getId(); ?>">
        <img loading="lazy" class="thumbnail-extension" src="<?php echo $video->getThumbnail(); ?>">
        <img loading="lazy" class="thumbnail-extension" src="<?php echo $video->getThumbnail(); ?>">
        <img loading="lazy" class="thumbnail-extension" src="<?php echo $video->getThumbnail(); ?>">

    <?php } else { ?>

        <a class="thumbnail-container" data-id="<?php echo $video->getId(); ?>"
            href="video?id=<?php echo $video->getId(); ?>">
            <img loading="lazy" class="thumbnail" src="<?php echo $video->getThumbnail(); ?>">


        <?php } ?>



        <span class="duration-on-thumbnail">
            <?php echo $video->getDurationFormatted(); ?>
        </span>

        <!--I'm still on the fence about wether or not I wanne add video titles to the thumbnails-->
        <!--<p class="thumbnail-title"><?php #echo $video->getTitle() ?></p>-->

    </a>

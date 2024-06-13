<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/edit-video.css">
    <title>The Garnet: Control panel</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
    <script src="scripts/changeThumbnails.js" defer></script>
    <script src="scripts/warnings.js" defer></script>
</head>

<body>
    <?php include ('components/header.php'); ?>
    <div class="wrapper">

        <h1 class="title">Editing video with id
            <strong>
                <?= $video->getId(); ?>
            </strong>
        </h1>

        <form action="edit-video.php?id=<?= $video->getId(); ?>&action=editvideo" method="post"
            enctype="multipart/form-data">

            <!--Video preview-->
            <label>Video preview </label>
            <video controls id="video-preview" alt="preview">
                <source id="sourcePrev" controls type="video/mp4"
                    src="<?= $contentPath . '/Videos/' . $video->getFilename() . $video->getExtension() ?>">
            </video>


            <!--Thumbnail preview-->
            <label>Thumbnail preview</label>
            <img id="thumbnail-preview" alt="preview" src="<?= $video->getThumbnail() ?>">

            <!--Change thumbnail-->
            <label for="thumbnailToUpload">Change thumbnail</label>
            <input class="input-element" title="Change this video's thumbnail." type="file" name="thumbnailToUpload" id="thumbnailToUpload"
                accept=".webp, .png, .jpg, .jpeg">



            <!--Video ID-->
            <label for="video_ID">Video ID</label>
            <input class="input-element" readonly title="This video's ID." type="number" name="video_ID" id="video_ID"
                value="<?= $video->getId() ?>">



            <!--Filename-->
            <label for="filename">Filename</label>
            <input class="input-element" readonly title="This video's filename." type="text" name="filename" id="filename" maxlength="32"
                value="<?= $video->getFilename() ?>">
            <img id="copy-to-clipboard" class="button" src="assets/clipboard.png">


            <!--Extension-->
            <label for="extension">Extension</label>
            <input class="input-element" title="This video's file extension." type="text" name="extension" id="extension" maxlength="5"
                required readonly value="<?= $video->getExtension() ?>">



            <!--Title-->
            <label for="title">Title</label>
            <input class="input-element" title="Change this video's title." maxlength="255" type="text" name="title" id="title"
                placeholder="Enter the video's title.." value="<?= $video->getTitle() ?>">



            <!--Description-->
            <label for="description">Description</label>
            <textarea class="input-element" placeholder="Enter the video's description.." title="Change this video's description."
                maxlength="1000" type="text" name="description"
                id="description"><?= $video->getDescription() ?></textarea>





            <!--Duration-->
            <label for="duration">Duration (hh:mm:ss)</label>
            <input class="input-element" readonly required title="This video's duration." type="text" name="duration" id="duration"
                maxlength="8" pattern="[0-9][0-9]:[0-9][0-9]:[0-9][0-9]" required
                value="<?= $video->getDuration() ?>">



            <!--Filesize-->
            <label for="filesize">Filesize (kB)</label>
            <input class="input-element" readonly title="This video's filesize." required type="number" name="filesize" id="filesize" required
                maxlength="8" value="<?= $video->getFileSize() ?>">


            <!--Score-->
            <label for="score">Score</label>
            <input class="input-element" title="Change this video's score." min="0" type="number" name="score" id="score" required
                maxlength="11" value="<?= $video->getScore() ?>">



            <!--Views-->
            <label for="views">Views</label>
            <input class="input-element" title="Change this video's amount of views." min="0" type="number" name="views" id="views" required
                maxlength="11" value="<?= $video->getViews() ?>">


            <!--Date Added-->
            <label for="date_added">Date added</label>
            <input class="input-element" title="Change this video's date added." type="datetime-local" name="date_added" id="date_added"
                required value="<?= $video->getDateAdded()->format('Y-m-d H:i:s') ?>">

            <!--Uploaded by-->
            <label for="uploaded_by">Uploaded by</label>
            <input class="input-element" title="The ID of the user who uploaded this video." readonly min="1" type="number" name="uploaded_by"
                id="uploaded_by" required value="<?= $video->getUploadedBy() ?>">
            <input class="input-element" title="The name of the user who uploaded this video." readonly type="text"
                name="uploaded_by_username" id="uploaded_by_username" required
                value="<?= $userSvc->getUserById($video->getUploadedBy())->getUsername() ?>">

            <!--Tags-->
            <!--hide this element since it servers no real purpose other than using it as a post value-->
            <input class="input-element" title="This video's tagline." readonly type="text" name="tags" id="tags" required minlength="3"
                maxlength="500" value="<?= $video->getTagsAsString() ?>" hidden>

            <?php include ('components/tagBuilder.php') ?>


            <!--hide this element since it servers no real purpose other than using it as a post value-->
            <input class="input-element" title="This video's creators." type="text" name="hidden-creators-field" id="hidden-creators-field" required
                onkeypress="return false;" minlength="3" maxlength="500"
                value="<?= $videoSvc->getVideoCreatorsAsString($video->getId()) ?>" hidden>

            <?php include ('components/creatorBuilder.php') ?>

            <div id="actions">
                <input title="Save changes made to this video." class="button" type="submit" value="Save changes">

                <a title="Click to delete this video." id="delete-video-link" class="regular-link"
                    data-videoId="<?= $video->getId(); ?>">Delete video</a>

                <a title="Click to go to this video." class="regular-link"
                    href="video?id=<?= $video->getId() ?>">Go to video</a>

                <a title="Return to control panel." class="regular-link" href="controlpanel-videos">Close</a>
            </div>


            <!--END FORM HERE-->
        </form>

        <!--END WRAPPER HERE-->
    </div>


    <?php require_once ('components/Notification.php'); ?>
    <?php include ('components/footer.php'); ?>
</body>


</html>
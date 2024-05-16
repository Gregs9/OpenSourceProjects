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
                <?php echo $video->getId(); ?>
            </strong>
        </h1>

        <?php echo $feedback->getMessage(); ?>

        <form action="edit-video.php?id=<?php echo $video->getId(); ?>&action=editvideo" method="post"
            enctype="multipart/form-data">

            <!--Video preview-->
            <label>Video preview </label>
            <video controls id="video-preview" alt="preview">
                <source id="sourcePrev" controls type="video/mp4"
                    src="<?php echo $contentPath . '/Videos/' . $video->getFilename() . $video->getExtension() ?>">
            </video>


            <!--Thumbnail preview-->
            <label>Thumbnail preview</label>
            <img id="thumbnail-preview" alt="preview" src="<?php echo $video->getThumbnail() ?>">

            <!--Change thumbnail-->
            <label for="thumbnailToUpload">Change thumbnail</label>
            <input title="Change this video's thumbnail." type="file" name="thumbnailToUpload" id="thumbnailToUpload"
                accept=".webp">



            <!--Video ID-->
            <label for="video_ID">Video ID</label>
            <input readonly title="This video's ID." type="number" name="video_ID" id="video_ID"
                value="<?php echo $video->getId() ?>">



            <!--Filename-->
            <label for="filename">Filename</label>
            <input readonly title="This video's filename." type="text" name="filename" id="filename" maxlength="32"
                value="<?php echo $video->getFilename() ?>">
            <img id="copy-to-clipboard" class="button" src="assets/clipboard.png">


            <!--Extension-->
            <label for="extension">Extension</label>
            <input title="This video's file extension." type="text" name="extension" id="extension" maxlength="5"
                required readonly value="<?php echo $video->getExtension() ?>">



            <!--Title-->
            <label for="title">Title</label>
            <input title="Change this video's title." maxlength="255" type="text" name="title" id="title"
                placeholder="Enter the video's title.." value="<?php echo $video->getTitle() ?>">



            <!--Description-->
            <label for="description">Description</label>
            <textarea placeholder="Enter the video's description.." title="Change this video's description."
                maxlength="1000" type="text" name="description"
                id="description"><?php echo $video->getDescription() ?></textarea>





            <!--Duration-->
            <label for="duration">Duration (hh:mm:ss)</label>
            <input readonly required title="This video's duration." type="text" name="duration" id="duration"
                maxlength="8" pattern="[0-9][0-9]:[0-9][0-9]:[0-9][0-9]" required
                value="<?php echo $video->getDuration() ?>">



            <!--Filesize-->
            <label for="filesize">Filesize (kB)</label>
            <input readonly title="This video's filesize." required type="number" name="filesize" id="filesize" required
                maxlength="8" value="<?php echo $video->getFileSize() ?>">


            <!--Score-->
            <label for="score">Score</label>
            <input title="Change this video's score." min="0" type="number" name="score" id="score" required
                maxlength="11" value="<?php echo $video->getScore() ?>">



            <!--Views-->
            <label for="views">Views</label>
            <input title="Change this video's amount of views." min="0" type="number" name="views" id="views" required
                maxlength="11" value="<?php echo $video->getViews() ?>">


            <!--Date Added-->
            <label for="date_added">Date added</label>
            <input title="Change this video's date added." type="datetime-local" name="date_added" id="date_added"
                required value="<?php echo $video->getDateAdded()->format('Y-m-d H:i:s') ?>">

            <!--Uploaded by-->
            <label for="uploaded_by">Uploaded by</label>
            <input title="The ID of the user who uploaded this video." readonly min="1" type="number" name="uploaded_by"
                id="uploaded_by" required value="<?php echo $video->getUploadedBy() ?>">
            <input title="The name of the user who uploaded this video." readonly type="text"
                name="uploaded_by_username" id="uploaded_by_username" required
                value="<?php echo $userSvc->getUserById($video->getUploadedBy())->getUsername() ?>">

            <!--Tags-->
            <!--hide this element since it servers no real purpose other than using it as a post value-->
            <input title="This video's tagline." readonly type="text" name="tags" id="tags" required minlength="3"
                maxlength="500" value="<?php echo $video->getTagsAsString() ?>" hidden>

            <?php include('components/tagBuilder.php')?>


            <!--hide this element since it servers no real purpose other than using it as a post value-->
            <input title="This video's creators." type="text" name="creators-line" id="creators-line" hidden required
                onkeypress="return false;" minlength="3" maxlength="500"
                value="<?php echo $videoSvc->getVideoCreatorsAsString($video->getId()) ?>" >

                <?php include ('components/creatorBuilder.php') ?>

            <div id="actions">
                <input title="Save changes made to this video." class="button" type="submit" value="Save changes">

                <a title="Click to delete this video." id="delete-video-link" class="regular-link"
                    data-videoId="<?php echo $video->getId(); ?>">Delete video</a>

                <a title="Click to go to this video." class="regular-link"
                    href="video?id=<?php echo $video->getId() ?>">Go to video</a>

                <a title="Return to control panel." class="regular-link" href="controlpanel_videos">Close</a>
            </div>


            <!--END FORM HERE-->
        </form>

        <!--END WRAPPER HERE-->
    </div>



    <?php include ('components/footer.php'); ?>
</body>


</html>
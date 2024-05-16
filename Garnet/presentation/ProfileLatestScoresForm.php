<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/profile-latest-scores.css">
    <title>The Garnet: Latest scores</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
</head>

<body>

    <?php include ('components/header.php'); ?>

    <!--START WRAPPER-->
    <div class="wrapper">
        <?php echo $feedback->getMessage(); ?>

        <!--Title-->
        <h1 class="title">Latest Scores</h1>

        <main class="video-list">
            <?php foreach ($video_list as $video) {
                include ('components/thumbnail.php');
            } ?>
        </main>


    </div>

</body>

<?php include ('components/footer.php'); ?>
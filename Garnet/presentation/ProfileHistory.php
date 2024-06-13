<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/profile-watch-history.css">
    <title>The Garnet: Watch History</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
</head>

<body>

    <?php include ('components/header.php'); ?>

    <!--START WRAPPER-->
    <div class="wrapper">

        <!--Title-->
        <h1 class="title">Watch history</h1>

            <?php
            $today = new DateTime('today');
            $yesterday = (new DateTime('yesterday'))->format('Y-m-d');
            $lastWeek = (new DateTime('-1 week'))->format('Y-m-d');
            $lastMonth = (new DateTime('-1 month'))->format('Y-m-d');

            $videoGroups = [
                'Today' => [],
                'Yesterday' => [],
                'Last Week' => [],
                'Last Month' => [],
                'Earlier' => []
            ];

            foreach ($video_list as $item) {
                $video = $item['video']; // This retrieves the Video object
                $timestamp = $item['date']; // This retrieves the associated timestamp
            
                if ($timestamp === $today->format('Y-m-d')) {
                    $videoGroups['Today'][] = $video;
                } elseif ($timestamp === $yesterday) {
                    $videoGroups['Yesterday'][] = $video;
                } elseif ($timestamp > $lastWeek && $timestamp <= $yesterday) {
                    $videoGroups['Last Week'][] = $video;
                } elseif ($timestamp > $lastMonth && $timestamp <= $lastWeek) {
                    $videoGroups['Last Month'][] = $video;
                } else {
                    $videoGroups['Earlier'][] = $video;
                }
            }

            // Now display the grouped videos
            foreach ($videoGroups as $group => $videos) {
                if (!empty($videos)) {
                    echo "<h1 class='title'>{$group}</h1><div class='video-list'>";
                    foreach ($videos as $video) {
                        // Assuming you have a way to display each video, like an include statement
                        include ('components/thumbnail.php');
                    }
                    echo '</div>'; // Close the group div
                }
            }
            ?>

    </div>

</body>
<?php require_once ('components/Notification.php'); ?>
<?php include ('components/footer.php'); ?>
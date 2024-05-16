<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/control-panel.css">
    <title>The Garnet: Control panel</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
    <script src="scripts/controlPanel_Searches.js" defer></script>
</head>

<body>

    <?php include ('components/header.php'); ?>


    <div class="wrapper">

        <?php echo $feedback->getMessage(); ?>



        <!--VIDEOS TABLE-->
        <h1 class="title">Videos</h1>
        <div id="container-table-videos" class="table-container">
            <div class="searchbar">
                <input class="search" id="search-videos" type="search" placeholder="Search.."
                    title="Enter what you wish to search for.">
            </div>
            <table id="table-videos">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Date added</th>
                        <th>Score</th>
                        <th>Views</th>
                        <th>Duration</th>
                        <th>Uploaded by</th>
                    </tr>
                </thead>
                <tbody>
                    <?php

                    foreach ($videoSvc->getAllVideos() as $video) {

                        #Cut title & description short if it exceeds 60 characters
                        if ($video->getTitle()) {
                            strlen($video->getTitle()) > 60 ? $video_title_formatted = substr($video->getTitle(), 0, 60) . '...' : $video_title_formatted = $video->getTitle();
                        } else {
                            $video_title_formatted = '';
                        }

                        if ($video->getDescription()) {
                            strlen($video->getDescription()) > 60 ? $video_description_formatted = substr($video->getDescription(), 0, 60) . '...' : $video_description_formatted = $video->getDescription();
                        } else {
                            $video_description_formatted = '';
                        }
                        
                       

                        echo
                            '
                    <tr>
                        <td><a class="regular-link" title="Click to edit this video." href="edit-video?id=' . $video->getId() . '">' . $video->getId() . '</a></td>
                        <td>' . $video_title_formatted . '</td>
                        <td>' . $video_description_formatted . '</td>
                        <td>' . $video->getDateAdded()->format('Y-m-d H:i:s') . '</td>
                        <td>' . $video->getScore() . '</td>
                        <td>' . $video->getViews() . '</td>
                        <td>' . $video->getDuration() . '</td>
                        <td>' . $arr_userIdsNamesList[$video->getUploadedBy()] . '</td>
                    </tr>';
                    }

                    ?>
                </tbody>
            </table>
        </div>


    </div>
    <!--END WRAPPER-->

    <?php include ('components/footer.php'); ?>

</body>

</html>
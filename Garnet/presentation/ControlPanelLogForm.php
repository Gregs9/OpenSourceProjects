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

    <?php include('components/header.php'); ?>


    <div class="wrapper">

        <!--REPORTS TABLE-->
        <h1 class="title">User Activity Log</h1>

        <form id="filters" method="post" action="controlpanel-log.php">
            <label for="filters">Activity</label>
            <select id="filter" name="filter">
                <option <?= $filter == "Login|Logged out" ? 'selected' : '' ?> value="Login|Logged out">Login
                    activity</option>
                <option <?= $filter == "View" ? 'selected' : '' ?> value="View"> View activity</option>
                <option <?= $filter == "Failed uploading video|Uploaded video" ? 'selected' : '' ?>
                    value="Failed uploading video|Uploaded video">Upload activity</option>
                <option <?= $filter == "Added tag|Removed tag" ? 'selected' : '' ?> value="Added tag|Removed tag">
                    Tag editing activity</option>
            </select>

            <input class="button" type="submit" value="Go">
        </form>



        <?php if (count($logSvc->getAllPerAction($filter)) > 0) { ?>
            <div id="container-log-info" class="table-container">
                <?php include 'components/searchTable.php' ?>
                <table id="table-log-info">
                    <tr>
                        <th>ID</th>
                        <th>Username</th>
                        <th>Action</th>
                        <th>Timestamp</th>
                        <th>Video ID</th>
                    </tr>
                    <?php foreach ($logSvc->getAllPerAction($filter) as $log) { ?>
                        <tr>
                            <td>
                                <?= $log->getId() ?>
                            </td>
                            <td>
                                <?= $arr_userIdsNamesList[$log->getUserId()] ?>
                            </td>
                            <td>
                                <?= $log->getAction() ?>
                            </td>
                            <td>
                                <?= $log->getTimestamp() ?>
                            </td>
                            <?php if ($log->getVideoId() !== 0) { ?>
                                <td><a class="regular-link" href="video.php?id= <?= $log->getVideoId() ?>">
                                        <?= $log->getVideoId() ?>
                                    </a></td>
                            <?php } else { ?>
                                <td></td>
                            <?php } ?>

                        </tr>
                    <?php } ?>
                </table>
            </div>

        <?php } else { ?>
            <img id="no_results" alt="no results" src="assets/no_results.png">
        <?php } ?>


    </div>
    <!--END WRAPPER-->
    <?php require_once ('components/Notification.php'); ?>
    <?php include('components/footer.php'); ?>

</body>

</html>
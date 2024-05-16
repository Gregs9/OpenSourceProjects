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

        <?php echo $feedback->getMessage() ?>

        <!--REPORTS TABLE-->
        <h1 class="title">User Activity Log</h1>

        <form id="filters" method="post" action="controlpanel_log.php">
            <label for="filters">Activity</label>
            <select id="filter" name="filter">
                <option <?php echo $filter == "Login|Logged out" ? 'selected' : '' ?> value="Login|Logged out">Login
                    activity</option>
                <option <?php echo $filter == "View" ? 'selected' : '' ?> value="View"> View activity</option>
                <option <?php echo $filter == "Failed uploading video|Uploaded video" ? 'selected' : '' ?>
                    value="Failed uploading video|Uploaded video">Upload activity</option>
                <option <?php echo $filter == "Added tag|Removed tag" ? 'selected' : '' ?> value="Added tag|Removed tag">
                    Tag editing activity</option>
            </select>

            <input class="button" type="submit" value="Go">
        </form>



        <?php if (count($logSvc->getAllPerAction($filter)) > 0) { ?>
            <div id="container-log-info" class="table-container">
                <div id="search-log-container">
                    <input type="search" id="search-log" name="search-log" placeholder="Search..">
                </div>
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
                                <?php echo $log->getId() ?>
                            </td>
                            <td>
                                <?php echo $arr_userIdsNamesList[$log->getUserId()] ?>
                            </td>
                            <td>
                                <?php echo $log->getAction() ?>
                            </td>
                            <td>
                                <?php echo $log->getTimestamp() ?>
                            </td>
                            <?php if ($log->getVideoId() !== 0) { ?>
                                <td><a class="regular-link" href="video.php?id= <?php echo $log->getVideoId() ?>">
                                        <?php echo $log->getVideoId() ?>
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

    <?php include('components/footer.php'); ?>

</body>

</html>
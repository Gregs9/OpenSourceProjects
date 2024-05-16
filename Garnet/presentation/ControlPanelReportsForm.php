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
</head>

<body>

    <?php include('components/header.php'); ?>


    <div class="wrapper">

        <?php echo $feedback->getMessage(); ?>

        <!--REPORTS TABLE-->
        <h1 class="title">Reports</h1>

        <?php if (count($reportSvc->getReports()) > 0) { ?>
        <div id="container-report-info" class="table-container">
            <table id="table-report-info">
                <tr>
                    <th>ID</th>
                    <th>Video ID</th>
                    <th>Reason</th>
                    <th>Comment</th>
                    <th>Creation</th>
                    <th>Status</th>
                </tr>
                <?php

                foreach ($reportSvc->getReports() as $report) {
                    echo
                        '
                    <tr>
                        <td>' . $report->getReportId() . '</td>
                        <td> <a title="Edit this video in the video editor." class="regular-link" href="edit-video.php?id=' . $report->getVideoId() . '">' . $report->getVideoId() . '</a></td>
                        <td>' . $report->getReason() . '</td>
                        <td>' . $report->getDescription() . '</td>
                        <td>' . $report->getCreation()->format('Y-m-d H:i:s') . '</td>
                        <td>' . $reportSvc->getReportStatusAction($report) . '</td>
                    </tr>';
                }


                ?>
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
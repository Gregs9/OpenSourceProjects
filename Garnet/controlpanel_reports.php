<?php
session_start();
require_once('data/autoloader.php');
require_once('components/DBNameSnippet.php');
require_once('components/authManager.php');




//Only execute code if user is an admin
if ($user->getRole() == 'admin') {
    
    $reportSvc = new ReportService();

    if (isset($_GET['update_report_id']) && $_GET['update_report_id'] != "") {
        $reportSvc->updateReport($_GET['update_report_id']);
        $_SESSION['feedback'] = 'Report marked as handled.';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_reports.php");
        exit(0);
    }
    
    if (isset($_GET['delete_report_id']) && $_GET['delete_report_id'] != "") {
        $reportSvc->deleteReport($_GET['delete_report_id']);
        $_SESSION['feedback'] = 'Report deleted.';
        $_SESSION['feedback_color'] = 'green';
        header("Location: controlpanel_reports.php");
        exit(0);
    }

    require_once('components/Notification.php');
    include('presentation/ControlPanelReportsForm.php');
} else {
    include('denied.php');
}
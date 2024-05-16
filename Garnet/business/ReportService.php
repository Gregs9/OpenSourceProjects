<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class ReportService
{
    public function createReport(int $video_id, string $reason, string $description)
    {
        $reportDAO = new ReportDAO();
        $reportDAO->addReport($video_id, $reason, $description);
    }

    public function deleteReport(int $report_id)
    {
        $reportDAO = new ReportDAO();
        $reportDAO->deleteReport($report_id	);
    }

    public function getReports(): array
    {
        $reportDAO = new ReportDAO();
        return $reportDAO->getReports();
    }

    public function getReportStatusAction(Report $report): string
    {
        $string_status = 'pending';

        if ($report->getStatus() == 'pending') {
            $string_status = 'pending <a title="Click to set status to handled." class="regular-link" href="controlpanel_reports?update_report_id=' . $report->getReportId() . '">(Update)</a>';
        } elseif ($report->getStatus() == 'handled') {
            $string_status = 'handled  <a title="Click to remove report." class="regular-link" href="controlpanel_reports?delete_report_id=' . $report->getReportId() . '">(Delete)</a>';
        }
        return $string_status;
    }

    public function updateReport(int $report_id)
    {

        $reportDAO = new ReportDAO();
        $reportDAO->updateReport($report_id);

    }
}
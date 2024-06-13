<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class ReportDAO
{

    protected $dbh;

    function __construct() {
        $this->dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
    }
    
    function __destruct() {
        $this->dbh = null;
    }

    public function getReports(): array
    {
        $sql = 'select * from reports order by creation asc, status asc';
        $resultSet = $this->dbh->query($sql);
        $list_reports = array();

        foreach ($resultSet as $row) {
            $report = new Report((int) $row['report_id'], (int) $row['video_id'], (string) $row['reason'], (string) $row['comment'], new DateTime($row['creation']), (string) $row['status']);
            array_push($list_reports, $report);
        }
        return $list_reports;
    }


    public function addReport(int $video_id, string $reason, string $comment)
    {
        $sql = "insert into reports (video_id, reason, comment, creation, status) values (:video_id, :reason, :comment, :creation, :status)";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $video_id, ':reason' => $reason, ':comment' => $comment, ':creation' => date('Y-m-d H:i:s'), ':status' => 'pending'));
    }

    public function updateReport(int $report_id)
    {
        $sql = "update reports set status = :status where report_id = :report_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':status' => 'handled', ':report_id' => $report_id));
    }

    public function deleteReport(int $report_id)
    {
        $sql = "delete FROM reports WHERE report_id=" . $report_id;
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute();
    }

    public function getPendingReports() : array
    {
        $sql = 'select * from reports where status like "pending" order by creation asc, status asc';
        $resultSet = $this->dbh->query($sql);
        $list_reports = array();

        foreach ($resultSet as $row) {
            $report = new Report((int) $row['report_id'], (int) $row['video_id'], (string) $row['reason'], (string) $row['comment'], new DateTime($row['creation']), (string) $row['status']);
            array_push($list_reports, $report);
        }
        return $list_reports ?? [];
    }
}
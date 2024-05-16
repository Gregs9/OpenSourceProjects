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
        $sql = 'select * from reports where status like "pending" order by creation asc';
        $resultSet = $this->dbh->query($sql);
        $list_reports = array();

        foreach ($resultSet as $rij) {
            $report = new Report((int) $rij['report_id'], (int) $rij['video_id'], (string) $rij['reason'], (string) $rij['comment'], new DateTime($rij['creation']), (string) $rij['status']);
            array_push($list_reports, $report);
        }

        $sql = 'select * from reports where status like "handled" order by creation asc';

        $resultSet = $this->dbh->query($sql);
        foreach ($resultSet as $rij) {
            $report = new Report((int) $rij['report_id'], (int) $rij['video_id'], (string) $rij['reason'], (string) $rij['comment'], new DateTime($rij['creation']), (string) $rij['status']);
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
}
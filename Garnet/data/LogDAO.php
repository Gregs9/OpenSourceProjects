<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class LogDAO
{

    protected $dbh;

    function __construct() {
        $this->dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD, array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8mb4"));
    }
    
    function __destruct() {
        $this->dbh = null;
    }

    public function log(int $user_id, string $action, $video_id = null)
    {
        // Add report to database
        $sql = "insert into log (user_id, action, timestamp, video_id) values (:user_id, :action, :timestamp, :video_id)";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':user_id' => $user_id, ':action' => $action, ':timestamp' => date('Y-m-d H:i:s'), ':video_id' => $video_id));
    }

    public function getAll() : array
    {
        $sql = "select * from log order by timestamp desc";
        $resultSet = $this->dbh->query($sql);
        $list = array();
        foreach ($resultSet as $rij) {
            $log = new Log((int) $rij['log_id'], (int) $rij['user_id'], (string) $rij['action'], $rij['timestamp'], (int) $rij['video_id']);
            array_push($list, $log);
        }
        return $list;
    }

    public function getAllPerAction(string $filter) : ?array
    {
        $sql = "select * from log 
        where action REGEXP '" . $filter . "'
        order by timestamp desc";
        $resultSet = $this->dbh->query($sql);
        $list = array();
        foreach ($resultSet as $rij) {
            $log = new Log((int) $rij['log_id'], (int) $rij['user_id'], (string) $rij['action'], $rij['timestamp'], (int) $rij['video_id']);
            array_push($list, $log);
        }
        return $list;
    }
}
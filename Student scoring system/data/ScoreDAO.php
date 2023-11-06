<?php
declare(strict_types=1);
require_once("DBConfig.php");
require_once("entities/Score.php");

class ScoreDAO
{
    public function getAll()
    {
        $sql = "select * from punten";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $resultSet = $dbh->query($sql);
        $lijst = array();
        foreach ($resultSet as $rij) {
            $punt = new Score((int) $rij['moduleID'], (int) $rij['persoonID'], (int) $rij['punt']);
            array_push($lijst, $punt);
        }
        $dbh = null;
        return $lijst;
    }

    public function getAmountOfScore($persoonID)
    {
        $sql = "select count(*) from punten where persoonID= :persoonID";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':persoonID' => $persoonID));
        $dbh = null;

        return $stmt->fetchColumn();
        
    }

    public function addScore($moduleID, $persoonID, $punt)
    {
        $sql = "insert into punten (moduleID, persoonID, punt) values (:moduleID, :persoonID, :punt)";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':moduleID' => $moduleID, ':persoonID' => $persoonID, ':punt' => $punt));
        $dbh = null;
    }
}
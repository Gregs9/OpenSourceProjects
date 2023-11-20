<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class PlaatsDAO
{
    public function getAll() : array
    {
        $sql = "select * from plaatsen";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $resultSet = $dbh->query($sql);
        $lijst = array();
        foreach ($resultSet as $rij) {
            $plaats = new Plaats((int) $rij['plaatsId'], (string) $rij['postcode'], (string) $rij['plaats']);
            array_push($lijst, $plaats);
        }
        $dbh = null;

        return $lijst;
    }
}


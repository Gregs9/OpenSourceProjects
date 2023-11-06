<?php
declare(strict_types=1);
require_once("DBConfig.php");
require_once("entities/Persoon.php");

class PersoonDAO
{
    public function getAll()
    {
        $sql = "select * from personen";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $resultSet = $dbh->query($sql);
        $lijst = array();
        foreach ($resultSet as $rij) {
            $persoon = new Persoon((int) $rij['id'], (string) $rij['voornaam'], (string) $rij['familienaam'], $rij['geboortedatum'], (string) $rij['geslacht']);
            array_push($lijst, $persoon);
        }
        $dbh = null;
        return $lijst;
    }

    public function getUserById(int $id): ?Persoon
    {
        $sql = "select * from personen where id= :id";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':id' => $id));
        $rij = $stmt->fetch(PDO::FETCH_ASSOC);

        $persoon = new Persoon((int) $rij['id'], (string) $rij['voornaam'], (string) $rij['familienaam'], $rij['geboortedatum'], (string) $rij['geslacht']);

        $dbh = null;

        return $persoon;
    }
}
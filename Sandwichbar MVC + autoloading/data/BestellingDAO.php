<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class BestellingDAO
{
    public function getAll(): array
    {
        $sql = "select * from bestellingen order by status desc, datum_bestelling asc";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $resultSet = $dbh->query($sql);
        $lijst = array();
        foreach ($resultSet as $rij) {
            $bestelling = new Bestelling((int) $rij['ID'], (int) $rij['klant_ID'], (int) $rij['broodje_ID'], $rij['datum_bestelling'], (string) $rij['status']);
            array_push($lijst, $bestelling);
        }
        $dbh = null;

        return $lijst;
    }

    public function addBestelling(Broodje $broodje, User $user)
    {
        $sql = "insert into bestellingen (klant_ID, broodje_ID, datum_bestelling, status) values (:klant_ID, :broodje_ID, :datum_bestelling, :status)";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':klant_ID' => $user->getId(), ':broodje_ID' => $broodje->getId(), ':datum_bestelling' => date('Y-m-d H:i:s'), ':status' => "besteld"));
        $dbh = null;
    }

    public function updateBestelling(Bestelling $bestelling)
    {
        $sql = "update bestellingen set status = :status where id = :id";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':status' => 'afgewerkt', ':id' => $bestelling->getId()));
        $dbh = null;
    }
}
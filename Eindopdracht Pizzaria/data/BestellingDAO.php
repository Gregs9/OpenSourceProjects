<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class BestellingDAO
{
    public function addBestelBon(string $datum, int $klantId, string $afleveradres, string $opmerking, float $verkoopprijs): int
    {

        $sql = "insert into bestelbonnen (datum, klant_id, afleveradres, opmerking, verkoopprijs) values (:datum, :klant_id, :afleveradres, :opmerking, :verkoopprijs)";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':datum' => $datum, ':klant_id' => $klantId, ':afleveradres' => $afleveradres, ':opmerking' => $opmerking, ':verkoopprijs' => $verkoopprijs));
        $bestelbonId = intval($dbh->lastInsertId());
        $dbh = null;

        return $bestelbonId;
    }

    public function addBestelLijn(int $bestelbonId, int $pizzaId, int $aantal)
    {
        $sql = "insert into bestellijnen (bestelbon_id, pizza_id, aantal) values (:bestelbon_id, :pizza_id, :aantal)";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':bestelbon_id' => $bestelbonId, ':pizza_id' => $pizzaId, ':aantal' => $aantal));
        $dbh = null;
    }
}
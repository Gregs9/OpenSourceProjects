<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class PizzaDAO
{
    public function getAll() : array
    {
        $sql = "select * from pizzas";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $resultSet = $dbh->query($sql);
        $lijst = array();
        foreach ($resultSet as $rij) {
            $pizza = new Pizza((int) $rij['id'], (string) $rij['naam'], (float) $rij['prijs'], (string) $rij['ingredienten'], (string) $rij['allergenen']);
            array_push($lijst, $pizza);
        }
        $dbh = null;

        return $lijst;
    }
}
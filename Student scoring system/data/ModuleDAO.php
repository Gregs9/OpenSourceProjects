<?php
declare(strict_types=1);
require_once("DBConfig.php");
require_once("entities/Module.php");

class ModuleDAO 
{
    public function getAll()
    {
        $sql = "select * from modules";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $resultSet = $dbh->query($sql);
        $lijst = array();
        foreach ($resultSet as $rij) {
            $module = new Module((int) $rij['id'], (string) $rij['naam'], (float) $rij['prijs']);
            array_push($lijst, $module);
        }
        $dbh = null;
        return $lijst;
    }


}
<?php


class DBConfig
{
    public static $DB_CONNSTRING = "mysql:host=localhost;dbname=garnet_public;charset=utf8";
    public static $DB_USERNAME = "root";
    public static $DB_PASSWORD = "";

    public static function getDatabaseName()
    {
        $dbName = explode(';', self::$DB_CONNSTRING);
        $dbName = explode('=', $dbName[1]);
        return $dbName[1];
    }
}

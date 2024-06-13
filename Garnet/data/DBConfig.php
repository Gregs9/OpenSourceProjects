<?php


// class DBConfig
// {
//     public static $DB_CONNSTRING = "mysql:host=grego1-garnet.db.transip.me;dbname=grego1_garnet;charset=utf8";
//     public static $DB_USERNAME = "grego1_garnetAdmin";
//     public static $DB_PASSWORD = "5454564dsd897SD98DSDHSD87087777!è!çèç!è";

//     public static function getDatabaseName()
//     {
//         $dbName = explode(';', self::$DB_CONNSTRING);
//         $dbName = explode('=', $dbName[1]);
//         return $dbName[1];
//     }
// }


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

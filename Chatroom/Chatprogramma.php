<?php
declare(strict_types=1);

class Chat
{
    private string $dbConn;
    private string $dbUsername;
    private string $dbPassword;
    private $LIJST_ELEMENTEN = array();


    public function __construct()
    {
        $this->dbConn = "mysql:host=localhost;dbname=cursusphp;charset=utf8";
        $this->dbUsername = "cursusgebruiker";
        $this->dbPassword = "cursuspwd";

        //Leg een connectie met de database
        $dbh = new PDO($this->dbConn, $this->dbUsername, $this->dbPassword);

        //Definiër de SQL query
        $sql = "select * from chatlog order by timestamp asc limit 20";

        $stmt = $dbh->prepare($sql);

        //Voer de SQL query uit met deze parameters (positioneel, dus variable in volgorde van de vraagtekens)
        $stmt->execute(array());

        //Steek alle resultaten in een array 'resultSet'
        $resultSet = $stmt->fetchAll(PDO::FETCH_ASSOC);

        //Creër een nieuwe lijst
        $lijst = array();

        //Loop door elk resultaat van het resultaat, en steek het resultaat in deze nieuwe array van resultaten
        foreach ($resultSet as $rij) {
            $element = new Element((int) $rij["id"], (string) $rij["username"], (string) $rij["message"], $rij["timestamp"]);
            array_push($lijst, $element);
        }
        //Sluit de connectie met de database
        $dbh = null;

        //Geef de lijst met resultaten terug aan de oproeper
        $this->LIJST_ELEMENTEN = $lijst;
    }

    public function getLIJSTELEMENTEN() : array {
        return $this->LIJST_ELEMENTEN;
    }

    public function sendMessage(string $message) {
        $sql = "insert into chatlog (username, message, timestamp) values (:username, :message, :timestamp)";
        $dbh = new PDO($this->dbConn, $this->dbUsername, $this->dbPassword);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':username' => $_COOKIE['username'], ':message' => $message, ':timestamp' => date('Y-m-d H:i:s')));
        $dbh = null;
    }

}






class Element
{
    private $id;
    private $username;
    private $message;
    private $timestamp;

    public function __construct(int $id, string $username, string $message, $timestamp) {
        $this->id = $id;
        $this->username = $username;
        $this->message = $message;
        $this->timestamp = $timestamp;
    }

    public function getId()
    {
        return $this->id;
    }

    public function getUsername()
    {
        return $this->username;
    }

    public function getMessage()
    {
        return $this->message;
    }

    public function getTimestamp()
    {
        return $this->timestamp;
    }
}
?>
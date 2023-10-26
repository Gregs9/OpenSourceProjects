<?php
declare(strict_types=1);

class Gastenboek
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
        $sql = "select * from gastenboek order by datum desc";
        $stmt = $dbh->prepare($sql);

        //Voer de SQL query uit met deze parameters (positioneel, dus variable in volgorde van de vraagtekens)
        $stmt->execute(array());

        //Steek alle resultaten in een array 'resultSet'
        $resultSet = $stmt->fetchAll(PDO::FETCH_ASSOC);

        //Creër een nieuwe lijst
        $lijst = array();

        //Loop door elk resultaat van het resultaat, en steek het resultaat in deze nieuwe array van resultaten
        foreach ($resultSet as $rij) {
            $element = new Element((int) $rij["id"], (string) $rij["auteur"], (string) $rij["boodschap"], $rij["datum"]);
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

    public function addBoodschap(string $auteur, string $boodschap) {
        $sql = "insert into gastenboek (auteur, boodschap, datum) values (:auteur, :boodschap, :datum)";
        $dbh = new PDO($this->dbConn, $this->dbUsername, $this->dbPassword);
        $stmt = $dbh->prepare($sql);
    $stmt->execute(array(':auteur' => $auteur, ':boodschap' => $boodschap, ':datum' => date('Y-m-d H:i:s')));
        $dbh = null;
    }



}






class Element
{
    private $id;
    private $auteur;
    private $boodschap;
    private $datum;

    public function __construct(int $id, string $auteur, string $boodschap, $datum) {
        $this->id = $id;
        $this->auteur = $auteur;
        $this->boodschap = $boodschap;
        $this->datum = $datum;
    }

    public function getId()
    {
        return $this->id;
    }

    public function getAuteur()
    {
        return $this->auteur;
    }

    public function getBoodschap()
    {
        return $this->boodschap;
    }

    public function getDatum()
    {
        return $this->datum;
    }
}
?>
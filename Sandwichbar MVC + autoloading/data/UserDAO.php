<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class UserDAO
{
    public function getAll(): array
    {
        $sql = "select * from gebruikers";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $resultSet = $dbh->query($sql);
        $lijst = array();
        foreach ($resultSet as $rij) {
            $user = new User((int) $rij['ID'], (string) $rij['Naam'], (string) $rij['Email'], (string) $rij['Wachtwoord'], (string) $rij['Status'], (string) $rij['Type'], $rij['Creatie']);
            array_push($lijst, $user);
        }
        $dbh = null;

        return $lijst;
    }

    public function addUser($naam, $email, $wachtwoord)
    {
        // Add user to database, without ID because it's auto increment
        $sql = "insert into gebruikers (Naam, Email, Wachtwoord, Status, Type, Creatie) values (:Naam, :Email, :Wachtwoord, :Status, :Type, :Creatie)";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':Naam' => $naam, ':Email' => $email, ':Wachtwoord' => $wachtwoord, ':Status' => "actief", ':Type' => "klant", ':Creatie' => date('Y-m-d H:i:s')));
        $dbh = null;
    }

    public function blockUser(User $user)
    {
        $sql = "update gebruikers set Status = :status where ID = :ID";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':status' => 'geblokkeerd', ':ID' => $user->getId()));
        $dbh = null;
    }

    public function unblockUser(User $user)
    {
        $sql = "update gebruikers set Status = :status where ID = :ID";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':status' => 'actief', ':ID' => $user->getId()));
        $dbh = null;
    }

    public function validateUser(string $user_email, string $user_password): ?User
    {
        $lijst_gebruikers = $this->getAll();
        foreach ($lijst_gebruikers as $user){
            if (($user->getEmail() == $user_email) && (password_verify($user_password, $user->getPassword()))) {
                return $user;
            }
        }

        return null;




    }
}
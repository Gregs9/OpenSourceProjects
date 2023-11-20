<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class UserDAO
{
    public function getAll(): array
    {
        $sql = "select * from users";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $resultSet = $dbh->query($sql);
        $lijst = array();
        foreach ($resultSet as $rij) {
            $user = new User((int) $rij['id'], (string) $rij['familienaam'], (string) $rij['voornaam'], (string) $rij['adres'], (string) $rij['email'], (string) $rij['wachtwoord'], (string) $rij['tel'], (int) $rij['plaatsId'], (int) $rij['kortingsTarief']);
            array_push($lijst, $user);
        }
        $dbh = null;

        return $lijst;
    }

    public function addUser($familienaam, $voornaam, $adres, $email, $wachtwoord, $tel, $plaatsId)
    {
        // Add user to database, without ID because it's auto increment
        $sql = "insert into users (familienaam, voornaam, adres, email, wachtwoord, tel, plaatsId, kortingsTarief) values (:familienaam, :voornaam, :adres, :email, :wachtwoord, :tel, :plaatsId, :kortingsTarief)";
        $dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
        $stmt = $dbh->prepare($sql);
        $stmt->execute(array(':familienaam' => $familienaam, ':voornaam' => $voornaam, ':adres' => $adres, ':email' => $email, ':wachtwoord' => $wachtwoord, ':tel' => $tel, ':plaatsId' => $plaatsId, ':kortingsTarief' => 0));
        $dbh = null;
    }

    public function validateUser(string $user_email, string $user_password): ?User
    {
        $lijst_gebruikers = $this->getAll();
        foreach ($lijst_gebruikers as $user) {
            if (($user->getEmail() == $user_email) && (password_verify($user_password, $user->getWachtwoord()))) {
                return $user;
            }
        }

        return null;
    }


}
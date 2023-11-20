<?php
declare(strict_types=1);
require_once('data/autoloader.php');
class UserService
{
    public function getUsers(): array
    {
        $userDAO = new UserDAO();
        $lijst = $userDAO->getAll();
        return $lijst;
    }

    public function getUserById(int $id): ?User
    {
        $lijst_users = $this->getUsers();
        foreach ($lijst_users as $user) {
            if ($user->getId() === $id) {
                return $user;
            }
        }
    }

    public function getUserByEmail(string $email): ?User
    {

        $lijst_users = $this->getUsers();
        foreach ($lijst_users as $user) {
            if ($user->getEmail() === strtolower($email)) {
                return $user;
            }
        }
    }

    public function addUser(string $familienaam, string $voornaam, string $adres, string $postcode, string $gemeente, string $email, string $wachtwoord, string $tel)
    {
        $userDAO = new UserDAO();
        $plaatsSvc = new PlaatsService();
        $plaatsId = $plaatsSvc->getPlaatsByPostcode($postcode)->getPlaatsId();

        $userDAO->addUser($familienaam, $voornaam, $adres, $email, $wachtwoord, $tel, $plaatsId);
    }

    public function validateUser(string $user_email, string $user_password): bool
    {
        $userDAO = new UserDAO();
        $user = $userDAO->validateUser($user_email, $user_password);
        if ($user !== null) {
            return true;
        } else {
            return false;
        }
    }

    public function validatePasswordRepetition(string $password, string $password2): bool
    {
        if ($password === $password2) {
            return true;
        } else {
            return false;
        }
    }

    public function validateEmail(string $email): bool
    {
        //Gebruik de ingebouwde functie om het formaat van een email adres te valideren
        if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
            return false;
        }

        //Controleer als het email adres al bestaat in de database
        $alreadyExists = true;
        $lijst_users = $this->getUsers();
        foreach ($lijst_users as $user) {
            if ($user->getEmail() === $email) {
                $alreadyExists = false;
            }
        }

        return $alreadyExists;
    }

}
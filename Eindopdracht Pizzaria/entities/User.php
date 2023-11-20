<?php
declare(strict_types=1);

class User
{
    private $id;
    private $familienaam;
    private $voornaam;
    private $adres;
    private $email;
    private $wachtwoord;
    private $telefoonNummer;
    private $plaatsId;
private $kortingsTarief;
    public function __construct(int $id, string $familienaam, string $voornaam, string $adres, string $email, string $wachtwoord, string $telefoonNummer, int $plaatsId, int $kortingsTarief)
    {
        $this->id = $id;
        $this->familienaam = $familienaam;
        $this->voornaam = $voornaam;
        $this->adres = $adres;
        $this->email = $email;
        $this->wachtwoord = $wachtwoord;
        $this->telefoonNummer = $telefoonNummer;
        $this->plaatsId = $plaatsId;
        $this->kortingsTarief = $kortingsTarief;
    }

    public function getId()
    {
        return $this->id;
    }

    public function getFamilienaam()
    {
        return $this->familienaam;
    }

    public function getVoornaam()
    {
        return $this->voornaam;
    }

    public function getAdres()
    {
        return $this->adres;
    }

    public function getTelefoonNummer()
    {
        return $this->telefoonNummer;
    }

    public function getWachtwoord()
    {
        return $this->wachtwoord;
    }

    public function getEmail()
    {
        return $this->email;
    }

    public function getPlaatsId()
    {
        return $this->plaatsId;
    }

    public function getKortingsTarief()
    {
        return $this->kortingsTarief;
    }
}

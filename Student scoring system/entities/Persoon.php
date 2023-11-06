<?php
declare(strict_types=1);

class Persoon 
{
    private $id;
    private $voornaam;
    private $familienaam;
    private $geboortedatum;
    private $geslacht;

    public function __construct(int $id, string $voornaam, string $familienaam, $geboortedatum, string $geslacht)
    {
        $this->id = $id;
        $this->voornaam = $voornaam;
        $this->familienaam = $familienaam;
        $this->geboortedatum = $geboortedatum;
        $this->geslacht = $geslacht;
    }

    public function getId(): int
    {
        return $this->id;
    }

    public function getVoornaam(): string
    {
        return $this->voornaam;
    }
    public function getFamilienaam(): string
    {
        return $this->familienaam;
    }

    public function getGeboortedatum()
    {
        return $this->geboortedatum;
    }

    public function getgeslacht(): string
    {
        return $this->geslacht;
    }
}
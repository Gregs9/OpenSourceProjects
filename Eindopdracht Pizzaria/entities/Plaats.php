<?php
declare(strict_types=1);

class Plaats
{
    private $plaatsId;
    private $plaatsPostcode;
    private $plaatsNaam;

    public function __construct(int $plaatsId, string $plaatsPostcode, string $plaatsNaam)
    {
        $this->plaatsId = $plaatsId;
        $this->plaatsPostcode = $plaatsPostcode;
        $this->plaatsNaam = $plaatsNaam;
    }

    public function getPlaatsId(): int
    {
        return $this->plaatsId;
    }

    public function getPostcode(): string
    {
        return $this->plaatsPostcode;
    }

    public function getNaam(): string
    {
        return $this->plaatsNaam;
    }

}
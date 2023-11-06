<?php
declare(strict_types=1);

class Bestelling
{
    private $id;
    private $klant_ID;
    private $broodje_ID;
    private $datum_bestelling;
    private $status;


    public function __construct(int $id, int $klant_id, int $broodje_id, $datum_bestelling, string $status)
    {
        $this->id = $id;
        $this->klant_ID = $klant_id;
        $this->broodje_ID = $broodje_id;
        $this->datum_bestelling = $datum_bestelling;
        $this->status = $status;

    }

    public function getId()
    {
        return $this->id;
    }

    public function getKlantId()
    {
        return $this->klant_ID;
    }

    public function getBroodjeId()
    {
        return $this->broodje_ID;
    }

    public function getDatumBestelling()
    {
        return $this->datum_bestelling;
    }

    public function getStatus()
    {
        return $this->status;
    }
}
?>
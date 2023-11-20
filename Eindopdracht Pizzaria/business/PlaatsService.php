<?php
declare(strict_types=1);
require_once('data/autoloader.php');
class PlaatsService
{
    public function getPlaatsen(): array
    {
        $plaatsDao = new PlaatsDAO();
        $lijst_plaatsen = $plaatsDao->getAll();
        return $lijst_plaatsen;
    }

    public function getPlaatsById(int $plaatsId): ?Plaats
    {
        $lijst_plaatsen = $this->getPlaatsen();
        foreach ($lijst_plaatsen as $plaats) {
            if ($plaats->getPlaatsId() === $plaatsId) {
                return $plaats;
            }
        }
    }

    public function getPlaatsByPostcode(string $postcode): ?Plaats
    {
        $lijst_plaatsen = $this->getPlaatsen();
        foreach ($lijst_plaatsen as $plaats) {
            if ($plaats->getPostcode() === $postcode) {
                return $plaats;
            }
        }
    }
}
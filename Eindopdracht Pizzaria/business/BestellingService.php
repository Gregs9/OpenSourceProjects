<?php
declare(strict_types=1);
require_once('data/autoloader.php');
class BestellingService
{
    public function addBestelBon(int $klant_id = 0, string $afleveradres, string $opmerking, float $verkoopprijs): int
    {
        $bestellingDAO = new BestellingDAO();
        $date = date("Y/m/d H:i:s");
        $bestelbonId = $bestellingDAO->addBestelBon($date, $klant_id, $afleveradres, $opmerking, $verkoopprijs);

        return $bestelbonId;

    }

    public function addBestelLijn(int $bestelbonId, int $pizzaId, int $aantal)
    {
        $bestellingDAO = new BestellingDAO();
        $bestellingDAO->addBestelLijn($bestelbonId, $pizzaId, $aantal);
    }

    public function getPriceOfOrder(array $order, int $korting) : float
    {
        $totaal = 0;
        foreach ($order as $orderLine) {
            $totaal += $orderLine->prijs * $orderLine->aantal;
        }

        return floatval($totaal);
    }

    public function getTotalPriceOfOrder(array $order, int $korting): float
    {
        $totaal = 0;
        foreach ($order as $orderLine) {
            $totaal += $orderLine->prijs * $orderLine->aantal;
        }

        //pas eventuele korting toe
        $totaal = $totaal * ((100 - $korting) / 100);

        return floatval($totaal);
    }


}
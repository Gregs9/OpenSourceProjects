<?php //business/BoekService.php
declare(strict_types=1);
require_once("data/PersoonDAO.php");
class PersoonService
{
    public function getPersonen() : array {
        $persoonDAO = new PersoonDAO();
        $lijst = $persoonDAO->getAll();
        return $lijst;
    }

    public function getPersoonById(int $id) : ?Persoon {
        $persoonDAO = new PersoonDAO();
        $persoon = $persoonDAO->getUserById($id);
        return $persoon;
    }
}
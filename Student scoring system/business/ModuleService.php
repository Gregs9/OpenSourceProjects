<?php
declare(strict_types=1);
require_once("data/ModuleDAO.php");
class ModuleService
{
    public function getModules() : array {
        $moduleDAO = new ModuleDAO();
        $lijst = $moduleDAO->getAll();
        return $lijst;
    }
}
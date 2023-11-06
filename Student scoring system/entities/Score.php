<?php
declare(strict_types=1);

class Score 
{
    private $module_id;
    private $persoon_id;
    private $punt;


    public function __construct(int $module_id, int $persoon_id, int $punt)
    {
        $this->module_id = $module_id;
        $this->persoon_id = $persoon_id;
        $this->punt = $punt;
    }

    public function getModuleId()
    {
        return $this->module_id;
    }

    public function getPersoonId()
    {
        return $this->persoon_id;
    }
    public function getPunt()
    {
        return $this->punt;
    }
}
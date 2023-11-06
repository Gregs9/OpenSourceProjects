<?php
declare(strict_types=1);
require_once("data/ScoreDAO.php");
class ScoreService
{
    public function getScores(): array
    {
        $ScoreDAO = new ScoreDAO();
        $lijstScores = $ScoreDAO->getAll();
        return $lijstScores;
    }

    public function getScoreByID(int $moduleID, int $persoonID)
    {
        $ScoreDAO = new ScoreDAO();
        $lijstScores = $ScoreDAO->getAll();
        $found = false;
        foreach ($lijstScores as $score) {
            if (($score->getModuleID() === $moduleID) && ($score->getPersoonId() === $persoonID)) {
                $found = true;
                return $score->getPunt();
            }
        }

        if ($found === false) {
            return '';
        }
    }

    public function getAmountOfScores($persoonID)
    {
        $scoreDAO = new ScoreDAO();
        return $scoreDAO->getAmountOfScore($persoonID);
    }

    public function addScore(int $moduleID, int $persoonID, int $punt)
    {
        $scoreDAO = new ScoreDAO();
        $scoreDAO->addScore($moduleID, $persoonID, $punt);
    }

    public function getAverageScoreByModule($moduleID) : ?float
    {
        $results = 0;
        $totaal = 0;

        $lijst_scores = $this->getScores();
        foreach ($lijst_scores as $score) {
            if ($score->getModuleID() === $moduleID) {
                $totaal += $score->getPunt();
                $results++;
            }
        }
        if ($results > 0) {
            return round($totaal / $results, 2);
        } else {
            return null;
        }

    }

    public function getAverageScoreByPersoon($persoonID) : ?float
    {
        $results = 0;
        $totaal = 0;

        $lijst_scores = $this->getScores();
        foreach ($lijst_scores as $score) {
            if ($score->getPersoonId() === $persoonID) {
                $totaal += $score->getPunt();
                $results++;
            }
        }
        if ($results > 0) {
            return round($totaal / $results, 2);
        } else {
            return null;
        }
    }




}
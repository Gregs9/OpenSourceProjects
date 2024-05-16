<?php
declare(strict_types=1);
require_once ('data/autoloader.php');

class LogService
{
    public function log(int $user_id, string $action, int $video_id = null)
    {
        $logDAO = new LogDAO();
        $logDAO->log($user_id, $action, $video_id);
    }

    public function getAll(): array
    {
        $logDAO = new LogDAO();
        return $logDAO->getAll();
    }

    public function getAllPerAction(string $filter): ?array
    {
        $logDAO = new LogDAO();
        return $logDAO->getAllPerAction($filter);
    }

}
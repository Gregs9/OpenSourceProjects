<?php
declare(strict_types=1);

class Log
{
    private int $log_id;
    private int $user_id;
    private string $action;
    private $timestamp;
    private int $video_id;

    public function __construct(int $log_id, int $user_id, string $action, $timestamp, int $video_id)
    {
        $this->log_id = $log_id;
        $this->user_id = $user_id;
        $this->action = $action;
        $this->timestamp = $timestamp;
        $this->video_id = $video_id;
    }

    public function getId() : int
    {
        return $this->log_id;
    }

    public function getUserId() : int
    {
        return $this->user_id;
    }

    public function getAction() : string
    {
        return $this->action;
    }

    public function getTimestamp()
    {
        return $this->timestamp;
    }

    public function getVideoId() : ?int
    {
        return $this->video_id;
    }
}
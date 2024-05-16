<?php
declare(strict_types=1);

class Report
{
    private $report_id;
    private $video_id;
    private $reason;
    private $description;
    private $creation;
    private $status;

    public function __construct(int $report_id, int $video_id, string $reason, string $description, $creation, string $status)
    {
        $this->report_id = $report_id;
        $this->video_id = $video_id;
        $this->reason = $reason;
        $this->description = $description;
        $this->creation = $creation;
        $this->status = $status;
    }

    public function getReportId()
    {
        return $this->report_id;
    }

    public function getVideoId()
    {
        return $this->video_id;
    }

    public function getReason()
    {
        return $this->reason;
    }

    public function getDescription()
    {
        return $this->description;
    }

    public function getCreation()
    {
        return $this->creation;
    }

    public function getStatus()
    {
        return $this->status;
    }
}
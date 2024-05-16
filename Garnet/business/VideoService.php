<?php
declare(strict_types=1);
require_once ('data/autoloader.php');

class VideoService
{
    public function getAllVideos(): array
    {
        $videoDAO = new VideoDAO();
        return $videoDAO->getAllVideos();
    }

    public function getVideosWithUnknownCreator(): array
    {
        $videoDAO = new VideoDAO();
        return $videoDAO->getVideosWithUnknownCreator();
    }

    public function getVideoById(int $video_id): ?Video
    {
        $videoDAO = new VideoDAO();
        return $videoDAO->getVideoById($video_id);
    }


    public function getAllVideosWithTag(int $tag_id): array
    {
        $newvideolist = array();

        foreach ($this->getAllVideos() as $video) {
            $taglist = $video->getTags();
            foreach ($taglist as $tag) {
                if (intval($tag->getId()) == intval($tag_id)) {
                    array_push($newvideolist, $video);
                }
            }
        }
        return $newvideolist;
    }

    public function addScore(Video $video)
    {
        $videoDAO = new VideoDAO();
        $videoDAO->addScore($video);
    }

    public function addView(Video $video)
    {
        $videoDAO = new VideoDAO();
        $videoDAO->addView($video);
    }

    public function removeView(Video $video)
    {
        $videoDAO = new VideoDAO();
        $videoDAO->removeView($video);
    }

    public function getPostedTimeAgo(datetime $date_added): ?string
    {
        $strTime = array("second", "minute", "hour", "day", "month", "year");
        $length = array("60", "60", "24", "30", "12", "10");
    
        $currentTime = time();
        $date_added = $date_added->getTimestamp();
    
        if ($currentTime >= $date_added) {
            $diff = $currentTime - $date_added;
            for ($i = 0; $diff >= $length[$i] && $i < count($length) - 1; $i++) {
                $diff = $diff / $length[$i];
            }
    
            $diff = round($diff);
            $plural = ($diff > 1) ? "s" : ""; //check als meervoud nodig is of niet
            return $diff . " " . $strTime[$i] . $plural . " ago";
        }
        return "Just now"; //als er geen groot verschil is
    
    }

    public function getSimilarVideos(Video $currentVideo): array
    {
        $videoDAO = new VideoDAO;
        return $videoDAO->getSimilarVideos($currentVideo);
    }

    public function getRecommendedVideos(int $user_id): ?array
    {
        $videoDAO = new VideoDAO;
        return $videoDAO->getRecommendedVideos($user_id);
    }

    public function addTagToVideo(Tag $requested_tag, Video $video)
    {

        $tagDAO = new TagDAO();

        $videoTags = $tagDAO->getAllTagsFromVideoByVideoId($video->getId());

        $valid_tag = true;
        
        //CHECK IF TAG ISN'T ALREADY IN THIS VIDEO
        foreach ($videoTags as $tag) {
            if ($tag->getId() == $requested_tag->getId()) {
                $valid_tag = false;
            }
        }

        if ($valid_tag) {
            $videoDAO = new VideoDAO();
            $videoDAO->addTagToVideo($video, $requested_tag);
        }

    }

    public function removeTagFromVideo(Tag $requested_tag, Video $video)
    {

        $doesVideoContainGivenTag = false;
        $whichTag = '';

        $tagDAO = new TagDAO();
        foreach ($tagDAO->getAllTagsFromVideo($video) as $tag) {
            if ($requested_tag->getId() == $tag->getId()) {
                $doesVideoContainGivenTag = true;
                $whichTag = $tag;
                break;
            }
        }

        if ($doesVideoContainGivenTag) {
            $videoDAO = new VideoDAO();
            $videoDAO->removeTagFromVideo($video, $whichTag);
        }
    }

    public function addVideo(string $filename, int $score, string $extension, string $description, int $views, string $title, string $duration, int $filesize, int $uploaded_by): int
    {
        $videoDAO = new VideoDAO();
        return $videoDAO->addVideo($filename, $score, $extension, $description, $views, $title, $duration, $filesize, $uploaded_by);
    }

    public function updateVideo(Video $video)
    {
        $videoDAO = new VideoDAO();
        $videoDAO->updateVideo($video);
    }

    public function deleteVideo(Video $video)
    {
        $videoDAO = new VideoDAO();
        $videoDAO->deleteVideo($video);
    }

    public function getRandomVideoId(): int
    {
        $videoDAO = new VideoDAO();
        return $videoDAO->getRandomVideoId();
    }

    public function getVideoCreatorsAsString(int $video_id): ?string
    {
        $videoDAO = new VideoDAO();
        return $videoDAO->getVideoCreatorsAsString($video_id);
    }

    public function getShort() : Video
    {
        $videoDAO = new VideoDAO();
        return $videoDAO->getShort();
    }

}
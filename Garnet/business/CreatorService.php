<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class CreatorService
{
    public function getAll(): array
    {
        $creatorDAO = new CreatorDAO();
        return $creatorDAO->getAll();
    }

    public function getAllSortedByAmountOfStarredin(): array
    {
        $creatorDAO = new CreatorDAO();
        return $creatorDAO->getAllSortedByAmountOfStarredin();
    }

    public function getCreatorById(int $creator_id): ?Creator
    {
        $creatorDAO = new CreatorDAO();
        return $creatorDAO->getCreatorById($creator_id);
    }

    public function getCreatorByName(string $creator_name): ?Creator
    {
        $creatorDAO = new CreatorDAO();
        return $creatorDAO->getCreatorByName($creator_name);
    }

    public function getCreatorsByVideoId(int $videoId): array
    {
        $creatorDAO = new CreatorDAO();
        return $creatorDAO->getCreatorsByVideoId($videoId);
    }

    public function getCreatorsByVideoIdAsString(int $videoId): ?string
    {
        $creatorDAO = new CreatorDAO();
        $arr_creators = $creatorDAO->getCreatorsByVideoId($videoId);

        if (count($arr_creators) > 0) {

            $stringBuilder = '';

            foreach ($arr_creators as $creator) {
                $stringBuilder = $stringBuilder . ';' . $creator->getName();
            }

            if (mb_substr($stringBuilder, 0, 1) == ';') {
                $stringBuilder = substr($stringBuilder, 1);
            }

            return $stringBuilder;
        } else {
            return null;
        }
    }

    public function addCreator(string $name, string $alias, $dateOfBirth, string $nationality, string $social_in, string $social_x, string $description): int
    {
        $creatorDAO = new CreatorDAO();
        return $creatorDAO->addCreator($name, $alias, $dateOfBirth, $nationality, $social_in, $social_x, $description); //return last inserted id for creator's thumbnail
    }

    public function addCreatorToVideo(Creator $creator, Video $video)
    {
        $creatorDAO = new CreatorDAO();
        $creatorDAO->addCreatorToVideo($creator, $video);
    }

    public function removeCreatorFromVideo(int $creatorId, int $videoId)
    {
        $creatorDAO = new CreatorDAO();
        $creatorDAO->removeCreatorFromVideo($creatorId, $videoId);
    }

    public function deleteCreator(Creator $creator)
    {
        $creatorDAO = new CreatorDAO();
        $creatorDAO->deleteCreator($creator);
    }

    public function getAmountStarredIn(Creator $creator): int
    {
        $creatorDAO = new CreatorDAO();
        return $creatorDAO->getAmountStarredIn($creator);
    }

    public function getCreatorsFavoriteCategory(Creator $creator)
    {
        $creatorDAO = new CreatorDAO();
        return $creatorDAO->getCreatorsFavoriteCategory($creator);
    }

    public function checkIfVideoAlreadyHasCreator(Creator $creator, int $video_id): bool
    {
        $creatorDAO = new CreatorDAO();
        return $creatorDAO->checkIfVideoAlreadyHasCreator($creator, $video_id);
    }

    public function removeAllCreatorsFromVideo(Video $video)
    {
        $creatorDAO = new CreatorDAO();
        $creatorDAO->removeAllCreatorsFromVideo($video);
    }

    public function getAllVideosByCreator(Creator $creator): array
    {
        $creatorDAO = new CreatorDAO();
        return $creatorDAO->getAllVideosByCreator($creator);
    }

    public function getTotalScoreOfCreator(Creator $creator): int
    {
        $totalScore = 0;
        foreach ($this->getAllVideosByCreator($creator) as $video) {
            $totalScore += $video->getScore();
        }
        return $totalScore;
    }

    public function getTotalViewsOfCreator(Creator $creator): int
    {
        $totalViews = 0;
        foreach ($this->getAllVideosByCreator($creator) as $video) {
            $totalViews += $video->getViews();
        }
        return $totalViews;
    }

    public function updateCreator(Creator $creator)
    {
        $creatorDAO = new CreatorDAO();
        $creatorDAO->updateCreator($creator);
    }

    public function getBirthday($currentDate): array
    {
        //get all creators with a valid birthdate
        $all_creators = $this->getAll();
        $arr_of_all_creators_with_a_birthdate = array();
        foreach ($all_creators as $creator) {
            $creator_dob = $creator->getDateOfBirth();
            if ($creator_dob !== null) {
                array_push($arr_of_all_creators_with_a_birthdate, $creator);
            }

        }

        //For each creator with a valid birthday, check if day and month matches current day and month
        $arr_all_creators_with_birthday_today = array();
        foreach ($arr_of_all_creators_with_a_birthdate as $creator) {
            $creator_day = date('d', strtotime($creator->getDateOfBirth()));
            $creator_month = date('m', strtotime($creator->getDateOfBirth()));
            $current_day = date('d');
            $current_month = date('m');

            if (($creator_day == $current_day) && ($creator_month == $current_month)) {
                array_push($arr_all_creators_with_birthday_today, $creator);
            }   
        }

        return $arr_all_creators_with_birthday_today;
    }

    public function isBirthday(Creator $creator) : bool
    {

        if ($creator->getDateOfBirth() !== '' && $creator->getDateOfBirth() !== null) {
            $creator_day = date('d', strtotime($creator->getDateOfBirth()));
            $creator_month = date('m', strtotime($creator->getDateOfBirth()));
            $current_day = date('d');
            $current_month = date('m');
    
            if (($creator_day == $current_day) && ($creator_month == $current_month)) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    public function getLatestVideosByCreator($creator) : array
    {
        $creatorDAO = new CreatorDAO;
        return $creatorDAO->getLatestVideosByCreator($creator);
    }
}
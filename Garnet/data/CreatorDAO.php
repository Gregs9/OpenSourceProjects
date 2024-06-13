<?php
declare(strict_types=1);
require_once ('data/autoloader.php');
class CreatorDAO
{

    protected $dbh;

    function __construct() {
        $this->dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD, array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8mb4"));
    }
    
    function __destruct() {
        $this->dbh = null;
    }


    public function getAll(): array
    {
        $sql = "select * from creators order by name asc";
        $resultSet = $this->dbh->query($sql);
        $list = array();
        foreach ($resultSet as $rij) {
            $creator = new Creator((int) $rij['creator_id'], (string) $rij['name'], (string) $rij['alias'], $rij['date_of_birth'], (string) $rij['nationality'], (string) $rij['social_in'], (string) $rij['social_x'], (string) $rij['description']);
            array_push($list, $creator);
        }
        return $list;
    }

    public function getAllSortedByAmountOfStarredin(): array
    {
        $sql = "select p.creator_id, p.name, p.alias, p.date_of_birth, p.nationality, p.social_in, p.social_x, p.description, COUNT(vp.creator_id) AS occurrences
        FROM creators p
        LEFT JOIN videocreators vp ON p.creator_id = vp.creator_id
        where p.creator_id != 0 and p.creator_id != 423 and p.creator_id != 424
        GROUP BY p.creator_id, p.name
        ORDER BY occurrences DESC;";
        $resultSet = $this->dbh->query($sql);
        $list = array();
        foreach ($resultSet as $rij) {
            $creator = new Creator((int) $rij['creator_id'], (string) $rij['name'], (string) $rij['alias'], $rij['date_of_birth'], (string) $rij['nationality'], (string) $rij['social_in'], (string) $rij['social_x'], (string) $rij['description']);
            array_push($list, $creator);
        }
        return $list;
    }

    public function getCreatorById(int $creator_id): ?Creator
    {
        $sql = "select * from creators where creator_id = :creator_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':creator_id' => $creator_id));
        $resultSet = $stmt->fetch(PDO::FETCH_ASSOC);
        if ($resultSet) {
            $creator = new Creator((int) $resultSet['creator_id'], (string) $resultSet['name'], (string) $resultSet['alias'], $resultSet['date_of_birth'], (string) $resultSet['nationality'], (string) $resultSet['social_in'], (string) $resultSet['social_x'], (string) $resultSet['description']);
            return $creator;
        } else {
            return null;
        }

    }

    public function getCreatorByName(string $creator_name): ?Creator
    {
        $sql = "select * from creators where name = :name";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':name' => $creator_name));
        $resultSet = $stmt->fetch(PDO::FETCH_ASSOC);
        if ($resultSet) {
            $creator = new Creator((int) $resultSet['creator_id'], (string) $resultSet['name'], (string) $resultSet['alias'], $resultSet['date_of_birth'], (string) $resultSet['nationality'], (string) $resultSet['social_in'], (string) $resultSet['social_x'], (string) $resultSet['description']);
            return $creator;
        } else {
            return null;
        }

    }

    public function getCreatorsByVideoId(int $videoId): array
    {
        $sql = "select * from creators 
        right join videocreators 
        on creators.creator_id = videocreators.creator_id 
        where videocreators.video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $videoId));
        $resultSet = $stmt->fetchAll(PDO::FETCH_ASSOC);

        $list = array();
        foreach ($resultSet as $rij) {
            $creator = new Creator((int) $rij['creator_id'], (string) $rij['name'], (string) $rij['alias'], $rij['date_of_birth'], (string) $rij['nationality'], (string) $rij['social_in'], (string) $rij['social_x'], (string) $rij['description']);
            array_push($list, $creator);
        }

        return $list;
    }

    public function addCreator(string $name, string $alias, $dateOfBirth, string $nationality, string $social_in, string $social_x, string $description): int
    {
        //Prevent empty strings from being inserted in the database
        if ($dateOfBirth == '') {
            $dateOfBirth = null;
        }
        if ($alias == '') {
            $alias = null;
        } else {
            $alias = ucwords(strtolower($alias));
        }
        if ($nationality == '') {
            $nationality = null;
        } else {
            $nationality = ucfirst(strtolower($nationality));
        }
        if ($social_in == '') {
            $social_in = null;
        }
        if ($social_x == '') {
            $social_x = null;
        }
        if ($description == '') {
            $description = null;
        }


        // Add creator to database, without ID because it's auto increment
        $sql = "insert into creators (name, alias, date_of_birth, nationality, social_in, social_x, description) values (:name, :alias, :date_of_birth, :nationality, :social_in, :social_x, :description)";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':name' => ucwords(strtolower($name)), ':alias' => $alias, ':date_of_birth' => $dateOfBirth, ':nationality' => $nationality, ':social_in' => $social_in, ':social_x' => $social_x, ':description' => $description));
        $creator_id = intval($this->dbh->lastInsertId());
        return $creator_id;
    }

    public function addCreatorToVideo(Creator $creator, Video $video)
    {
        $sql = "insert into videocreators (video_id, creator_id) values (:video_id, :creator_id)";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $video->getId(), ':creator_id' => $creator->getId()));
    }

    public function removeCreatorFromVideo(int $creatorId, int $videoId)
    {
        $sql = "delete from videocreators where video_id = :video_id and creator_id = :creator_id;";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $videoId, ':creator_id' => $creatorId));
    }

    public function removeAllCreatorsFromVideo(Video $video)
    {
        $sql = "delete from videocreators where video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $video->getId()));
    }

    public function deleteCreator(Creator $creator)
    {
        //Delete creator from creators table
        $sql = "delete from creators where creator_id = :creator_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':creator_id' => $creator->getId()));
    }

    public function getAmountStarredIn(Creator $creator): int
    {
        $sql = "select COUNT(creator_id) AS total_occurrences FROM videocreators where creator_id = :creator_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':creator_id' => $creator->getId()));
        $resultSet = $stmt->fetch(PDO::FETCH_ASSOC);
        return $resultSet['total_occurrences'];
    }

    public function checkIfVideoAlreadyHasCreator(Creator $creator, int $video_id): bool
    {
        $sql = "select * from videocreators where creator_id = :creator_id and video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':creator_id' => $creator->getId(), ':video_id' => $video_id));
        $resultSet = $stmt->fetchAll(PDO::FETCH_ASSOC);

        if (count($resultSet) > 0) {
            return true;
        } else {
            return false;
        }
    }

    public function getAllVideosByCreator(Creator $creator): array
    {
        $sql = "
        select * from videocreators 
        join videos on videocreators.video_id = videos.video_id 
        where creator_id = " . $creator->getId();
        $resultSet = $this->dbh->query($sql);
        $list_videos = array();

        foreach ($resultSet as $row) {
            $video = new Video((int) $row['video_id'], (string) $row['filename'], (string) $row['extension'], new DateTime($row['date_added']), null, (int) $row['score'], (string) $row['description'], null, (int) $row['views'], (string) $row['title'], (string) $row['duration'], (int) $row['filesize_kB'], (int) $row['uploaded_by']);
            array_push($list_videos, $video);
        }

        return $list_videos;
    }

    public function getLatestVideosByCreator(Creator $creator): array
    {
        $sql = "select videos.* from videos
        join videocreators
        on videos.video_id = videocreators.video_id
        join creators
        on videocreators.creator_id = creators.creator_id
        where creators.creator_id = " . $creator->getId() . "
        order by videos.date_added desc
        limit 5;";

        $resultSet = $this->dbh->query($sql);
        $list_videos = array();

        foreach ($resultSet as $row) {
            $video = new Video((int) $row['video_id'], (string) $row['filename'], (string) $row['extension'], new DateTime($row['date_added']), null, (int) $row['score'], (string) $row['description'], null, (int) $row['views'], (string) $row['title'], (string) $row['duration'], (int) $row['filesize_kB'], (int) $row['uploaded_by']);
            array_push($list_videos, $video);
        }

        return $list_videos;
    }

    public function getCreatorsFavoriteCategory(Creator $creator, int $limit = 5)
    {
        //step 1: get every video from this creator
        $sql = "select
        subquery.tag_id,
        subquery.tag_occurrences
        FROM (
        SELECT
            vt.tag_id,
            COUNT(*) AS tag_occurrences
        FROM
            creators p
            JOIN videocreators vp ON p.creator_id = vp.creator_id
            JOIN videos v ON vp.video_id = v.video_id
            JOIN videotags vt ON v.video_id = vt.video_id
        WHERE
            p.creator_id = :creator_id
        GROUP BY
            vt.tag_id
        ORDER BY
            tag_occurrences DESC
        LIMIT " . $limit . " 
        ) AS subquery
        ORDER BY
        subquery.tag_occurrences ASC;";

        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':creator_id' => $creator->getId()));
        $resultSet = $stmt->fetchAll(PDO::FETCH_ASSOC);

        $arr_top_tags = array();
        $tagSvc = new TagService();
        foreach ($resultSet as $row) {
            $tag = $tagSvc->getTagById($row['tag_id']);
            array_push($arr_top_tags, $tag);
        }

        return $arr_top_tags;

    }

    public function updateCreator(Creator $creator)
    {
        //allow values to be nullable
        $creator_alias = ($creator->getAlias() !== '') ? $creator->getAlias() : null;
        $creator_dob = ($creator->getDateOfBirth() !== '') ? $creator->getDateOfBirth() : null;
        $creator_nationality = ($creator->getNationality() !== '') ? $creator->getNationality() : null;
        $creator_in = ($creator->getSocialIn() !== '') ? $creator->getSocialIn() : null;
        $creator_x = ($creator->getSocialX() !== '') ? $creator->getSocialX() : null;
        $creator_description = ($creator->getDescription() !== '') ? $creator->getDescription() : null;

        $sql = "update creators set name = :name, alias = :alias, date_of_birth = :date_of_birth, nationality = :nationality, social_in = :social_in, social_x = :social_x, description = :description where creator_id = :creator_id";

        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(
            ':name' => $creator->getName(), 
            ':alias' => $creator_alias, 
            ':date_of_birth' => $creator_dob, 
            ':nationality' => $creator_nationality, 
            ':social_in' => $creator_in, 
            ':social_x' => $creator_x, 
            ':description' => $creator_description, 
            ':creator_id' => $creator->getId()));

    }
}
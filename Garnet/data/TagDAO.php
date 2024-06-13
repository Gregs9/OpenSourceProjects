<?php
declare(strict_types=1);
require_once ('data/autoloader.php');

class TagDAO
{

    protected $dbh;

    function __construct() {
        $this->dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
    }
    
    function __destruct() {
        $this->dbh = null;
    }

    public function getAllTags(): array
    {
        $sql = "select * from tags order by tag_name asc";
        $resultSet = $this->dbh->query($sql);
        $list = array();
        foreach ($resultSet as $row) {
            $tag = new Tag((int) $row['tag_id'], (string) $row['tag_name'], (int) $row['weight'], (string) $row['description'], new DateTime($row['date_added']));
            array_push($list, $tag);
        }

        return $list;
    }

    public function getAllPopularTags(int $limit): array
    {
        $sql = 'SELECT 
        vt.tag_id, 
        t.tag_name, 
        t.weight, 
        t.description, 
        t.date_added,
        COUNT(*) AS tag_count
    FROM (
        SELECT video_id
        FROM log
        WHERE action = "View"
          AND timestamp >= CURDATE() - INTERVAL 1 MONTH
    ) AS recentviewlogs
    JOIN videotags vt ON recentviewlogs.video_id = vt.video_id
    JOIN tags t ON vt.tag_id = t.tag_id
    GROUP BY vt.tag_id, t.tag_name, t.weight, t.description, t.date_added
    ORDER BY tag_count DESC
    LIMIT ' . $limit;

        $resultSet = $this->dbh->query($sql);
        $list = array();
        foreach ($resultSet as $row) {
            $tag = new Tag((int) $row['tag_id'], (string) $row['tag_name'], (int) $row['weight'], (string) $row['description'], new DateTime($row['date_added']));
            array_push($list, $tag);
        }

        return $list;
    }

       public function getAllRecommendedTags(int $limit, User $user): array
    {
        $sql = 'SELECT 
        vt.tag_id, 
        t.tag_name, 
        t.weight, 
        t.description, 
        t.date_added,
        COUNT(*) AS tag_count
    FROM (
        SELECT video_id
        FROM log
        WHERE action = "View"
          AND user_id = ' . $user->getId() . '
          AND timestamp >= CURDATE() - INTERVAL 1 MONTH
    ) AS recentviewlogs
    JOIN videotags vt ON recentviewlogs.video_id = vt.video_id
    JOIN tags t ON vt.tag_id = t.tag_id
    GROUP BY vt.tag_id, t.tag_name, t.weight, t.description, t.date_added
    ORDER BY tag_count DESC
    LIMIT ' . $limit;


        $resultSet = $this->dbh->query($sql);
        $list = array();
        foreach ($resultSet as $row) {
            $tag = new Tag((int) $row['tag_id'], (string) $row['tag_name'], (int) $row['weight'], (string) $row['description'], new DateTime($row['date_added']));
            array_push($list, $tag);
        }

        return $list;
    }

    public function getTagOccurences(): array
    {
        $sql = 'SELECT tag_id, COUNT(*) AS occurrence_count
        FROM videotags
        GROUP BY tag_id
        ORDER BY occurrence_count DESC;';


        $resultSet = $this->dbh->query($sql);
        $tagOccurrences = [];

        foreach ($resultSet as $row) {
            if ($row['occurrence_count'] !== NULL) {
                $tagOccurrences[$row['tag_id']] = $row['occurrence_count'];
            }
        }

        return $tagOccurrences;
    }
    public function getTagByName(string $tag_name): ?Tag
    {
        $sql = "select * from tags";

        $resultSet = $this->dbh->query($sql);
        foreach ($resultSet as $rij) {
            if (strtolower($tag_name) == strtolower($rij['tag_name'])) {
                $tag = new Tag((int) $rij['tag_id'], (string) $rij['tag_name'], (int) $rij['weight'], (string) $rij['description'], new DateTime($rij['date_added']));
                return $tag;
            }
        }
        return null;
    }

    public function addPrimaryTag(Tag $tag)
    {
        $now = new DateTime('now');
        // Add user to database, without ID because it's auto increment
        $sql = "insert into tags (tag_name, weight, description, date_added) values (:tag_name, :weight, :description, :date_added)";

        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':tag_name' => $tag->getName(), ':weight' => $tag->getWeight(), ':description' => $tag->getDescription(), ':date_added' => $now->format('Y-m-d H:i:s')));
    }

    public function removePrimaryTag(Tag $tag)
    {
        $sql = "delete FROM videotags WHERE tag_id=" . $tag->getId();
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute();

        $sql = "delete FROM tags WHERE tag_id=" . $tag->getId();
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute();
    }

    public function getAllTagsFromVideo(Video $video): array
    {
        $sql = "select * from videotags left join tags on videotags.tag_id = tags.tag_id where video_id = " . $video->getId();
        $resultSet = $this->dbh->query($sql);
        $list_tags = array();
        foreach ($resultSet as $row) {
            $dateTime = datetime::createfromformat('Y-m-d H:i:s', $row['date_added']);
            $tag = new Tag((int) $row['tag_id'], (string) $row['tag_name'], (int) $row['weight'], (string) $row['description'], $dateTime);
            array_push($list_tags, $tag);
        }

        return $list_tags;
    }
    public function getAllTagsFromVideoByVideoId(int $video_id): array
    {
        $sql = "select * from videotags left join tags on videotags.tag_id = tags.tag_id where video_id = " . $video_id . " order by tag_name asc";
        $resultSet = $this->dbh->query($sql);
        $list_tags = array();
        foreach ($resultSet as $row) {
            $dateTime = datetime::createfromformat('Y-m-d H:i:s', $row['date_added']);
            $tag = new Tag((int) $row['tag_id'], (string) $row['tag_name'], (int) $row['weight'], (string) $row['description'], $dateTime);
            array_push($list_tags, $tag);
        }

        return $list_tags;
    }

    public function removeAllTagsFromVideo(Video $video)
    {
        $sql = "delete from videotags where video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $video->getId()));
    }

    public function getAmountOfVideosWithTag(Tag $tag): int
    {
        $tag_id = $tag->getId();
        $sql = "select COUNT(*) AS tag_occurrences FROM videotags WHERE tag_id = :tag_id;";
        $stmt = $this->dbh->prepare($sql);
        $stmt->bindParam(":tag_id", $tag_id);
        $stmt->execute();
        $rij = $stmt->fetch(PDO::FETCH_ASSOC);
        return intval($rij['tag_occurrences']);
    }


    public function updateTag(Tag $tag)
    {
        $sql = "update tags set tag_name = :tag_name, weight = :weight, description = :description, date_added = :date_added where tag_id = :tag_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':tag_name' => $tag->getName(), ':weight' => $tag->getWeight(), ':description' => $tag->getDescription(), ':date_added' => $tag->getDateAdded(), ':tag_id' => $tag->getId()));
    }


}
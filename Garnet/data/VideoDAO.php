<?php
declare(strict_types=1);
require_once ('data/autoloader.php');

class VideoDAO
{

    protected $dbh;

    function __construct()
    {
        try {
            $this->dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD, array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8mb4"));
        } catch (Exception $e) {
            $_SESSION['feedback'] = json_encode(['message' => 'There was an error connecting to the database.', 'type' => 'error']);
            header('location: login');
            exit(0);
        }
    }

    function __destruct()
    {
        $this->dbh = null;
    }

    //Get all videos, sort by id by default
    public function getAllVideos(): array
    {
        //get all videos from database
        $sql = "select * from videos order by date_added desc";
        $sql = "select * from videos order by video_id asc";
        $resultSet = $this->dbh->query($sql);
        $list_videos = array();

        //for every video found, get array with all tags of this video
        $tagDAO = new TagDAO();

        foreach ($resultSet as $rij) {

            //get all tags from this video as an array
            $arr_video_tags = $tagDAO->getAllTagsFromVideoByVideoId(intval($rij['video_id']));

            $video = new Video((int) $rij['video_id'], (string) $rij['filename'], (string) $rij['extension'], new DateTime($rij['date_added']), (int) $rij['score'], (string) $rij['description'], (array) $arr_video_tags, (int) $rij['views'], (string) $rij['title'], (string) $rij['duration'], (int) $rij['filesize_kB'], (int) $rij['uploaded_by']);
            array_push($list_videos, $video);
        }

        return $list_videos;
    }

    public function getVideosWithUnknownCreator(): array
    {
        //get all videos from database
        $sql = "select * from videos
                join videocreators
                on videos.video_id = videocreators.video_id
                where videocreators.creator_id = 0
                order by date_added desc";
        $resultSet = $this->dbh->query($sql);
        $list_videos = array();

        //for every video found, get array with all tags of this video
        $tagDAO = new TagDAO();

        foreach ($resultSet as $rij) {

            //get all tags from this video as an array
            $arr_video_tags = $tagDAO->getAllTagsFromVideoByVideoId(intval($rij['video_id']));

            $video = new Video((int) $rij['video_id'], (string) $rij['filename'], (string) $rij['extension'], new DateTime($rij['date_added']), (int) $rij['score'], (string) $rij['description'], (array) $arr_video_tags, (int) $rij['views'], (string) $rij['title'], (string) $rij['duration'], (int) $rij['filesize_kB'], (int) $rij['uploaded_by']);
            array_push($list_videos, $video);
        }


        return $list_videos;
    }

    public function getVideoById(int $video_id): ?Video
    {
        $sql = "select * from videos where video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->bindParam("video_id", $video_id);
        $stmt->execute();
        $rij = $stmt->fetch(PDO::FETCH_ASSOC);

        if ($rij == false) {
            return null;
        } else {
            //get all tags from this video as an array
            $tagDAO = new TagDAO();
            $arr_video_tags = $tagDAO->getAllTagsFromVideoByVideoId(intval($rij['video_id']));

            $video = new Video((int) $rij['video_id'], (string) $rij['filename'], (string) $rij['extension'], new DateTime($rij['date_added']), (int) $rij['score'], (string) $rij['description'], (array) $arr_video_tags, (int) $rij['views'], (string) $rij['title'], (string) $rij['duration'], (int) $rij['filesize_kB'], (int) $rij['uploaded_by']);
            return $video;
        }
    }

    public function addScore(Video $video)
    {
        $sql = "update videos set score = score + 1 where video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $video->getId()));
    }

    public function addView(Video $video)
    {
        $sql = "update videos set views = views + 1 where video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $video->getId()));
    }

    public function removeView(Video $video)
    {
        $sql = "update videos set views = views - 1 where video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $video->getId()));
    }

    public function addTagToVideo(Video $video, Tag $requested_tag)
    {
        $sql = "insert into videotags (video_id, tag_id) values (:video_id, :tag_id)";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $video->getId(), ':tag_id' => $requested_tag->getId()));
    }

    public function removeTagFromVideo(Video $video, Tag $tag)
    {
        $sql = "delete FROM videotags WHERE video_id = " . $video->getId() . " and tag_id = " . $tag->getId();
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute();
    }

    public function addVideo(string $filename, int $score, string $extension, string $description, int $views, string $title, string $duration, int $filesize, int $uploaded_by): int
    {
        $now = new DateTime('now');
        $sql = "insert into videos (filename, date_added, score, extension, description, views, title, duration, filesize_kB, uploaded_by) values (:filename, :date_added, :score, :extension, :description, :views, :title, :duration, :filesize_kB, :uploaded_by)";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':filename' => $filename, ':date_added' => $now->format('Y-m-d H:i:s'), ':score' => $score, ':extension' => $extension, ':description' => $description, ':views' => $views, ':title' => $title, ':duration' => $duration, ':filesize_kB' => $filesize, ':uploaded_by' => $uploaded_by));	
        $video_id = intval($this->dbh->lastInsertId());
        return $video_id;
    }

    public function updateVideo(Video $video)
    {   
        $sql = "update videos set filename = :filename, date_added = :date_added, score = :score, extension = :extension, description = :description, views = :views, title = :title, duration = :duration, filesize_kB = :filesize_kB, uploaded_by = :uploaded_by where video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':filename' => $video->getFilename(), ':date_added' => $video->getDateAdded()->format('Y/m/d H:i:s'), ':score' => $video->getScore(), ':extension' => $video->getExtension(), ':description' => $video->getDescription(), ':views' => $video->getViews(), ':title' => $video->getTitle(), ':duration' => $video->getDuration(), ':filesize_kB' => $video->getFileSize(), ':uploaded_by' => $video->getUploadedBy(), ':video_id' => $video->getId()));
    }

    public function deleteVideo(Video $video)
    {
        $sql = "delete from videos where video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':video_id' => $video->getId()));
    }

    public function getSimilarVideos(Video $video): array
    {
        $sql = "select
        v2.*,
        SUM(t.weight) AS total_weight_of_common_tags
        FROM
        videos v1
        JOIN videotags vt1 ON v1.video_id = vt1.video_id
        JOIN videotags vt2 ON vt1.tag_id = vt2.tag_id
        JOIN videos v2 ON vt2.video_id = v2.video_id
        JOIN tags t ON vt2.tag_id = t.tag_id
        WHERE
        v1.video_id = :video_id
        AND v2.video_id != :video_id
        GROUP BY
        v2.video_id, v2.filename
        ORDER BY
        total_weight_of_common_tags DESC
        LIMIT 10;";
        $stmt = $this->dbh->prepare($sql);
        $video_id = $video->getId();
        $stmt->bindParam("video_id", $video_id);
        $stmt->execute();
        $resultSet = $stmt->fetchAll(PDO::FETCH_ASSOC);

        $arr_recommended_videos = array();

        foreach ($resultSet as $rij) {
            $tagDAO = new TagDAO();
            $arr_video_tags = $tagDAO->getAllTagsFromVideoByVideoId(intval($rij['video_id']));
            $video = new Video((int) $rij['video_id'], (string) $rij['filename'], (string) $rij['extension'], new DateTime($rij['date_added']), (int) $rij['score'], (string) $rij['description'], (array) $arr_video_tags, (int) $rij['views'], (string) $rij['title'], (string) $rij['duration'], (int) $rij['filesize_kB'], (int) $rij['uploaded_by']);
            array_push($arr_recommended_videos, $video);
        }

        return $arr_recommended_videos;
    }

    public function getRecommendedVideos(int $user_id): ?array
    {
        //get the user's favorite video from last 7 days
        //This is a calculation based on how many times it was viewed and scored
        $sql = 'select videos.*, SUM(
            CASE WHEN action = "View" THEN 1
                 WHEN action = "Score" THEN 5
                 ELSE 0
            END
        ) AS score
        FROM log
        JOIN videos
        ON log.video_id = videos.video_id
        WHERE user_id = :user_id
          AND action IN ("View", "Score")
          AND TIMESTAMPDIFF(DAY, timestamp, NOW()) < 7
        GROUP BY video_id
        ORDER BY score DESC
        LIMIT 1;';

        $stmt = $this->dbh->prepare($sql);
        $stmt->bindParam("user_id", $user_id);
        $stmt->execute();
        $result = $stmt->fetch(PDO::FETCH_ASSOC);
        $tagDAO = new TagDAO();
        //get all tags from this video as an array
        if ($result) {
            $arr_video_tags = $tagDAO->getAllTagsFromVideoByVideoId(intval($result['video_id']));
            $video = new Video((int) $result['video_id'], (string) $result['filename'], (string) $result['extension'], new DateTime($result['date_added']), (int) $result['score'], (string) $result['description'], (array) $arr_video_tags, (int) $result['views'], (string) $result['title'], (string) $result['duration'], (int) $result['filesize_kB'], (int) $result['uploaded_by']);
            return $this->getSimilarVideos($video);
        } else {
            return null;
        }

    }


    public function getRandomVideoId(): int
    {
        $sql = 'select video_id FROM videos ORDER BY RAND() LIMIT 1';
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute();
        $result = $stmt->fetch(PDO::FETCH_ASSOC);
        return intval($result['video_id']);
    }

    public function getVideoCreatorsAsString(int $video_id): ?string
    {
        $sql = "select creators.name from videos
        left join videocreators
        on videos.video_id = videocreators.video_id
        left join creators
        on videocreators.creator_id = creators.creator_id
        where videos.video_id = " . $video_id;
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute();
        $resultSet = $stmt->fetchAll(PDO::FETCH_ASSOC);

        if (count($resultSet) > 0) {
            $stringBuilder = '';
            foreach ($resultSet as $row) {
                $stringBuilder .= ($row['name'] . ';');
            }
            return rtrim($stringBuilder, ";");

        } else {
            return null;
        }
    }

    public function getShort(): Video
    {
        $sql = 'SELECT videos.* FROM videos
        join videotags on videos.video_id = videotags.video_id
        WHERE videotags.tag_id = 127 #vertical recording tag_id
        and TIME_TO_SEC(duration) <= 30
        order by rand()
        limit 1';

        $stmt = $this->dbh->prepare($sql);
        $stmt->execute();
        $rij = $stmt->fetch(PDO::FETCH_ASSOC);

        $tagDAO = new TagDAO();
        $arr_video_tags = $tagDAO->getAllTagsFromVideoByVideoId(intval($rij['video_id']));
        $video = new Video((int) $rij['video_id'], (string) $rij['filename'], (string) $rij['extension'], new DateTime($rij['date_added']), (int) $rij['score'], (string) $rij['description'], (array) $arr_video_tags, (int) $rij['views'], (string) $rij['title'], (string) $rij['duration'], (int) $rij['filesize_kB'], (int) $rij['uploaded_by']);

        return $video;
    }
}
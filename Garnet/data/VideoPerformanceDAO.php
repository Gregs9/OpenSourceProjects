<?php
declare(strict_types=1);
require_once ('data/autoloader.php');

class VideoPerformanceDAO
{

    protected $dbh;

    public function __construct()
    {
        $this->dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
    }

    function __destruct()
    {
        $this->dbh = null;
    }

    public function getAllVideosPerPage(int $page_no, int $results_per_page, string $order_by): array
    {
        $start_from = ($page_no - 1) * $results_per_page;
        $sql = 'select * from videos order by ' . $order_by . ' LIMIT ' . $start_from . ', ' . $results_per_page;
        $resultSet = $this->dbh->query($sql);
        $list_videos = array();

        //for every video found, get array with all tags of this video
        $tagDAO = new TagDAO();

        foreach ($resultSet as $rij) {
            $arr_video_tags = $tagDAO->getAllTagsFromVideoByVideoId(intval($rij['video_id']));
            $firstAppeared = array_key_exists('first_appeared', $rij) && !is_null($rij['first_appeared']) ? new DateTime($rij['first_appeared']) : null;
            $video = new Video((int) $rij['video_id'], (string) $rij['filename'], (string) $rij['extension'], new DateTime($rij['date_added']), $firstAppeared, (int) $rij['score'], (string) $rij['description'], (array) $arr_video_tags, (int) $rij['views'], (string) $rij['title'], (string) $rij['duration'], (int) $rij['filesize_kB'], (int) $rij['uploaded_by']);
            array_push($list_videos, $video);
        }

        return $list_videos;
    }

    public function getTotalRecords(): int
    {
        $sql = 'select count(video_id) as total from videos';
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute();
        $rij = $stmt->fetch(PDO::FETCH_ASSOC);
        return intval($rij["total"]);
    }






    //IT CRASHES WHEN THE ARR_TAGS IS EMPTY, PROBABLY BECAUSE THE WRONG METHOD IS CALLED, ADD A CHECK FOR WHEN ARR IS EMPTY!
    public function getTotalRecordsPerPageWithFilter(array $arr_tags, string $query, string $excludeShorts): int
    {

        $sql = 'select videos.video_id
            from videos
            right join videotags
            on videos.video_id = videotags.video_id
            right join tags
            on videotags.tag_id = tags.tag_id
            right join videocreators
            on videos.video_id = videocreators.video_id
            right join creators
            on videocreators.creator_id = creators.creator_id
            right join users
            on videos.uploaded_by = users.id

            WHERE (
                LOWER(videos.description) LIKE LOWER("%' . $query . '%") OR
                LOWER(videos.title) LIKE LOWER("%' . $query . '%") OR
                LOWER(videos.video_id) LIKE LOWER("%' . $query . '%") OR
                LOWER(users.username) LIKE LOWER("%' . $query . '%") OR
                LOWER(tags.tag_name) LIKE LOWER("%' . $query . '%") OR
                LOWER(tags.description) LIKE LOWER("%' . $query . '%") OR
                LOWER(creators.name) LIKE LOWER("%' . $query . '%") OR
                LOWER(creators.alias) LIKE LOWER("%' . $query . '%") OR
                LOWER(creators.nationality) LIKE LOWER("%' . $query . '%") OR
                LOWER(creators.description) LIKE LOWER("%' . $query . '%")
                ) and videos.video_id is not null ';

        if ($excludeShorts == 'true') {
            $sql .= ' AND videos.video_id NOT IN (
                SELECT DISTINCT videotags.video_id
                FROM videos right join videotags on videos.video_id = videotags.video_id
                WHERE videotags.tag_id = 127 
                and time_to_sec(videos.duration) <= 30
            ) ';
        }

        if (count($arr_tags) > 0) {
            $sql .= 'and tags.tag_name IN (';


            foreach ($arr_tags as $requested_tag) {
                $sql .= '"' . $requested_tag->getName() . '", ';
            }

            $sql = substr($sql, 0, -2);
            $sql .= ') ';
        }

        $sql .= 'group by videos.video_id';
        if (count($arr_tags) > 0) {
            $sql .= ' HAVING COUNT(DISTINCT tags.tag_id) = ' . count($arr_tags);
        }
        try {
            $stmt = $this->dbh->prepare($sql);
            $stmt->execute();
        } catch (PDOException $e) {
            echo $e->getMessage() . '<br><br>';
            echo $sql;

        }
        $result = $stmt->fetchAll(PDO::FETCH_ASSOC);

        return count($result);
    }


    public function getAllVideosPerPageWithFilter(int $page, int $results_per_page, array $arr_tags, string $query = '', string $order_by, string $excludeShorts)
    {
        $start_from = ($page - 1) * $results_per_page;

        try {
            $sql = 'select 
            videos.*,
            users.username,
            tags.*,
            creators.*
            from videos
            right join videotags
            on videos.video_id = videotags.video_id
            right join tags
            on videotags.tag_id = tags.tag_id
            right join videocreators
            on videos.video_id = videocreators.video_id
            right join creators
            on videocreators.creator_id = creators.creator_id
            right join users
            on videos.uploaded_by = users.id

            WHERE (
                LOWER(videos.description) LIKE LOWER("%' . $query . '%") OR
                LOWER(videos.title) LIKE LOWER("%' . $query . '%") OR
                LOWER(videos.video_id) LIKE LOWER("%' . $query . '%") OR
                LOWER(users.username) LIKE LOWER("%' . $query . '%") OR
                LOWER(tags.tag_name) LIKE LOWER("%' . $query . '%") OR
                LOWER(tags.description) LIKE LOWER("%' . $query . '%") OR
                LOWER(creators.name) LIKE LOWER("%' . $query . '%") OR
                LOWER(creators.alias) LIKE LOWER("%' . $query . '%") OR
                LOWER(creators.nationality) LIKE LOWER("%' . $query . '%") OR
                LOWER(creators.description) LIKE LOWER("%' . $query . '%")
                ) and videos.video_id is not null ';

            if ($excludeShorts == 'true') {
                $sql .= ' AND videos.video_id NOT IN (
    SELECT DISTINCT videotags.video_id
    FROM videos right join videotags on videos.video_id = videotags.video_id
    WHERE videotags.tag_id = 127 
    and time_to_sec(videos.duration) <= 30
) ';
            }

            if (count($arr_tags) > 0) {
                $sql .= ' and tags.tag_name IN (';


                foreach ($arr_tags as $requested_tag) {
                    $sql .= '"' . $requested_tag->getName() . '", ';
                }

                $sql = substr($sql, 0, -2);
                $sql .= ') ';
            }


            $sql .= 'group by videos.video_id';
            if (count($arr_tags) > 0) {
                $sql .= ' HAVING COUNT(DISTINCT tags.tag_id) = ' . count($arr_tags);
            }
            $sql .= ' order by videos.' . $order_by;
            $sql .= ' LIMIT ' . $start_from . ', ' . $results_per_page;

            $resultSet = $this->dbh->query($sql);

        } catch (PDOException $e) {
            echo $e->getMessage() . '<br><br>' . $sql;
        }

        $list_videos = array();

        //for every video found, get array with all tags of this video
        $tagDAO = new TagDAO();

        foreach ($resultSet as $rij) {


            //get all tags from this video as an array
            $arr_video_tags = $tagDAO->getAllTagsFromVideoByVideoId(intval($rij['video_id']));

            $firstAppeared = array_key_exists('first_appeared', $rij) && !is_null($rij['first_appeared']) ? new DateTime($rij['first_appeared']) : null;


            $video = new Video((int) $rij['video_id'], (string) $rij['filename'], (string) $rij['extension'], new DateTime($rij['date_added']), $firstAppeared, (int) $rij['score'], (string) $rij['description'], (array) $arr_video_tags, (int) $rij['views'], (string) $rij['title'], (string) $rij['duration'], (int) $rij['filesize_kB'], (int) $rij['uploaded_by']);

            array_push($list_videos, $video);

        }
        return $list_videos;
    }


}
<?php
declare(strict_types=1);
require_once ('data/autoloader.php');

class CreatorPerformanceDAO
{

    protected $dbh;

    function __construct()
    {
        $this->dbh = new PDO(DBConfig::$DB_CONNSTRING, DBConfig::$DB_USERNAME, DBConfig::$DB_PASSWORD);
    }

    function __destruct()
    {
        $this->dbh = null;
    }

    public function getTotalRecords(string $query): int
    {
        $sql = 'select count(distinct p.creator_id) as total from creators p 
        where 
        (
        LOWER(p.name) LIKE LOWER("%' . $query . '%") OR 
        LOWER(p.alias) LIKE LOWER("%' . $query . '%")
        ) 
        
        and creator_id != 0 and 
        creator_id != 423 and 
        creator_id != 424 ';

        $stmt = $this->dbh->prepare($sql);
        $stmt->execute();
        $rij = $stmt->fetch(PDO::FETCH_ASSOC);
        return intval($rij["total"]);
    }

    public function getAllCreatorsPerPage(int $page_no, int $results_per_page, string $order_by, string $query): array
    {
        $start_from = ($page_no - 1) * $results_per_page;

        $sql = '
        select creators.*,
        SUM(videos.views) AS views,
        SUM(videos.score) AS score,
        COUNT(videocreators.creator_id) AS occurrences
        from creators
        join videocreators on creators.creator_id = videocreators.creator_id
        join videos on videocreators.video_id = videos.video_id
        where (
        LOWER(creators.name) LIKE LOWER("%' . $query .'%") 
        OR LOWER(creators.alias) LIKE LOWER("%' . $query . '%")
        ) 
        and creators.creator_id != 0 
        and creators.creator_id != 423 
        and creators.creator_id != 424 
        group by creators.creator_id' .
        ' order by ' . $order_by . '
        LIMIT ' . $start_from . ', ' . $results_per_page;

        $resultSet = $this->dbh->query($sql);
        $list = array();
        foreach ($resultSet as $rij) {
            $creator = new Creator((int) $rij['creator_id'], (string) $rij['name'], (string) $rij['alias'], $rij['date_of_birth'], (string) $rij['nationality'], (string) $rij['social_in'], (string) $rij['social_x'], (string) $rij['description']);
            array_push($list, $creator);
        }
        return $list;
    }
}
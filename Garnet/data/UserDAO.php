<?php
declare(strict_types=1);
require_once ('data/autoloader.php');
class UserDAO
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


    public function getAll(): array
    {
        $sql = "select * from users";
        $resultSet = $this->dbh->query($sql);
        $list = array();
        foreach ($resultSet as $rij) {
            $creation = array_key_exists('creation', $rij) && !is_null($rij['creation']) ? new DateTime($rij['creation']) : null;
            $last_score = array_key_exists('last_added_score', $rij) && !is_null($rij['last_added_score']) ? new DateTime($rij['last_added_score']) : null;
            $user = new User((int) $rij['id'], (string) $rij['username'], (string) $rij['password'], (string) $rij['role'], $creation, $rij['status'], $last_score);
            array_push($list, $user);
        }

        return $list;
    }

    public function getUserIdNameList(): array
    {
        $sql = 'select id, username from users';
        $resultSet = $this->dbh->query($sql);
        $arr_userIdsNames = [];
        foreach ($resultSet as $row) {
            $arr_userIdsNames[$row['id']] = $row['username'];
        }

        return $arr_userIdsNames;
    }

    public function addUser($username, $password)
    {
        // Add user to database, without ID because it's auto increment
        $sql = "insert into users (username, password, role, creation, status) values (:username, :password, :role, :creation, :status)";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':username' => strtolower($username), ':password' => $password, ':role' => "user", ':creation' => date('Y-m-d H:i:s'), ':status' => 'active'));
    }

    public function validateUser(string $username, string $password): ?User
    {
        $lijst_gebruikers = $this->getAll();
        foreach ($lijst_gebruikers as $user) {
            if (($user->getUsername() == $username) && (password_verify($password, $user->getPassword()))) {
                return $user;
            }
        }
        return null;
    }

    public function blockUser(User $user)
    {
        $sql = "update users set status = :status where id = :id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':status' => 'blocked', ':id' => $user->getId()));
    }

    public function unblockUser(User $user)
    {
        $sql = "update users set status = :status where id = :id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':status' => 'active', ':id' => $user->getId()));
    }

    public function promoteUser(User $user)
    {
        $sql = "update users set role = :role where id = :id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':role' => 'admin', ':id' => $user->getId()));
    }

    public function demoteUser(User $user)
    {
        $sql = "update users set role = :role where id = :id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':role' => 'user', ':id' => $user->getId()));
    }

    public function removeUser(User $user)
    {
        //when deleting a user, get all their uploaded videos, and remove them through the videoDAO, otherwise they will stay on the server's storage.
        $users_uploaded_videos = $this->getUploadedVideos($user);

        $videoDAO = new VideoDAO;
        require ('components/DBNameSnippet.php');

        foreach ($users_uploaded_videos as $video) {

            //Create the to be deleted paths
            $video_path = $contentPath . '/Videos/' . $video->getFilename() . $video->getExtension();
            $thumbnail_path = $contentPath . '/Thumbnails/' . $video->getFilename() . '.webp';
            //1. DELETE VIDEO FROM CONTENT
            file_exists($video_path) ? unlink($video_path) : null;

            //2. DELETE VIDEO FROM THUMBNAILS
            file_exists($thumbnail_path) ? unlink($thumbnail_path) : null;

            $videoDAO->deleteVideo($video);
        }

        $sql = "delete FROM users WHERE id=" . $user->getId();
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute();
    }

    public function updateLastScore(User $user)
    {
        $sql = "update users set last_added_score = :last_added_score where id = :user_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':user_id' => $user->getId(), ':last_added_score' => date('Y-m-d H:i:s')));
    }

    public function favoriteCreator(User $user, Creator $creator)
    {
        $user_id = $user->getId();
        $creator_id = $creator->getId();

        $sql = "insert into userfavoritecreators (user_id, creator_id) values (:user_id, :creator_id)";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':user_id' => $user_id, ':creator_id' => $creator_id));
    }

    public function unfavoriteCreator(User $user, Creator $creator)
    {
        $sql = "delete from userfavoritecreators where user_id = :user_id and creator_id = :creator_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':user_id' => $user->getId(), ':creator_id' => $creator->getId()));
    }

    public function getFavoriteCreators(User $user): array
    {
        $sql = "select * from userfavoritecreators
        left join creators
        on userfavoritecreators.creator_id = creators.creator_id
        where user_id = " . $user->getId() . "
        order by creators.name asc";

        $resultSet = $this->dbh->query($sql);
        $list = array();
        foreach ($resultSet as $rij) {
            $creator = new Creator((int) $rij['creator_id'], (string) $rij['name'], (string) $rij['alias'], $rij['date_of_birth'], (string) $rij['nationality'], (string) $rij['social_in'], (string) $rij['social_x'], (string) $rij['description']);
            array_push($list, $creator);
        }
        return $list;

    }

    public function isCreatorFavorited(User $user, Creator $creator): bool
    {
        $user_id = $user->getId();
        $creator_id = $creator->getId();

        $sql = 'select * from userfavoritecreators
            where user_id = :user_id and
            creator_id = :creator_id';

        $stmt = $this->dbh->prepare($sql);
        $stmt->bindParam("user_id", $user_id);
        $stmt->bindParam("creator_id", $creator_id);
        $stmt->execute();
        $result = $stmt->fetch(PDO::FETCH_ASSOC);

        if ($result) {
            return true;
        }
        return false;
    }

    public function favoriteVideo(User $user, Video $video)
    {
        $sql = "insert into userfavoritevideos (user_id, video_id) values (:user_id, :video_id)";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':user_id' => $user->getId(), ':video_id' => $video->getId()));
    }

    public function unfavoriteVideo(User $user, Video $video)
    {
        $sql = "delete from userfavoritevideos where user_id = :user_id and video_id = :video_id";
        $stmt = $this->dbh->prepare($sql);
        $stmt->execute(array(':user_id' => $user->getId(), ':video_id' => $video->getId()));
    }

    public function getFavoriteVideos(User $user): array
    {
        $sql = "select * from userfavoritevideos
        left join videos
        on userfavoritevideos.video_id = videos.video_id
        where user_id = " . $user->getId() . "
        order by videos.date_added desc";

        $resultSet = $this->dbh->query($sql);
        $list_videos = array();

        foreach ($resultSet as $row) {
            $video = new Video((int) $row['video_id'], (string) $row['filename'], (string) $row['extension'], new DateTime($row['date_added']), null, (int) $row['score'], (string) $row['description'], null, (int) $row['views'], (string) $row['title'], (string) $row['duration'], (int) $row['filesize_kB'], (int) $row['uploaded_by']);
            array_push($list_videos, $video);
        }

        return $list_videos;
    }

    public function isVideoFavorited(User $user, Video $video): bool
    {
        $user_id = $user->getId();
        $video_id = $video->getId();

        $sql = 'select * from userfavoritevideos
            where user_id = :user_id and
            video_id = :video_id';

        $stmt = $this->dbh->prepare($sql);
        $stmt->bindParam("user_id", $user_id);
        $stmt->bindParam("video_id", $video_id);
        $stmt->execute();
        $result = $stmt->fetch(PDO::FETCH_ASSOC);

        if ($result) {
            return true;
        }
        return false;
    }

    public function getWatchHistory(User $user): array
    {
        $sql = "select log.timestamp, videos.* from log
        join videos on log.video_id = videos.video_id

        where action = 'View'
        and user_id = " . $user->getId() . "
        group by log.video_id
        order by log.timestamp desc
        
        limit 0, 500";

        $resultSet = $this->dbh->query($sql);
        $list_videos = array();

        foreach ($resultSet as $row) {
            $video = new Video((int) $row['video_id'], (string) $row['filename'], (string) $row['extension'], new DateTime($row['date_added']), null, (int) $row['score'], (string) $row['description'], null, (int) $row['views'], (string) $row['title'], (string) $row['duration'], (int) $row['filesize_kB'], (int) $row['uploaded_by']);
            $date = new DateTime($row["timestamp"]);
            array_push($list_videos, ["video" => $video, "date" => $date->format('Y-m-d')]);
        }

        return $list_videos;
    }

    public function getLatestScores(User $user): array
    {
        $sql = 'SELECT videos.* FROM log
        join videos on log.video_id = videos.video_id
        WHERE log.action = "Score"
        AND user_id = ' . $user->getId() . '
        order by log.timestamp desc
        LIMIT 0, 1000;';

        $resultSet = $this->dbh->query($sql);
        $list_videos = array();

        foreach ($resultSet as $row) {
            $video = new Video((int) $row['video_id'], (string) $row['filename'], (string) $row['extension'], new DateTime($row['date_added']), null, (int) $row['score'], (string) $row['description'], null, (int) $row['views'], (string) $row['title'], (string) $row['duration'], (int) $row['filesize_kB'], (int) $row['uploaded_by']);
            array_push($list_videos, $video);
        }

        return $list_videos;
    }

    public function getUploadedVideos(User $user): array
    {
        $sql = 'select * from videos where uploaded_by = ' . $user->getId();
        $resultSet = $this->dbh->query($sql);

        $list_videos = array();
        foreach ($resultSet as $row) {
            $video = new Video((int) $row['video_id'], (string) $row['filename'], (string) $row['extension'], new DateTime($row['date_added']), null, (int) $row['score'], (string) $row['description'], null, (int) $row['views'], (string) $row['title'], (string) $row['duration'], (int) $row['filesize_kB'], (int) $row['uploaded_by']);
            array_push($list_videos, $video);
        }
        return $list_videos;

    }
}
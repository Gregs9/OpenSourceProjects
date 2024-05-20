<?php
declare(strict_types=1);
require_once ('data/autoloader.php');



function validateCsrfToken($token)
{
    /*
    Token is currently hardcoded for simplicity, in a real scenario, I would store a user's session hash in the database.
    I would then generate a new hash in javascript, containing the user's session, a part of the (sensitive) data and a the timestamp of the request and mold this into a hash
    for optimal security. 
    */
    return $token == 'a19e6ab21ff4ecf98a288be53fbd9acf45bc190a8f0824bd690ad1c7c3a8d1b9';
}

//For adding a tag to a video -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'add_tag') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';

    /*
    if (!validateCsrfToken($csrfToken)) {
        http_response_code(403);
        echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
        exit;
    }
*/
    $tagSvc = new TagService();
    $videoSvc = new VideoService();
    $logSvc = new LogService();

    // Retrieve posted data
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    //get tag & video objects
    $tag = $tagSvc->getTagByName($postData['tag_name']);

    if (!$tag) {
        http_response_code(400);
        echo json_encode(['error' => $postData['tag_name'] . ' is not a valid tag.']);
        return;
    }

    //get video
    $video = $videoSvc->getVideoById(intval($postData['video_id']));

    //check if video already has this tag
    $video_tags = $video->getTags();
    foreach ($video_tags as $check_tag) {
        if (strtolower($check_tag->getName()) == strtolower($postData['tag_name'])) {
            http_response_code(400);
            echo json_encode(['error' => $postData['tag_name'] . ' is already added to this video.']);
            return;
        }
    }

    //add tag to video
    $videoSvc->addTagToVideo($tag, $video);

    //log event
    $logSvc->log(intval($postData['user_id']), 'Added tag', $video->getId());


    // Send response back to JavaScript
    http_response_code(200);
    echo json_encode(['message' => $postData['tag_name'] . ' added to video id ' . $postData['video_id']]);

}
//For removing a tag to a video -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'remove_tag') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    $tagSvc = new TagService();
    $videoSvc = new VideoService();
    $logSvc = new LogService();

    // Retrieve posted data
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    //get tag & video objects
    $tag = $tagSvc->getTagByName($postData['tag_name']);

    if (!$tag) {
        http_response_code(400);
        echo json_encode(['error' => $postData['tag_name'] . ' is not a valid tag.']);
        return;
    }

    $video = $videoSvc->getVideoById(intval($postData['video_id']));

    //check if tag is indeed part of this video
    $video_tags = $video->getTags();
    foreach ($video_tags as $check_tag) {
        if (strtolower($check_tag->getName()) == strtolower($postData['tag_name'])) {
            //remove tag to video
            $videoSvc->removeTagFromVideo($tag, $video);

            //log event
            $logSvc->log(intval($postData['user_id']), 'Removed tag', $video->getId());


            // Send response back to JavaScript
            http_response_code(200);
            echo json_encode(['message' => $postData['tag_name'] . ' removed from video id ' . $postData['video_id']]);
            return;
        }
    }
    http_response_code(400);
    echo json_encode(['error' => $postData['tag_name'] . ' is not added to this video.']);
    return;




}
//For displaying the score button if the user has not scored a video in the last 8 hours -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'get_last_score') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    //Retrieve user data
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    //get user object
    $userSvc = new UserService();
    $user = $userSvc->getUserById(intval($postData['user_id']));

    //check that it has at least been 8 hours
    $last_added_score = $user->getLastScore();
    if ($last_added_score) {

        $current_datetime = new DateTime();
        $interval = $current_datetime->diff($last_added_score);
        $hoursDifference = $interval->h + ($interval->days * 24);
        http_response_code(200);
        echo $hoursDifference < 8 ? json_encode(0) : json_encode(1);
        return;

    } else {
        http_response_code(200);
        echo json_encode(1);
        return;
    }


}
//For adding a score to a video -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'add_score') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    // Retrieve posted data
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    $videoSvc = new VideoService();
    $logSvc = new LogService();
    $userSvc = new UserService();

    $user = $userSvc->getUserById(intval($postData['user_id']));

    //check that it has at least been 8 hours
    $last_added_score = $user->getLastScore();

    if ($last_added_score) {
        $current_datetime = new DateTime();
        $interval = $current_datetime->diff($last_added_score);
        $hoursDifference = $interval->h + ($interval->days * 24);

        if ($hoursDifference < 8) {
            http_response_code(400);
            echo json_encode(['error' => "You have already added a score in the last 8 hours."]);
            return;
        }

    }

    $userSvc->updateLastScore($user);

    $video = $videoSvc->getVideoById(intval($postData['video_id']));
    $videoSvc->addScore($video);
    $logSvc->log(intval($postData['user_id']), 'Score', intval($postData['video_id']));

    http_response_code(200);
    echo json_encode(['message' => 'Score succesfully added to video!']);

    return;

}
//For fetching creator stats -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'fetch_creator_stats') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    $creatorSvc = new CreatorService;
    $creator = $creatorSvc->getCreatorById(intval($postData['creator_id']));

    if ($creator) {
        http_response_code(200);
        echo json_encode([
            'message' =>
                '<ul>
            <li>Starred in <strong>' . $creatorSvc->getAmountStarredIn($creator) . '</strong> videos</li>
            <li><strong>' . $creatorSvc->getTotalViewsOfCreator($creator) . '</strong> total views</li>
            <li><strong>Score: ' . $creatorSvc->getTotalScoreOfCreator($creator) . '</strong></li>
        </ul>'
        ]);
    } else {
        http_response_code(400);
        echo json_encode(['error' => 'Creator not found.']);
    }
}
//For fetching creator data -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'fetch_creator_data') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    $creatorSvc = new CreatorService;
    $arr_simplified_creators = [];
    foreach ($creatorSvc->getAll() as $creator) {
        array_push(
            $arr_simplified_creators,
            [
                "creator_id" => $creator->getId(),
                "creator_name" => $creator->getName(),
                "creator_alias" => $creator->getAlias(),
                "creator_profile_pic" => $creator->GetProfilePic()
            ]
        );
    }
    http_response_code(200);
    echo json_encode(['message' => $arr_simplified_creators]);

}
//For favoriting a creator -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'favorite_creator') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    // Retrieve posted data
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    $creatorSvc = new CreatorService();
    $userSvc = new UserService();

    $user = $userSvc->getUserById(intval($postData['user_id']));
    $creator = $creatorSvc->getCreatorById(intval($postData['creator_id']));

    if ($user && $creator) {
        $userSvc->favoriteCreator($user, $creator);
    } else {
        http_response_code(400);
        echo json_encode(['error' => 'Error: Invalid user or creator.']);
    }
    http_response_code(200);
    echo json_encode(['message' => 'Creator succesfully favorited!']);
    return;

}
//For unfavoriting a creator -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'unfavorite_creator') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    // Retrieve posted data
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    $creatorSvc = new CreatorService();
    $userSvc = new UserService();

    $user = $userSvc->getUserById(intval($postData['user_id']));
    $creator = $creatorSvc->getCreatorById(intval($postData['creator_id']));

    if ($user && $creator) {
        $userSvc->unfavoriteCreator($user, $creator);
    } else {
        http_response_code(400);
        echo json_encode(['error' => 'Error: Invalid user or creator.']);
    }

    echo json_encode(['message' => 'Creator succesfully unfavorited!']);
    return;
}
//For favoriting a video -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'favorite_video') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    // Retrieve posted data
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    $videoSvc = new VideoService();
    $userSvc = new UserService();

    $user = $userSvc->getUserById(intval($postData['user_id']));
    $video = $videoSvc->getVideoById(intval($postData['video_id']));

    if ($user && $video) {
        $userSvc->favoriteVideo($user, $video);
    } else {
        http_response_code(400);
        echo json_encode(['error' => 'Invalid user or video.']);
    }

    http_response_code(200);
    echo json_encode(['message' => 'Video succesfully favorited!']);
    return;

}
//For unfavoriting a video -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'unfavorite_video') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    // Retrieve posted data
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    $videoSvc = new VideoService();
    $userSvc = new UserService();

    $user = $userSvc->getUserById(intval($postData['user_id']));
    $video = $videoSvc->getVideoById(intval($postData['video_id']));

    if ($user && $video) {
        $userSvc->unfavoriteVideo($user, $video);
    } else {
        http_response_code(400);
        echo json_encode(['error' => 'Invalid user or video.']);
    }
    http_response_code(200);
    echo json_encode(['message' => 'Video succesfully unfavorited!']);
    return;
}
//For searching a video in the favorited videos page -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'search_favorited_video') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    // Retrieve posted data
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    $videoSvc = new VideoService();

    $video = $videoSvc->getVideoById(intval($postData['video_id']));
    $query = $postData['search_query'];

    if (

        strpos(strtolower($video->getFilename()), $query) !== false ||
        strpos(strtolower($video->getTitle()), $query) !== false ||
        strpos(strtolower($video->getDescription()), $query) !== false ||
        strpos(strtolower($video->getTitle()), $query) !== false ||
        strpos(strtolower($video->getTagsAsString()), $query) !== false ||
        strpos(strtolower($videoSvc->getVideoCreatorsAsString($video->getId())), $query) !== false

    ) {
        http_response_code(200);
        echo json_encode(['message' => 'true']);
        return;
    }
    http_response_code(200);
    echo json_encode(['message' => 'false']);
    return;
}
//For fetching a short -- DONE
if (isset($_GET['action']) && $_GET['action'] === 'get_short') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */
    //no data is currently being received, but I implemented it in case we do want to send data, like when we want to pick videos depending on user preferences.
    $postData = json_decode(file_get_contents('php://input'), true); // Decode JSON data sent from JavaScript

    require ('components/DBNameSnippet.php');
    $videoSvc = new VideoService;
    $userSvc = new UserService;
    $creatorSvc = new CreatorService;
    $logSvc = new LogService;

    $user_id = intval($postData['user_id']);
    $user = $userSvc->getUserById($user_id);


    $video = $videoSvc->getShort();
    $videoSvc->addView($video);
    $logSvc->log($user_id, 'View', $video->getId());



    $video_simplified = [
        'source' => $contentPath . '/Videos/' . $video->getFilename() . $video->getExtension(),
        'id' => $video->getId(),
        'filename' => $video->getFilename(),
        'extension' => $video->getExtension(),
        'dateAdded' => $video->getDateAdded()->format('d/m/Y'),
        'score' => $video->getScore(),
        'description' => $video->getDescription(),
        'tags' => [],
        'views' => $video->getViews(),
        'title' => $video->getTitle(),
        'duration' => $video->getDuration(),
        'filesize' => $video->getFileSize(),
        'uploadedBy' => $video->getUploadedBy(),
        'aspectRatio' => $video->getAspectRatio(),
        'thumbnail' => $video->getThumbnail(),
        'is_favorited' => $userSvc->isVideoFavorited($user, $video),
        'creators' => []
    ];

    foreach ($video->getTags() as $tag) {
        $video_simplified['tags'][] = [
            'id' => $tag->getId(),
            'name' => $tag->getName(),
            'weight' => $tag->getWeight(),
            'description' => $tag->getDescription(),
            'dateAdded' => $tag->getDateAdded()->format(''),
        ];
    }

    foreach ($creatorSvc->getCreatorsByVideoId($video->getId()) as $creator) {
        $video_simplified['creators'][] = [
            'id' => $creator->getId(),
            'name' => $creator->getName(),
            'alias' => $creator->getAlias(),
            'description' => $creator->getDescription(),
            'profile_pic' => $creator->getProfilePic(),
        ];
    }

    http_response_code(200);
    echo json_encode(['message' => $video_simplified]);
}




//For fetching home page video results
if (isset($_GET['action']) && $_GET['action'] === 'getAllVideosPerPageWithFilter') {

    $headers = getallheaders();
    $csrfToken = $headers['X-CSRF-Token'] ?? '';
    /*
        if (!validateCsrfToken($csrfToken)) {
            http_response_code(403);
            echo json_encode(['error' => 'Invalid CSRF token: ' . $csrfToken]);
            exit;
        }
    */

    //required components
    require ('components/DBNameSnippet.php');
    $videoSvc = new VideoService;
    $videoPerformanceDAO = new VideoPerformanceDAO();
    $creatorSvc = new CreatorService;
    $tagSvc = new TagService;

    //retrieve post data
    $postData = json_decode(file_get_contents('php://input'), true);
    $page_no = (int) $postData['page_no'];
    $array_selected_tags_string = $postData['selected_tags']; // has to be an array of tag objects
    $query = $postData['query'];
    $order_by = $postData['order_by'];
    $exclude_shorts = $postData['exclude_shorts'] ? 'true' : 'false';


    //covert string array of tags to array of tag objects
    $tag_array = [];
    foreach ($array_selected_tags_string as $string_tag) {
        $tag = $tagSvc->getTagByName($string_tag);
        if ($tag) {
            array_push($tag_array, $tag);
        }
    }

    $results_per_page = 25;

    $video_list = $videoPerformanceDAO->getAllVideosPerPageWithFilter($page_no, $results_per_page, $tag_array, $query, $order_by, $exclude_shorts);

    $total_records = $videoPerformanceDAO->getTotalRecordsPerPageWithFilter($tag_array, $query, $exclude_shorts);
    $total_pages = ceil($total_records / $results_per_page);

    $results = [];

    foreach ($video_list as $video) {

        $video_simplified = [
            'source' => $contentPath . '/Videos/' . $video->getFilename() . $video->getExtension(),
            'id' => $video->getId(),
            'filename' => $video->getFilename(),
            'extension' => $video->getExtension(),
            'dateAdded' => $video->getDateAdded()->format('d/m/Y'),
            'score' => $video->getScore(),
            'description' => $video->getDescription(),
            'tags' => [],
            'views' => $video->getViews(),
            'title' => $video->getTitle(),
            'duration' => $video->getDuration(),
            'filesize' => $video->getFileSize(),
            'uploadedBy' => $video->getUploadedBy(),
            'aspectRatio' => $video->getAspectRatio(),
            'thumbnail' => $video->getThumbnail(),
            'creators' => []
        ];

        foreach ($video->getTags() as $tag) {
            $video_simplified['tags'][] = [
                'id' => $tag->getId(),
                'name' => $tag->getName(),
                'weight' => $tag->getWeight(),
                'description' => $tag->getDescription(),
                'dateAdded' => $tag->getDateAdded()->format(''),
            ];
        }

        foreach ($creatorSvc->getCreatorsByVideoId($video->getId()) as $creator) {
            $video_simplified['creators'][] = [
                'id' => $creator->getId(),
                'name' => $creator->getName(),
                'alias' => $creator->getAlias(),
                'description' => $creator->getDescription(),
                'profile_pic' => $creator->getProfilePic(),
            ];
        }

        array_push($results, $video_simplified);
    }

    http_response_code(200);

    echo 
    json_encode([
        'result' => $results,
        'total_records' => $total_records,
        'total_pages' => $total_pages,
    ]);


}


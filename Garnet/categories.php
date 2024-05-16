<?php
declare(strict_types=1);
session_start();
require_once('data/autoloader.php');
require_once('components/DBNameSnippet.php');
require_once('components/authManager.php');



$tagSvc = new TagService();
$all_tags = $tagSvc->getAllTags();
$popular_tags = $tagSvc->getAllPopularTags(10);
$recommended_tags = $tagSvc->getAllRecommendedTags(10, $user);

/*Load an array with all tag_id's as the key, and their amount of occurences, so we don't have to fetch this information seperately for each tag and slow down performance.
This increases performance by 80% (roughly 2500ms -> 500ms) */ 
$arr_tag_occurences = $tagSvc->getTagOccurences();


include ('presentation/CategoriesForm.php');

<?php
/*Snippet for determining what database is being used*/

require_once('data/autoloader.php');

$contentPath = 'content';
if (DBConfig::getDatabaseName() == "garnet_dummy") {
    $contentPath = 'dummycontent';
}


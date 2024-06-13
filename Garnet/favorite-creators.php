<?php
declare(strict_types=1);
session_start();
require_once('components/DBNameSnippet.php');
require_once('data/autoloader.php');
require_once('components/authManager.php');

$userSvc = new UserService;
$creatorSvc = new CreatorService;
$favorite_creators = $userSvc->getFavoriteCreators($user);

include('presentation/ProfileFavoriteCreators.php');
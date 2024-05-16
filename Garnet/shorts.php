<?php
declare(strict_types=1);
session_start();
require_once('data/autoloader.php');
require_once('components/DBNameSnippet.php');
require_once('components/authManager.php');

$videoSvc = new VideoService();


include('presentation/ShortsForm.php');
<?php
declare(strict_types=1);
require_once('data/autoloader.php');
//check if user is logged in
if (!isset($_COOKIE['user']) || $_COOKIE['user'] == '') {
    header('Location: login');
    exit(0);
} else {
    $user = unserialize($_COOKIE['user'], ['User']);
}


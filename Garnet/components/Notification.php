<?php
if (isset($_SESSION['feedback'])) {
    $feedback = new CustomException($_SESSION['feedback'], $_SESSION['feedback_color']);
    unset($_SESSION['feedback']);
    unset($_SESSION['feedback_color']);
} else {
    $feedback = new CustomException('', 'red');
}
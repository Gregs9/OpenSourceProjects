<?php
declare(strict_types=1);
require_once("Chatprogramma.php");
?>

<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Chat</title>
    <link rel="stylesheet" href="default.css">
</head>


<body>
    <?php
    //Check if a new message needs to be added
    
    if (isset($_GET["action"]) && $_GET["action"] === "newuser") {
        setcookie('username', $_POST['username']);
        setcookie('color', $_POST['color']);
        header("Location: ChatForm.php");
    }
    ?>
    <form action="Username.php?action=newuser" method="post">
        <label for="username">Please set your username: <br><input id="username" type="text" name="username"
                minlength="1" maxlength="45" required></label>
            <select id="color" name="color">
                <option value="black">Black</option>
                <option value="blue">Blue</option>
                <option value="brown">Brown</option>
                <option value="gray">Gray</option>
                <option value="green">Green</option>
                <option value="orange">Orange</option>
                <option value="pink">Pink</option>
                <option value="purple">Purple</option>
                <option value="red">Red</option>
                <option value="white">White</option>
                <option value="yellow">Yellow</option>
            </select>
            <br>
            <input type="submit" value="Set" />
    </form>
</body>

</html>
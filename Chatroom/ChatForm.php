<?php
declare(strict_types=1);
require_once("Chatprogramma.php");
$instantie = new Chat();

if (!isset($_COOKIE['username']) || $_COOKIE['username'] === "") {
    header("Location: Username.php");
}

if (isset($_GET["action"]) && $_GET["action"] === "send") {
    $instantie->sendMessage((string) $_POST["message"]);
    header("Location: ChatForm.php");
}
?>

<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Chat</title>
    <link rel="stylesheet" href="default.css">
</head>


<body>

    <h1>Chat with others!</h1>
    <?php echo '<h2>Logged in as </h2>' . '<h2 style="color:' . $_COOKIE['color'] . '">' . $_COOKIE['username'] . '</h2>' ;?>
    <div id="messages">

        <?php
        $lijst = $instantie->getLIJSTELEMENTEN();
        foreach ($lijst as $element) {
            echo (
                '<div class="message">' .
                '<img src="avatar.png" alt="avatar" class="avatar">' .
                
                '<label class="username" style="color:' . $_COOKIE['color'] . ';">' . $element->getUsername() . '</label>' . '<p class="timestamp">' . $element->getTimestamp() .'</p>' .
                '<br>' .
                '<p>' . $element->getMessage() . '</p>' . '<br>' .
                '</div>'
            );
        }
        ?>
    </div>




    <form action="ChatForm.php?action=send" method="post">
        <label>Message: <br><textarea id="message" type="text" name="message" minlength="1" maxlength="500"
                required></textarea></label>
        <br>
        <input type="submit" value="Send" />
    </form>
</body>

</html>

<script defer>
    document.getElementById("messages").scrollTop = document.getElementById("messages").scrollHeight;
</script>
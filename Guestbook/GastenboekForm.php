<?php
declare(strict_types=1);
require_once("Gastenboek.php");


?>

<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Gegevens ophalen</title>
    <link rel="stylesheet" href="default.css">
</head>


<body>
    <h1>Berichten</h1>
    <div id="boodschappen">
    <?php




    $instantie = new Gastenboek();

    //Check if a new message needs to be added
    if (isset($_GET["action"]) && $_GET["action"] === "new") {
        $instantie->addBoodschap((string) $_POST["auteur"], (string) $_POST["boodschap"]);
        header("Location: GastenboekForm.php");
    }


    $lijst = $instantie->getLIJSTELEMENTEN();
    foreach ($lijst as $element) {
        echo (
            "<label>Auteur: </label>" . $element->getAuteur() . "<br>" . "<p>" . $element->getBoodschap() . "</p>" . "<p>_________________________________________________________</p> <br>"
        );
    }

    ?>
</div>
    <h1>Bericht Toevoegen</h1>
    <form action="GastenboekForm.php?action=new" method="post">
        <label for="auteur">Auteur: <input id="auteur" type="text" name="auteur" pattern="[A-Za-z]{1,30}" maxlength="30"
                required /></label>
        <br>
        <label>Boodschap: <br><textarea id="boodschap" type="text" name="boodschap" maxlength="200"
                required></textarea></label>
        <br>
        <input type="submit" value="Verzenden" />
    </form>
</body>

</html>
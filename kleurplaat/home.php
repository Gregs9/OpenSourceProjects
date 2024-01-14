<?php
declare(strict_types=1);

?>


<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Kleurplaat</title>
    <link rel="stylesheet" href="kleurplaat.css">
    <script src="kleurplaat.js" defer></script>
</head>

<body>
    <!--START WRAPPER-->
    <div class="wrapper">

        <h1>Kleurplaat</h1>

        <div id="kleurplaat">

        </div>

        <div id="veldgrootte">
            <label for="hoogte">Hoogte</label>
            <input type="number" id="hoogte" name="hoogte" value="20" max="99" min="1" required>
            <br>
            <label for="breedte">Breedte</label>
            <input type="number" id="breedte" name="breedte" value="20" max="99" min="1" required>
            <br>
            <label for="celgrootte">Celgrootte</label>
            <input type="number" id="celgrootte" name="celgrootte" value="50" max="100" min="1" required>
            <label for="celgrootte">px</label>
            <br>
            <button id="veldgrootte_toepassen">Toepassen</button>
        </div>

        <div id="kleurkeuze">
            <p>Selecteer een kleur</p>
            <input type="radio" id="rood" name="kleur" value="red">
            <label for="rood">Rood</label><br>
            <input type="radio" id="groen" name="kleur" value="green">
            <label for="groen">Groen</label><br>
            <input type="radio" id="blauw" name="kleur" value="blue">
            <label for="blauw">Blauw</label><br>
            <input type="radio" id="wit" name="kleur" value="white" checked>
            <label for="wit">Wit</label>
        </div>

        <button id="exporteer">Exporteer</button>
        <br>
        <label for="fileToUpload">Importeer</label>
            <input type=file id="fileToUpload" name="fileToUpload" accept="application/json">





    </div>
    <!--END WRAPPER-->

</body>

</html>
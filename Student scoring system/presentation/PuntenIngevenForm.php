<?php
declare(strict_types=1);
require_once('business/PersoonService.php');
require_once('business/ModuleService.php');
require_once('business/ScoreService.php');
?>

<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Punten Ingeven</title>
    <link rel="stylesheet" href="Css/default.css">
</head>

<body>

    <h1>Punten ingeven voor
        <?php
        foreach ($personenLijst as $persoon) {
            if ($persoon->getId() == $_GET['id']) {
                echo $persoon->getFamilienaam() . ' ' . $persoon->getVoornaam();
            }
        }
        ?>
    </h1>

    <form method="post" action="punteningeven.php?id=<?php echo $_GET['id'] ?>&action=opslaan">
        <table>
            <thead>
                <tr>
                    <th>Module</th>
                    <th>Punten</th>
                </tr>
            </thead>
            <tbody>
                <?php
                foreach ($moduleLijst as $module) {

                    $punt = $scoreSvc->getScoreByID((int) $module->getId(), (int) $_GET['id']);

                    if ($punt === '') {
                        echo
                '<tr>
                    <td>' . $module->getNaam() . '</td>
                    <td><input type="number" min="0" max="100" name="' . $module->getId() . '"></input></td>
                </tr>';
                    }
                }
                ?>
            </tbody>
        </table>
        <a href="overzicht.php">< Terug</a>
        <input type="submit" value="Sla op" style="cursor:pointer">
    </form>
    


</body>

</html>
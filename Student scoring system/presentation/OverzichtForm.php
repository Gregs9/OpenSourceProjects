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
    <title>Punten</title>
    <link rel="stylesheet" href="Css/default.css">
</head>

<body>
    <h1>Punten ingeven</h1>
    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>Familienaam</th>
                <th>Voornaam</th>
                <th>Geboortedatum</th>
                <th>Geslacht</th>
                <th>Punten</th>
            </tr>
        </thead>
        <tbody>
            <?php



            foreach ($personenLijst as $persoon) {

                if ($scoreSvc->getAmountOfScores($persoon->getId()) >= 9) {
                    $link = '<a>Alles ingegeven!</a>';
                } else {
                    $link = '<a href="punteningeven.php?id=' . $persoon->getId() . '">Ingeven ></a>';
                }

                echo
                    '
                <tr>
                    <td>' . $persoon->getId() . '</td>
                    <td>' . $persoon->getFamilienaam() . '</td>
                    <td>' . $persoon->getVoornaam() . '</td>
                    <td>' . $persoon->getGeboorteDatum() . '</td>
                    <td>' . $persoon->getGeslacht() . '</td>
                    <td>' . $link . '</td>
                </tr>
                ';
            }
            ?>
        </tbody>
    </table>





    <h1>Punten per module</h1>
    <table>
        <thead>
            <tr>
                <th></th>
                <?php

                foreach ($personenLijst as $persoon) {
                    echo '<th>' .
                        $persoon->getFamilienaam() . ' ' . $persoon->getVoornaam()
                        . '</th>';
                }
                ?>
            </tr>
        </thead>
        <tbody>
            <?php
            foreach ($moduleLijst as $module) {
                echo '<tr><td>' . $module->getNaam() . '</td>';
                foreach ($personenLijst as $persoon) {
                    echo '<td>' . $scoreSvc->getScoreByID((int) $module->getId(), (int) $persoon->getId()) . '</td>';
                }
                echo '</tr>';
            }
            ?>
        </tbody>
        <tfoot>
            <?php
            echo '<tr><td><strong>GEMIDDELDE</strong></td>';
            foreach ($personenLijst as $persoon) {
                echo '<td><strong>' . $scoreSvc->getAverageScoreByPersoon($persoon->getId()) . '</strong></td>';
            }
            echo '</tr>';
            ?>
        </tfoot>
    </table>



    <h1>Punten per student</h1>
    <table>
        <thead>
            <tr>
                <th></th>
                <?php

                foreach ($moduleLijst as $module) {
                    echo '<th>' . $module->getNaam() . '</th>';
                }
                ?>
            </tr>
        </thead>
        <tbody>
            <?php
            foreach ($personenLijst as $persoon) {
                echo '<tr><td>' . $persoon->getFamilienaam() . ' ' . $persoon->getVoornaam() . '</td>';
                foreach ($moduleLijst as $module) {
                    echo '<td>' . $scoreSvc->getScoreByID((int) $module->getId(), (int) $persoon->getId()) . '</td>';
                }
                echo '</tr>';
            }
            ?>
        </tbody>
        <tfoot>
            <?php
            echo '<tr><td><strong>GEMIDDELDE</strong></td>';
            foreach ($moduleLijst as $module) {
                echo '<td><strong>' . $scoreSvc->getAverageScoreByModule($module->getId()) . '</strong></td>';
            }
            echo '</tr>';
            ?>
        </tfoot>
    </table>




</body>

</html>
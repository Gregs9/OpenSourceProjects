<?php
declare(strict_types=1);

?>


<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Treasure Hunt</title>
    <link rel="stylesheet" href="Schattenjacht.css">
    <link rel="icon" href="assets/treasurehunt.ico">
    <script src="Schattenjacht.js" defer></script>
    <script src="UI.js" defer></script>
    <!--PRELOAD IMAGES TO AVOID FLICKERING-->
    <link rel="preload" href="assets/gras.png" as="image">
    <link rel="preload" href="assets/muur.png" as="image">
    <link rel="preload" href="assets/schat.png" as="image">

    <link rel="preload" href="assets/jager_boven.png" as="image">
    <link rel="preload" href="assets/jager_links.png" as="image">
    <link rel="preload" href="assets/jager_onder.png" as="image">
    <link rel="preload" href="assets/jager_rechts.png" as="image">

    <link rel="preload" href="assets/speler_boven.png" as="image">
    <link rel="preload" href="assets/speler_links.png" as="image">
    <link rel="preload" href="assets/speler_onder.png" as="image">
    <link rel="preload" href="assets/speler_rechts.png" as="image">

    <link rel="preload" href="assets/jager_dood_1.png" as="image">
    <link rel="preload" href="assets/jager_dood_2.png" as="image">
    <link rel="preload" href="assets/jager_dood_3.png" as="image">
    <link rel="preload" href="assets/jager_dood_4.png" as="image">
    <link rel="preload" href="assets/jager_dood_5.png" as="image">
    <link rel="preload" href="assets/jager_dood_6.png" as="image">

    <link rel="preload" href="assets/jager_idle_0.png" as="image">
    <link rel="preload" href="assets/jager_idle_1.png" as="image">
    <link rel="preload" href="assets/jager_idle_2.png" as="image">
    <link rel="preload" href="assets/jager_idle_3.png" as="image">

</head>

<body>
    <audio id="music" src="assets/e1m1.mp3" loop></audio>
    <audio id="death" src="assets/death.wav"></audio>
    <audio id="injured" src="assets/damage.wav"></audio>
    <audio id="treasure" src="assets/treasure.wav"></audio>
    <audio id="start" src="assets/start.wav"></audio>

    <div id="start-menu">
        <h1>DOOM TREASURE HUNT</h1>

        <div id="game_settings">
            <label for="difficulty">difficulty</label>
            <br>
            <select name="difficulty" id="difficulty">
                <option value="4">I'm Too Young To Die</option>
                <option value="3">Hurt Me Plenty</option>
                <option value="2">Ultra Violence</option>
                <option value="1">☠ Nightmare ☠</option>
            </select>
            <br>
            <br>
            <label for="hoogte">Height
                <input type="range" min="10" max="50" value="15" class="slider" id="hoogte"><span
                    id="n_hoogte">15</span>
            </label>

            <br>

            <label for="breedte">Width
                <input type="range" min="10" max="50" value="15" class="slider" id="breedte"><span
                    id="n_breedte">15</span>
            </label>

            <br>
            <br>

            <button id="speel" class="button">PLAY</button>

            <br>
            <br>
            <br>
            <br>

            <label for="music_volume">Music volume</label><input type="range" min="0" max="100" value="0" class="slider" id="music_volume"><span
                id="m_volume">0</span>

                <label for="sfx_volume">SFX volume</label><input type="range" min="0" max="100" value="60" class="slider" id="sfx_volume"><span
                id="s_volume">60</span>

        </div>
    </div>



    <main id="game" style="display: none;">


        <div id="win-screen" style="display:none;">
            <h1>You won</h1>
            <button id="win-again" class="button">Play again</button>
        </div>

        <div id="kill-screen" style="display:none;">
            <h1>You lost</h1>
            <button id="lose-again" class="button">RETRY</button>
        </div>







        <div id="speelveld">

        </div>


        <div id="levens" style="display:none;">
            <div class="heart full">
            </div>
            <div class="heart full">
            </div>
            <div class="heart full">
            </div>
        </div>

        <div id="spelinfo" style="display:none;">
            <label>Treasures: </label>
            <label id="gevonden-schatten">0</label>
            <label>/</label>
            <label id="totale-schatten">3</label>
        </div>

    </main>






</body>

</html>
<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Minesweeper</title>
    <link rel="stylesheet" href="css/Minesweeper.css">
    <link rel="icon" type="image/x-icon" href="assets/minesweeper.ico">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="JS/UI.js" defer></script>
    <script src="JS/Minesweeper.js" defer></script>
</head>

<body>
    <audio id="music" src="assets/ironforge.mp3" loop></audio>
    <audio id="sfx"></audio>
    <audio id="sfx-bomb"></audio>

    <div id="start-menu">
        <h1>MINESWEEPER</h1>

        <div id="game_settings">

            <div id="height-container">
                <label for="height">Height: <span id="n_height">15</span></label>
                <input type="range" min="10" max="50" value="15" class="slider" id="height">
            </div>

            <div id="width-container">
                <label for="width">Width: <span id="n_width">15</span></label>
                <input type="range" min="10" max="50" value="15" class="slider" id="width">
            </div>

            <div id="bomb-container">
                <label for="bombs">Bomb ratio: <span id="n_bombs">15</span></label>
                <input type="range" min="5" max="50" value="15" class="slider" id="bombs">
            </div>

            <div id="button-container">
                <button id="play" class="button">PLAY</button>
            </div>


            <br>
            <div id="volume-container">
                <div id="music-volume-container">
                    <label for="width">Music Volume: </label>
                    <input type="range" min="0" max="100" value="20" class="slider" id="music_volume">
                    <span id="n_music_volume">20</span>
                </div>

                <div id="sfx-volume-container">
                    <label for="width">SFX Volume: </label>
                    <input type="range" min="0" max="100" value="20" class="slider" id="sfx_volume">
                    <span id="n_sfx_volume">20</span>
                </div>
            </div>
        </div>

    </div>



    <main id="game" style="display: none;">

        <div id="game_info">

            <div id="time">
                <img src="assets/time.jpg">
                <label id="seconds">0</label>
            </div>

            <div id="flags">
                <img src="assets/flag.jpg">
                <label id="flag"></label>
            </div>

        </div>

        <!--Show this field when the player wins-->
        <div id="win-screen" style="display:none;">
            <h1>VICTORY</h1>
            <button id="win-again" class="button">play again</button>
        </div>

        <!--Show this field when the player loses-->
        <div id="kill-screen" style="display:none;">
            <h1>DEFEAT</h1>
            <button id="lose-again" class="button">RETRY</button>
        </div>

        <div id="grid">

        </div>


    </main>

</body>

</html>
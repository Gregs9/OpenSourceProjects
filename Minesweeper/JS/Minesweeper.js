"use strict";

class Field {
    #h;
    #w;
    #grid = [];

    getHeight() {
        return parseInt(this.#h);
    }

    getWidth() {
        return parseInt(this.#w);
    }

    generateGrid(height, width, bombs) {
        this.#h = height;
        this.#w = width;

        //generate grid with given size
        for (let y = 0; y < height; y++) {
            const row = [];
            for (let x = 0; x < width; x++) {
                const node = new Node(x, y, false);
                row.push(node);
            }
            this.#grid.push(row);
        }

        //calculate amount of bombs
        let bomb_amount = Math.floor(((height * width) / 100) * bombs);

        //give amount of flags equal to the amount of bombs
        flags = bomb_amount;
        $('#flag').text(flags);

        //Flatten & shuffle array, and get first x results, where x is the amount of bombs
        const bombNodes = shuffleArray(this.#grid.flat()).slice(0, bomb_amount);

        //Set these randomly selected nodes to bombs
        bombNodes.forEach(bombNode => bombNode.setIsBomb(true));

        function shuffleArray(array) {
            for (let i = array.length - 1; i > 0; i--) {
                const j = Math.floor(Math.random() * (i + 1));
                [array[i], array[j]] = [array[j], array[i]];
            }
            return array;
        }

        this.generateProximityNumbers();

    }

    generateProximityNumbers() {
        for (const row of this.#grid) {
            for (const node of row) {
                let proximity = 0;
                //Check each neighbour and add 1 to proximity if it is a bomb
                if (node.getY() > 0) { this.#grid[node.getY() - 1][node.getX()].getIsBomb() ? proximity++ : undefined; }
                if (node.getY() > 0 && node.getX() < (this.#w - 1)) { this.#grid[node.getY() - 1][node.getX() + 1].getIsBomb() ? proximity++ : undefined; }
                if (node.getX() < (this.#w - 1)) { this.#grid[node.getY()][node.getX() + 1].getIsBomb() ? proximity++ : undefined; }
                if (node.getY() < (this.#h - 1) && node.getX() < (this.#w - 1)) { this.#grid[node.getY() + 1][node.getX() + 1].getIsBomb() ? proximity++ : undefined; }
                if (node.getY() < (this.#h - 1)) { this.#grid[node.getY() + 1][node.getX()].getIsBomb() ? proximity++ : undefined; }
                if (node.getY() < (this.#h - 1) && node.getX() > 0) { this.#grid[node.getY() + 1][node.getX() - 1].getIsBomb() ? proximity++ : undefined; }
                if (node.getX() > 0) { this.#grid[node.getY()][node.getX() - 1].getIsBomb() ? proximity++ : undefined; }
                if (node.getX() > 0 && node.getY() > 0) { this.#grid[node.getY() - 1][node.getX() - 1].getIsBomb() ? proximity++ : undefined; }
                node.setProximity(proximity);
            }
        }
    }

    drawGrid() {

        $('#grid').empty();

        for (let i = 0; i < this.#w; i++) {
            for (let j = 0; j < this.#h; j++) {
                const node = this.#grid[i][j];

                //create the element
                const node_element = $('<div class="cell" data-x="' + node.getX() + '" data-y="' + node.getY() + '"></div>');

                node.getFlagged() ? node_element.addClass('flagged') : null;
                node.getRevealed() && node.getIsBomb() ? node_element.addClass('bomb') : null;
                node.getRevealed() && !node.getIsBomb() ? node_element.addClass('Prox' + node.getProximity()) : null;

                //if node isn't revealed, add onclick events
                if (!node.getRevealed()) {
                    node_element.click(function (e) { //left click
                        field.leftClick(e, node, node_element);
                    });
                    node_element.on('contextmenu', function (e) {
                        field.rightClick(e, node); //right click
                    });

                }

                //append the drawn node to the canvas
                $('#grid').append(node_element);

                //Check for chain-reaction
                field.revealNeighbouringZeros();
            }

            //add line break
            $('#grid').append($('<br>'));
        }

        field.determineCellSize();

        //bug workaround - unfortunately I couldn't find the cause so this workaround is required to make the top left cell (0,0) reveal itself if one if it's neightbours is a 0
        // this will make sure to reveal the first node(0,0) if it's neighbours are 0
        this.#grid[0][0].getRevealed() ? $('[data-x="0"][data-y="0"]').addClass('Prox' +  this.#grid[0][0].getProximity()) : null;


        //Check if all nodes are revealed except bombs
        this.checkVictory() ? win() : null;

    }

    determineCellSize() {
        //get screen width in pixels
        let screenHeight = window.innerHeight;
        let screenWidth = window.innerWidth;

        //substract 50px to have a margin
        screenWidth -= 50;
        screenHeight -= 100;

        //Spread the amount of cells over the available width
        let cell_width = Math.floor(screenWidth / this.#w);
        let cell_height = Math.floor(screenHeight / this.#h);

        //get lowest of the two since cells must always be square
        const cell_size = Math.min(cell_width, cell_height);

        $(".cell").width(cell_size + 'px');
        $(".cell").height(cell_size + 'px');
        $('#grid').width(this.#w * cell_size);
        $('#game_info').width(this.#w * cell_size);
    }

    revealNeighbouringZeros() {
        const grid = this.#grid;
        const w = this.#w;
        const h = this.#h;

        //for every node
        for (let i = (field.getHeight() - 1); i > -1; i--) {
            for (let j = (field.getWidth() - 1); j > -1; j--) {
                const node = grid[i][j];
                if (node.getProximity() === 0 && node.getRevealed()) {
                    if (node.getY() > 0) { grid[node.getY() - 1][node.getX()].reveal() } //top
                    if (node.getY() > 0 && node.getX() < (w - 1)) { grid[node.getY() - 1][node.getX() + 1].reveal() }//topright
                    if (node.getX() < (w - 1)) { grid[node.getY()][node.getX() + 1].reveal() }//right
                    if (node.getY() < (h - 1) && node.getX() < (w - 1)) { grid[node.getY() + 1][node.getX() + 1].reveal() }//bottomright
                    if (node.getY() < (h - 1)) { grid[node.getY() + 1][node.getX()].reveal() }//bottom
                    if (node.getY() < (h - 1) && node.getX() > 0) { grid[node.getY() + 1][node.getX() - 1].reveal() }//bottomleft
                    if (node.getX() > 0) { grid[node.getY()][node.getX() - 1].reveal() }//left
                    if (node.getX() > 0 && node.getY() > 0) { grid[node.getY() - 1][node.getX() - 1].reveal() }//topleft
                }
            }
        }

    }

    checkVictory() {
        for (const row of this.#grid) {
            for (const node of row) {
                if (!node.getIsBomb() && !node.getRevealed()) {
                    // If any non-bomb node is not revealed, return false (game is not won)
                    return false;
                }
            }
        }

        return true;
    }

    rightClick(e, node) {
        e.preventDefault(); // Prevent the default right-click menu from showing
        if (!node.getFlagged() && flags > 0) {
            sfx.playFlag();
            node.setFlagged(true);
            flags--;
        } else if (node.getFlagged()) {
            sfx.playRemoveFlag();
            node.setFlagged(false);
            flags++;
        }

        $('#flag').text(flags);

        field.drawGrid();

    }

    leftClick(e, node, node_element) {
        sfx.playHammer(node.getProximity());
        node.reveal();

        if (node.getIsBomb()) {
            sfx.playBomb();
            node_element.removeClass('flagged');
            node_element.addClass('bomb');
            lose();
        }
        field.drawGrid();
    }
}

class Node {
    #x;
    #y;
    #isBomb;
    #revealed;
    #proximity;
    #flagged;

    constructor(x, y, isBomb) {
        this.#x = x;
        this.#y = y;
        this.#isBomb = isBomb;
        this.#revealed = false;
        this.#flagged = false;
    }

    getX() {
        return parseInt(this.#x);
    }

    getY() {
        return parseInt(this.#y);
    }

    getIsBomb() {
        return this.#isBomb;
    }

    setIsBomb(bool) {
        this.#isBomb = bool;
    }

    reveal() {
        this.#revealed = true;
        this.#flagged = false; //A revealed node can never be flagged
    }

    getRevealed() {
        return this.#revealed;
    }

    setProximity(proximity) {
        this.#proximity = proximity;
    }

    getProximity() {
        return parseInt(this.#proximity);
    }

    getFlagged() {
        return this.#flagged;
    }

    setFlagged(bool) {
        this.#flagged = bool;
    }

}

class SFX {
    #music_element = $('#music')[0];
    #audio_element = $('#sfx')[0];
    #music_vol;
    #sfx_vol;

    constructor(music_vol, sfx_vol) {
        this.#music_vol = music_vol / 100;
        this.#sfx_vol = sfx_vol / 100;
        this.#music_element.volume = this.#music_vol
        this.#audio_element.volume = this.#sfx_vol
    }

    playMusic() {
        this.#music_element.pause();
        this.#music_element.currentTime = 0;
        this.#music_element.play();
    }

    playHammer(intensity) {
        this.#audio_element.src = "assets/hammer" + intensity + ".mp3";
        this.#audio_element.play();
    }

    playFlag() {
        this.#audio_element.src = "assets/flag.mp3";
        this.#audio_element.play();
    }

    playRemoveFlag() {
        this.#audio_element.src = "assets/removeflag.mp3";
        this.#audio_element.play();
    }

    playBomb() {
        $('#sfx-bomb')[0].volume = this.#sfx_vol;
        $('#sfx-bomb')[0].src = "assets/bomb.mp3";
        $('#sfx-bomb')[0].play();
    }

    playVictory() {
        this.#audio_element.src = "assets/victory.mp3";
        this.#audio_element.play();
    }
    playDefeat() {
        this.#audio_element.src = "assets/defeat.mp3";
        this.#audio_element.play();
    }

}














let timerInterval;
let seconds = 0;
let flags = 0;
let sfx;
const field = new Field();



//Play button click
$('#play').click(function () {
    sfx = new SFX($('#music_volume').val(), $('#sfx_volume').val());
    sfx.playMusic();

    $('#start-menu').hide();
    $('#game').show();


    field.generateGrid($('#height').val(), $('#width').val(), $('#bombs').val());

    //Automatically scale cells
    addEventListener("resize", (event) => { field.determineCellSize() });
    onresize = (event) => { field.determineCellSize() };

    field.drawGrid();

    startTimer();

})





function lose() {
    stopTimer();
    $('.cell').off();
    $('#kill-screen').css('display', 'inline-block');
    sfx.playDefeat();
}

function win() {
    stopTimer();
    $('.cell').off();
    $('#win-screen').css('display', 'inline-block');
    sfx.playVictory();
}


function startTimer() {
    timerInterval = setInterval(updateTimer, 1000);
    seconds = 0;
}

function stopTimer() {
    clearInterval(timerInterval);
}

function updateTimer() {
    seconds++;
    $('#seconds').text(seconds);
}



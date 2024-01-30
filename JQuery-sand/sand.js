"use strict";
class Canvas {
    #height;
    #width;
    #nodes = [];

    constructor(height, width) {
        this.#height = height;
        this.#width = width;
    }

    generateCanvas() {
        //Empty potentially existing array of nodes
        this.#nodes = [];

        //Empty potentially existing grid
        $('#canvas').empty();

        //Generate array of nodes
        for (let i = 0; i < this.#height; i++) {
            const row = [];
            for (let j = 0; j < this.#width; j++) {
                const node = new Node(j, i, '#ffffff', false)
                row.push(node);
            }
            this.#nodes.push(row);
        }

        //Draw nodes as a grid of divs
        for (const row of this.#nodes) {
            for (const node of row) {
                //create the element
                const node_element = $('<div class="node" data-x="' + node.getX() + '" data-y="' + node.getY() + '"></div>');

                //Set the size of the node
                const cell_size = this.calculateCellSize();
                node_element.height(cell_size);
                node_element.width(cell_size);
                node_element.css("background-color", node.getColor());
                node_element.attr('draggable', 'False');


                //append the drawn node to the canvas
                $('#canvas').append(node_element);

                node_element.hover(() => {
                    if (mouseDown === true) {
                        node.setIsSand(true);
                    }
                });

            }
            const linebreak = $('<br>');
            $('#canvas').append(linebreak);
        }
    }

    getHeight() {
        return parseInt(this.#height);
    }

    getWidth() {
        return parseInt(this.#width);
    }

    getNodes() {
        return this.#nodes;
    }

    shiftSand() {
        //Iterate over every row in the nodes array
        for (let y = this.#nodes.length - 1; y >= 0; y--) {
            // Iterate over each node in the row
            for (let x = this.#nodes[y].length - 1; x >= 0; x--) {

                // Check if the current node is sand and it's not in the last row
                if (this.#nodes[y][x].getIsSand() && y < this.#nodes.length - 1) {
                    // Check if the node below is not sand
                    let moved = false;
                    if (!this.#nodes[y + 1][x].getIsSand()) {
                        // Move sand down one row
                        this.#nodes[y + 1][x].setIsSand(true);
                        this.#nodes[y][x].setIsSand(false);

                        //select div with the same coordinates as the next node
                        const old_node_element = $('[data-x="' + x + '"][data-y="' + y + '"]');
                        const new_node_element = $('[data-x="' + x + '"][data-y="' + (y + 1) + '"]');

                        //change node background color
                        old_node_element.css("background-color", this.#nodes[y][x].getColor());
                        new_node_element.css("background-color", this.#nodes[y + 1][x].getColor());

                        moved = true;
                    }

                    if (!moved) {
                        const randomNumber = Math.floor(Math.random() * 2);
                        switch (randomNumber) {
                            case 0:
                                attemptSlideLeft();
                                attemptSlideRight();
                                break;
                            case 1:
                                attemptSlideRight();
                                attemptSlideLeft();
                                break;
                        }
                    }



                    function attemptSlideLeft() {
                        if (x > 0 && !canvas.getNodes()[y][x - 1].getIsSand() && !canvas.getNodes()[y + 1][x - 1].getIsSand()) {
                            // Move sand to the left if the node to the left and below is not sand
                            canvas.getNodes()[y][x - 1].setIsSand(true);
                            canvas.getNodes()[y][x].setIsSand(false);

                            // Select div with the same coordinates as the new node
                            const old_node_element = $('[data-x="' + x + '"][data-y="' + y + '"]');
                            const new_node_element = $('[data-x="' + (x - 1) + '"][data-y="' + (y + 1) + '"]');

                            // Change node background color
                            old_node_element.css("background-color", canvas.getNodes()[y][x].getColor());
                            new_node_element.css("background-color", canvas.getNodes()[y][x - 1].getColor());
                        }
                    }

                    function attemptSlideRight() {
                        if (x < canvas.getNodes()[y].length - 1 && !canvas.getNodes()[y][x + 1].getIsSand() && !canvas.getNodes()[y + 1][x + 1].getIsSand()) {
                            // Move sand to the right if the node to the right and below is not sand
                            canvas.getNodes()[y][x + 1].setIsSand(true);
                            canvas.getNodes()[y][x].setIsSand(false);

                            // Select div with the same coordinates as the new node
                            const old_node_element = $('[data-x="' + x + '"][data-y="' + y + '"]');
                            const new_node_element = $('[data-x="' + (x + 1) + '"][data-y="' + (y + 1) + '"]');

                            // Change node background color
                            old_node_element.css("background-color", canvas.getNodes()[y][x].getColor());
                            new_node_element.css("background-color", canvas.getNodes()[y][x + 1].getColor());
                        }
                    }
                }
            }
        }
    }

    calculateCellSize() {
        //get screen width in pixels
        let screenHeight = window.innerHeight;
        let screenWidth = window.innerWidth;

        //substract 50px to have a margin
        screenWidth -= 50;
        screenHeight -= 100;

        //Spread the amount of cells over the available width
        const amountOfCellsWide = $('#canvas-width').val();
        const amountOfCellsHigh = $('#canvas-height').val();

        let cell_width = Math.floor(screenWidth / amountOfCellsWide);
        let cell_height = Math.floor(screenHeight / amountOfCellsHigh);

        //get lowest of the two since cells must always be square
        const cell_size = Math.min(cell_width, cell_height);

        return cell_size;
    }

    setCellSize(size) {
        $(".node").width(size + 'px');
        $(".node").height(size + 'px')
    }
}

class Node {
    #x;
    #y;
    #color = "";
    #isSand;

    constructor(x, y, color, isSand) {
        this.#x = x
        this.#y = y;
        this.#color = color;
        this.#isSand = isSand;
    }

    getX() {
        return parseInt(this.#x);
    }

    getY() {
        return parseInt(this.#y);
    }

    getColor() {
        return this.#color;
    }

    getIsSand() {
        return this.#isSand;
    }

    setIsSand(bool) {
        this.#isSand = bool;
        if (this.#isSand === true) {
            this.setColor(start_color);
        } else {
            this.setColor('#ffffff');
        }
    }

    setColor(color) {
        this.#color = color;
    }

}



function tick() {
    canvas.shiftSand();
    start_color = incrementColor(start_color);
    function incrementHexValue(hexValue) {
        // Increment the value and ensure it wraps around correctly
        return ('0' + (parseInt(hexValue, 16) + 5).toString(16)).slice(-2);
    }

    function decreaseHexValue(hexValue) {
        // Increment the value and ensure it wraps around correctly
        return ('0' + (parseInt(hexValue, 16) - 5).toString(16)).slice(-2);
    }

    // Function to increment a hexadecimal color by 1
    function incrementColor(color) {
        // Remove '#' if present
        color = color.replace('#', '');

        // Split the color into RGB components
        var r = color.substring(0, 2);
        var g = color.substring(2, 4);
        var b = color.substring(4, 6);

 
        if (color == '000000') {
            operator = '+';
        }

        if (color == 'ffffbe') {
            operator = '-';
        }



        // Increment each component
        if (operator === '+') {
            if (r !== 'ff') {
                r = incrementHexValue(r);
            } else if (g !== 'ff') {
                g = incrementHexValue(g);
            } else if (b !== 'ff') {
                b = incrementHexValue(b);
            }
        } else {
            if (r !== '00') {
                r = decreaseHexValue(r);
            } else if (g !== '00') {
                g = decreaseHexValue(g);
            } else if (b !== '00') {
                b = decreaseHexValue(b);
            }
        }


        // Return the incremented color in hexadecimal format
        return '#' + r + g + b;
    }
}

//check if mouse is down

let mouseDown = 0;
$('#canvas').on('mousedown', function () {
    mouseDown = true;
});

$('#canvas').on('mouseup', function () {
    mouseDown = false;
});




//Generate field
let start_color = '#000000';
let operator = '+';
let canvas = new Canvas(50, 50);
canvas.generateCanvas();
let timer = setInterval(tick, 50);

//  Schaal het speelveld automatisch als het scherm word geresized, ook tijdens het spelen
addEventListener("resize", (event) => {
    canvas.setCellSize(canvas.calculateCellSize());
});
onresize = (event) => {
    canvas.setCellSize(canvas.calculateCellSize());
};


$('#apply').click(function () {
    canvas = new Canvas($('#canvas-height').val(), $('#canvas-width').val());
    canvas.generateCanvas();
    clearInterval(timer);
    timer = setInterval(tick, $('#tick-speed').val());
});
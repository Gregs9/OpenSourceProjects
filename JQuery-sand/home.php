<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sand Simulator</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="sand.js" defer></script>
    <link rel="stylesheet" href="home.css">
</head>

<body>
    <h1>Sand Simulator</h1>
    <!--The canvas-->
    <div id="canvas">

    </div>

    <!--Parameters for the canvas-->
    <div id="parameters">
        <h1>Parameters</h1>
        <!--Canvas height-->
        <label for="canvas-height">Height</label>
        <input id="canvas-height" name="canvas-height" type="number" value="50" min="20" max="200"
            placeholder="height..">

        <!--Canvas width-->
        <label for="canvas-width">Width</label>
        <input id="canvas-width" name="canvas-width" type="number" value="50" min="20" max="200" placeholder="width..">

        <!--Tick speed-->
        <label for="tick-speed">Speed (ms)</label>
        <input id="tick-speed" name="tick-speed" type="number" value="50" min="10" max="200" placeholder="speed..">

        <!--Apply button-->
        <button id="apply">Reset & Apply</button>
    </div>





</body>

</html>
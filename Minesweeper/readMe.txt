
___  ____                                                   
|  \/  (_)                                                  
| .  . |_ _ __   ___  _____      _____  ___ _ __   ___ _ __ 
| |\/| | | '_ \ / _ \/ __\ \ /\ / / _ \/ _ \ '_ \ / _ \ '__|
| |  | | | | | |  __/\__ \\ V  V /  __/  __/ |_) |  __/ |   
\_|  |_/_|_| |_|\___||___/ \_/\_/ \___|\___| .__/ \___|_|   
                                           | |              
                                           |_|              

DEVELOPER DOCUMENTATION
Gregory Hermans
12/02/2024

Introduction
This documentation will explain the structure and inner workings of this Minesweeper re-creation I made using JavaScript with Jquery.

Disclaimer
This application utilizes various assets including but not limited to images, logos, trademarks, and other intellectual property. All such assets belong to their respective owners. The use of these assets within this application is for educative purposes only and does not imply ownership or endorsement by the creators of this application.

Structure
• root/home.php
contains all elements require to present the user with an UI.

• root/assets
Assets contains all images, sound effects (sfx), music, fonts and some additional resources used for development like the photoshop file (.psd). In larger scale applications, each type of asset should be subdivided in additional folders, like "sfx", "music", "images", "resources" and so on. Since this is a very small application, it is not required to further order the assets used.

• root/css
Contains all the css files used for this application. Since this is a small single-page application, we can easily combine all required css into a single file. Again, for larger scale applications, the use of a css framework, or at least division between css files is recommended.

• root/JS
This directory contains all JavaScript files, required to run the application.




home.php:
This is a simple html presentation file, that contains all the basic UI elements the user needs. Note that it is indeed a php file, but html would have worked just as well in this scenario. The reason I chose for PHP is that it would be easier to add additional features in the future should I wish to do so.

>head
Contains basic html structure like charset, title, page icon, and references to all the required files like css, js and jQuery.

>audio elements
These (invisible) audio elements will be used by JavaScript to play sound effects and music. Since we occasionally need to play multiple sound effects at the same time, we need multiple audio elements. A single audio element cannot play multiple sounds simultaneously. We have a single audio element that will play the music, and two additional audio elements that will play sound effects.

>UI
We present the user with several slides, which they can use to adjust the amount of horizontal and vertical nodes. Additionally, there is a bomb ratio slider, which will increase or decrease the amount of bombs placed on the field. More on this later.

The user can also adjust the volume of the music, and sound effects separately. Since we use multiple audio elements, the user can adjust these volumes individually, which allows for better balance in volume between sfx and music.

>Game
Next, we have invisible elements, the first one contains 2 more elements for displaying the time spent, and flags the user has named "game_info".
Next, we have two invisible elements, that contains the message that either the player lost, or won with a replay button. On of these two screens will be displayed once the player has won or lost the game. More on this later.
Finally, we have a grid that will contain all nodes created by Javascript and display them inside of this element.

JavaScript
Inside the JS folder, you will see two Javascript files, one named "UI" and the other named "Minesweeper".

The UI file is loaded first, which will set a session variable for each setting the user may have adjusted. If the user has changed a setting, this will be saved in a session variable. This will prevent the user from having to re-adjust each setting once they reload the page.
These settings are also loaded once the home page reloads.

Also, the invisible replay buttons on the win and lose screen are set to reload the page when they are pressed. This will re-execute all code and is an easy way to reset the game.


Finally, we will take a look at the Minesweeper.JS file, this file contains all logic for playing minesweeper. This game consists out of three classes (objects) Field, Node, and SFX.

The field object has a height and width property, which is the width and height of the grid set by the user. You will also see an array grid as a property, which is a two-dimensional array (matrix or grid) that contains rows and columns of the node object.
See that the state of each node is a property of the node object, and the field has a drawGrid() method, which will draw the current state of the grid from memory.

Before we go into detail how the grid is generated, we need to understand the Node object. A node is an object or one individual cell inside our array, which contains several properties and states.
The node object has several properties:
x & y: the coordinates of the node
isBomb: whether or not the node is a bomb
revealed: whether the node has been revealed (clicked by the player)
proximity: the amount of neighboring nodes that are bombs
flagged: whether a node is flagged or not (right clicked by the player will set a flag)
All these properties can be get and set by the Node object's methods.

Let's take a closer look how the grid is generated (generateGrid()). We generate a matrix using the height and width provided by the user and create a node object for each iteration. Each node's coordinates (x and y values) are set, and their isBomb property is set to false. We will change this next.

We then calculate the number of bombs. The bomb ratio value provided by the user is the percentage of nodes that are bombs in the total surface area of the grid (height*width)
For example, if the user has set a height and width of 10, and a bomb ratio of 15, 15 bombs will be placed inside the grid, because 15% of (10*10) = 15.

we also provide the user with an number of flags equal to the amount of bombs, which they can use to mark nodes that they think are bombs.

In order to randomly select the nodes that are bombs, we use the flat() method to convert out two-dimensional grid into a single dimensional grid. We than shuffle this array, and select the first x number of nodes, where x is the amount of bombs we calculated using the slice method.
We loop through these randomly selected nodes and set their isBomb state to true.

Next, we will determine each node's proximity number. The proximity number is the number of bombs that are neighboring the selected node. For example, the selected node is n:

X|.|.
.|n|x
.|x|.

n's proximity number will be 3, since it is neighbored by three nodes that are bombs.

in the generateProximityNumbers() function, we will loop through each node, and check how many of it's neighbors are bombs. The result will be the node's proximity number. This includes some checking for the grid's borders, of course.

Before we start drawing the canvas, we want to make sure each drawn node fits properly on the user's screen. I added an eventListener to the page, that will trigger the determineCellSize() function every time the user's resizes their screen. The first time the application is loaded, it will also trigger this function.

Let's take a look at the determineCellSize() function.
this function will get the user's screen height and width, and subtract a small margin from each side for tolerance. We will calculate the height and width of any given cell, by dividing the available screen height and width by the grid's height and width.
Since each node has to be square, we will get the lowest value (either height or width) and this value will be our size for the node.
We set each drawn node's (class "cell") height and width to the calculated size, and make sure the grid fits well around the grid, by setting the grid's width to the cell's size times the width of the grid.
To fit the UI properly above the canvas, the game's info's width is set to the same size as the grid.


We now have a matrix containing node objects with all their states.
All that is left, is to visualize this matrix to the user. The initial matrix is drawn with the drawGrid() method.
We will start by emptying the existing grid element, and loop through each node in the matrix. We will then create the node element, with it's coordinates as dataset values, so we can easily access these elements when we need them. Then, we will check each state of each node. We will check if it is a flag or a bomb, and if it is neither, we will display that node's proximity number instead. When a certain state is set, we will display the according image, using the addClass() method. In the css file, each state has a styling attached to it, so we can style each node with the state that it is.

If the node is already revealed, we will not add left and right click events to this element. A node that is revealed should no longer be clickable. A revealed node that is a bomb, will always result in a loss and prevent the player from continuing. In case a node is not revealed, we will add a left and right click event. The rightClick() method, allows the user to place a flag on a node they suspect is a bomb. We will check if the node is already flagged, and if the player has flags left to place. Based on these conditions users can toggle a flag on a cell that hasn't been revealed. We display the flag by adding the node to the "flagged" css class. And redraw the updated state of the node matrix.

On left click, we simply reveal the node, and if it is a bomb, we will display the bomb and trigger the lose() function, which will inform the user they have lost the game.

Continuing in the drawGrid() function, once we have or haven't added the click events, we will add this node element to the grid, and trigger the revealNeighbouringZeros() function.
In Minesweeper, when you click a node where all of its neighbors are not bombs, it will reveal those neighboring nodes as well. This can trigger a chain reaction revealing a significant portion of the grid. This function will check for that chain reaction.
The revealNeighbouringZeros() function will iterate over every node in the array in reverse order, and check if the node is revealed, if the node is revealed, and it's proximity is 0, it will reveal it's neighbors.

Now, there is a minor bug that prevents the top left cell from being revealed this way. This could potentially be solved by re-iterating over every node and checking their state again. However, to increase performance, I manually select the top left node, and check if its state is revealed, and display the proper proximity if so.

Finally, we will call the checkVictory() method, which will check if each node that is not a bomb, has been revealed. Note that the player doesn't necessarily have to flag all the bombs, simply revealing all nodes that aren't bombs is enough to win the game.

Extras:
In order to display the time, the player has spent on their current game, I added a timer that will update each second and increase the spent time by one second. This way the user can keep track of the time they spent on this game. In future updates, we could calculate a player score using this time.

I also created a SFX object, which is used to play all music and sound effects. This object has the music and sfx element as a property, and the music and sfx volume as a property.
All methods in this function are called when music or a sound effect should be played, by simply setting the source of this element to the correct asset and playing it.





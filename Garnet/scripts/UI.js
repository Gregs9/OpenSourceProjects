"use strict";
//For hiding the notification on click
$('#feedback').click(function () {
    $(this).hide();
});

//For cookies
$('#accept-cookies').on('click', function () {
    let now = new Date();
    now.setTime(now.getTime() + 1000 * 36000);
    document.cookie = 'accept-cookie=true;expires=' + now.toUTCString();
    $('#cookie-notification').css('display', 'none');
});



//For showing the report form
$('#report-video-icon').on('click', function () {
    $('#report-video-form').toggle();
});

//For popping in & out the control panel
$('#control_panel_options').toggle(false);
sessionStorage.getItem("popout") ? $('#control_panel_options').toggle(sessionStorage.getItem("popout") === "true") : null;
$('#control_panel').click(function () {
    $('#control_panel_options').toggle();
    sessionStorage.setItem("popout", $('#control_panel_options').is(':visible') ? "true" : "false");
    //if profile panel is open, hide it
    if ($('#profile_panel_options').is(':visible')) {
        $('#profile_panel_options').toggle();
        sessionStorage.setItem("popout-profile", $('#profile_panel_options').is(':visible') ? "true" : "false");
    }
});

//For popping in & out the profile panel
$('#profile_panel_options').toggle(false);
sessionStorage.getItem("popout") ? $('#profile_panel_options').toggle(sessionStorage.getItem("popout-profile") === "true") : null;
$('#profile').click(function () {
    $('#profile_panel_options').toggle();
    sessionStorage.setItem("popout-profile", $('#profile_panel_options').is(':visible') ? "true" : "false");
    //if control panel is open, hide it
    if ($('#control_panel_options').is(':visible')) {
        $('#control_panel_options').toggle();
        sessionStorage.setItem("popout", $('#control_panel_options').is(':visible') ? "true" : "false");
    }
});

//  For copying to clipboard
$('#copy-to-clipboard').on('click', function () {
    $('#filename').setSelectionRange(0, 99999); // For mobile devices
    navigator.clipboard.writeText($('#filename').val());
});


//Add placeholders for video uploading
const videoTitlePlaceholders = [
    "The Great Spatula Showdown: Flipping Out for Glory",
    "Feline Fashion Show: Cats in Bow Ties and Top Hats",
    "Toothbrush Tango: Dancing with Dental Hygiene",
    "Squirrel Ninja Warrior: Obstacle Course for the Nutty",
    "Beekeeping for Beginners: A Sticky Situation",
    "The Art of Balloon Animal Zen: Mastering the Inflatable",
    "Penguin Disco Fever: Shaking Tail Feathers on Ice",
    "Extreme Pillow Fighting Championships: Bedtime Brawls",
    "The Mystery of Missing Left Socks: A Sock-umentary",
    "The Great Rubber Ducky Race: Quacking for Victory",
    "Dance-Off with Robots: Humans vs. AI",
    "Accordion Aerobics: Squeezing in a Workout",
    "Jellybean Jenga: Sweet Tower of Instability",
    "The World's Tiniest Violin Concert: Miniature Maestros",
    "Puppy Opera: Canine Choir in Concert",
    "Garden Gnome Olympics: Tiny Athletes, Big Dreams",
    "The Epic Battle of the Dancing Fruit Bowls",
    "Pirate Parrots on Parade: Feathered Buccaneers",
    "Competitive Hula Hooping: Circling for Victory",
    "Toilet Paper Mummy Makeover: From Drab to Fab",
    "Tea Bag Tag Team Wrestling: Brewing up a Fight",
    "Synchronized Swimming with Goldfish: Aquatic Elegance",
    "Unicorn Hair Braiding Tutorial: Enchanting Styles",
    "The Great Banana Phone Challenge: Dialing Up the Laughs",
    "Zombie Apocalypse Survival Guide: Using Everyday Household Items",
    "The World's Slowest Marathon: Racing at a Snail's Pace",
    "Gourmet Bug Tasting: Exploring the World of Edible Insects",
    "The Great Thumb Wrestling Championship: Thumbs of Fury",
    "Breakdancing Grandma: When Hip-Hop Meets Hip Replacement",
    "Unicorn Petting Zoo: Sparkles and Rainbows Galore",
    "Potato Sack Racing on Stilts: A Balancing Act",
    "Spaghetti Lasso Championships: Roping in Noodles",
    "Synchronized Snail Racing: Slow and Furious",
    "The Great Emoji War: Emoticons vs. Memes",
    "The Secret Life of Rubber Ducks: A Tell-All Documentary",
    "Cooking with a Flamethrower: Gourmet Grilling Like You've Never Seen Before!",
    "Tropical Fruit Choir: When Pineapples and Mangoes Sing in Harmony",
    "DIY Sharknado Shelter Building: Are You Prepared?",
    "Wacky Hairdos of History: From Marie Antoinette to Einstein's Bad Hair Day",
    "World Record for Most Confused Pigeons in a Park",
    "Dancing Bananas: The Fruit That Grooves",
    "Toilet Paper Olympics: Unrolling the Gold Medal",
    "Zombie Apocalypse Survival Guide: Using Everyday Household Items",
    "Tropical Fruit Choir: When Pineapples and Mangoes Sing in Harmony",
    "Invisible Ink Unboxing: What's Inside the Empty Box?",
    "Time-Traveling Hamster: An Adventure Through the Space-Time Wheel",
    "Wacky Hairdos of History: From Marie Antoinette to Einstein's Bad Hair Day",
    "The Quest for the Lost TV Remote: A Hero's Journey through Couch Cushions",
    "Pineapple Undercover: A Spy Fruit's Adventures",
    "Famous Paintings Recreated with Balloon Animals: Artistic Inflation",
    "Cooking with Robots: Mechanical Chefs Gone Wild",
    "The Great Laundry Basket Grand Prix: Racing Dirty",
    "The World's Most Epic Sock Puppet Battle",
    "Guitar-Playing Hamsters: Tiny Rock Stars in Action",
    "Underwater Pumpkin Carving: Jack-o'-Lanterns Take the Plunge",
    "Competitive Ice Cream Eating: Brain Freeze Showdown",
    "The Great Bubblegum Bubble-Off: Blowing Bigger Bubbles",
    "Supermarket Sweep with a Twist: Ninja Grocery Shopping",
    "Chia Pet Fashion Show: The Green Carpet Event",
    "Ketchup Bottle Orchestra: Squeezing out Musical Genius",
    "The Great Rubber Duck Regatta: Quacktastic Racing",
    "Penguin Olympics: Waddling to Glory",
    "Synchronized Swinging: Playground Gymnastics",
    "The World's Tiniest Cupcake Challenge: Miniature Baking Extravaganza",
    "Fruit Ninja: Real-Life Fruit Slicing Action",
    "Breakdancing Babies: Toddler Turntable Dance Battle",
    "Rock, Paper, Scissors Championship: Throwing Down the Gauntlet",
    "The Great Skateboard Bulldog Showdown",
    "The Secret Lives of Garden Gnomes: A Tell-All Documentary",
    "Gummy Bear Opera: A Chewy Serenade",
    "Extreme Tricycle Racing: Three-Wheeled Speedsters",
    "The World's Fastest Snail: Turbo in Action",
    "The Great Spatula Olympics: Fl",
    "The Descent Into Madness By A Crazy Developer"
];
const videoDescriptionPlaceholders = [
    "Honey never spoils. Archaeologists have found pots of honey in ancient Egyptian tombs that are over 3,000 years old and still perfectly edible.",
    "Octopuses have three hearts. Two pump blood to the gills, while the third pumps it to the rest of the body.",
    "Cows have best friends and can become stressed when they are separated from them.",
    "A group of flamingos is called a 'flamboyance.'",
    "In Switzerland, it is illegal to own just one guinea pig because they are prone to loneliness.",
    "Bananas are berries, but strawberries aren't.",
    "Polar bears' skin is black, and their fur is not actually white; it's translucent.",
    "The Eiffel Tower can be 15 cm taller during the summer due to the expansion of the iron in the heat.",
    "The shortest war in history was between Britain and Zanzibar on August 27, 1896. Zanzibar surrendered after 38 minutes.",
    "A day on Venus is longer than a year on Venus. It takes Venus 243 Earth days to complete one rotation and 225 Earth days to orbit the Sun.",
    "Hippopotamus milk is pink.",
    "The 'S' in Harry S. Truman's name doesn't stand for anything. His parents gave him the middle initial as a tribute to both of his grandfathers, Anderson Shipp Truman and Solomon Young.",
    "The Great Wall of China is not visible from space to the naked eye.",
    "Wombat feces are cube-shaped, which helps them mark their territory by preventing the droppings from rolling away.",
    "The dot over the letter 'i' is called a 'tittle.'",
    "Coca-Cola was originally green.",
    "A newborn kangaroo is about 1 inch long.",
    "A 'jiffy' is an actual unit of time for 1/100th of a second.",
    "The longest time between two twins being born is 87 days.",
    "The unicorn is the national animal of Scotland.",
    "Banging your head against a wall burns 150 calories an hour.",
    "The oldest known sample of the smallpox virus was found in the teeth of a 17th-century child buried in Lithuania.",
    "Bees can recognize human faces.",
    "Cleopatra was born closer to the invention of the iPhone than to the construction of the Great Pyramid of Giza.",
    "The longest English word without a vowel is 'rhythms.'",
    "The pineapple is a symbol of hospitality.",
    "The first recorded game of baseball was played in 1846 in Hoboken, New Jersey.",
    "Sea otters hold hands while sleeping to keep from drifting apart.",
    "The world's largest desert is not the Sahara but Antarctica.",
    "The first recorded instance of a 'high five' was in 1977.",
    "The shortest war in history was between Britain and Zanzibar on August 27, 1896. Zanzibar surrendered after 38 minutes.",
    "A crocodile cannot stick its tongue out.",
    "A group of pugs is called a 'grumble.'",
    "Bananas are berries, but strawberries aren't.",
    "Hawaii is the only U.S. state that commercially grows coffee.",
    "The world's smallest mammal is the bumblebee bat.",
    "The inventor of the Pringles can was buried in a Pringles can.",
    "A day on Venus is longer than a year on Venus. It takes Venus 243 Earth days to complete one rotation and 225 Earth days to orbit the Sun.",
    "The Great Wall of China is not visible from space to the naked eye.",
    "Cows have best friends and can become stressed when they are separated from them.",
    "A day on Venus is longer than a year on Venus. It takes Venus 243 Earth days to complete one rotation and 225 Earth days to orbit the Sun.",
    "Octopuses have three hearts. Two pump blood to the gills, while the third pumps it to the rest of the body.",
    "Honey never spoils. Archaeologists have found pots of honey in ancient Egyptian tombs that are over 3,000 years old and still perfectly edible.",
    "Bananas are berries, but strawberries aren't.",
    "Cows have best friends and can become stressed when they are separated from them.",
    "The Eiffel Tower can be 15 cm taller during the summer due to the expansion of the iron in the heat.",
    "Polar bears' skin is black, and their fur is not actually white; it's translucent.",
    "The shortest war in history was between Britain and Zanzibar on August 27, 1896. Zanzibar surrendered after 38 minutes.",
    "Cows have best friends and can become stressed when they are separated from them.",
    "A group of flamingos is called a 'flamboyance.'",
    "The dot over the letter 'i' is called a 'tittle.'",
    "In Switzerland, it is illegal to own just one guinea pig because they are prone to loneliness.",
    "Octopuses have three hearts. Two pump blood to the gills, while the third pumps it to the rest of the body.",
    "A newborn kangaroo is about 1 inch long.",
    "The 'S' in Harry S. Truman's name doesn't stand for anything. His parents gave him the middle initial as a tribute to both of his grandfathers, Anderson Shipp Truman and Solomon Young.",
    "Bees can recognize human faces.",
    "The Great Wall of China is not visible from space to the naked eye.",
    "Wombat feces are cube-shaped, which helps them mark their territory by preventing the droppings from rolling away.",
    "Coca-Cola was originally green.",
    "Cleopatra was born closer to the invention of the iPhone than to the construction of the Great Pyramid of Giza.",
    "The unicorn is the national animal of Scotland.",
    "The pineapple is a symbol of hospitality.",
    "The first recorded game of baseball was played in 1846 in Hoboken, New Jersey.",
    "Sea otters hold hands while sleeping to keep from drifting apart.",
    "The world's largest desert is not the Sahara but Antarctica.",
    "A 'jiffy' is an actual unit of time for 1/100th of a second.",
    "The longest time between two twins being born is 87 days.",
    "The first recorded instance of a 'high five' was in 1977.",
    "The inventor of the Pringles can was buried in a Pringles can.",
    "A group of pugs is called a 'grumble.'",
    "Hawaii is the only U.S. state that commercially grows coffee.",
    "The world's smallest mammal is the bumblebee bat.",
    "This website is a dream come true, but dreams are never meant to be reached."
];

$('#title').attr('placeholder', 'e.g. ' + videoTitlePlaceholders[(Math.floor(Math.random() * videoTitlePlaceholders.length))]);
$('#description').attr('placeholder', 'e.g. ' + videoDescriptionPlaceholders[(Math.floor(Math.random() * videoDescriptionPlaceholders.length))]);


//FOR ADDING A NEW TAG
$('#input-new-tag-weight').on('change input', function () {
    correctInput($('#input-new-tag-weight'));
});

function correctInput(element) {
    if (parseInt(element.val()) > 10) {
        element.val(10);
    }
    if (parseInt(element.val()) < 0) {
        element.val(0);
    }
    if (element.val() == '') {
        element.val(0);
    }
    if (element.val().length > 2) {
        element.val(10);
    }
}

//Mainting underline effect of the header links when on that page
$('a.linkHeader').each(function () {
    if (this.href === window.location.href) {
        $(this).addClass('activePage');
    }
});
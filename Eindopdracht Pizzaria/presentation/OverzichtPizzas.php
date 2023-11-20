<?php
declare(strict_types=1);

?>

<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Scorchini's</title>
    <link rel="stylesheet" href="css/global.css">
    <link rel="stylesheet" href="css/home.css">
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
</head>

<body>
    <?php include('includes/header.php') ?>
    <?php include('includes/caddy.php') ?>

    <div class="wrapper">
        <h1>Pizzas!</h1>
        <main id="overzicht">
            <?php
                foreach ($lijst_pizzas as $pizza) {
                    echo '<div data-id="' . $pizza->getId() . '" data-naam="' . $pizza->getNaam() . '" data-prijs="' . $pizza->getPrijs() . '" class="pizza-info">';
                    echo '<h2>' . $pizza->getNaam() . '</h2>';
                    echo '<img class="thumbnail" src="assets/' . $pizza->getNaam() . '.png">';
                    echo '<p>€ ' . $pizza->getPrijs() . '</p>';
                    echo '<p>Ingrediënten: ' . $pizza->getIngdienten() . '</p>';
                    echo '<p>Allergenen: ' . $pizza->getAllergenen() . '</p>';
                    echo '</div>';
                }
                
            ?>
        </main>
    </div>
    <?php include('includes/footer.php') ?>
</body>

</html>
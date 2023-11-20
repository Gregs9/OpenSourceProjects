<?php
declare(strict_types=1);

?>

<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Scorchini's</title>
    <link rel="stylesheet" href="css/global.css">
    <link rel="stylesheet" href="css/afrekenen.css">
    <script src="scripts/afrekenen.js" defer></script>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
</head>

<body>
    <?php include('includes/header.php') ?>
    <div class="wrapper">
        <h1 class="titel">Overzicht</h1>
        <p id="feedback"></p>
        <main id="overzicht">
            <?php
            foreach ($Orders as $orderLine) {
                echo
                    '<div data-order_object=' . str_replace(' ', '_', json_encode($orderLine)) . '" class="pizza-info">' .
                    '<img class="thumbnail" src="assets/' . $orderLine->naam . '.png">' .
                    '<p>Pizza ' . $orderLine->naam . '</p><br><br>' .
                    '<p>Aantal: <input id="inputAantal" class="aantal" type="number" min="0" max="99" required value="' . $orderLine->aantal . '"></input>Stuk(s)</p><br>' .
                    '<p>Prijs per stuk: €' . $orderLine->prijs . '</p><br><br>' .
                    '<p>Ingrediënten: ' . $pizzaSvc->getPizzaById(intval($orderLine->id))->getIngdienten() . '</p><br>' .
                    '<p>Allergenen: ' . $pizzaSvc->getPizzaById(intval($orderLine->id))->getAllergenen() . '</p>' .
                    '</div>';
            }
            ?>

            <div id="outer">
                <button class="button" id="update-caddy">Update winkelmand</button>
            </div>

            <?php 
            echo '<h2 class="titel">Totaal: €' . number_format($totaalBedrag, 2) . '</h2>'; 
            echo '<h2 class="titel">Korting: ' . $user->getKortingsTarief(). '%</h2>'; 
            echo '<h2 class="titel">Te betalen: €' . number_format($teBetalen, 2) . '</h2>'; 
            ?>

            <div id="lever-info">
                <p><u>Leveren naar:</u> </p>
                <p id="full-name">
                    <?php echo $user->getFamilienaam() . ' ' . $user->getVoornaam() ?>
                </p>
                <p id="address">
                    <?php echo $user->getAdres() ?>
                </p>
                <p id="city">
                    <?php echo $plaatsSvc->getPlaatsById($user->getPlaatsId())->getPostcode() . ' ' . $plaatsSvc->getPlaatsById($user->getPlaatsId())->getNaam() ?>
                </p>

                <br>

                <a id="wijzig-adres" class="button" href="#">wijzig</a>

                <br>
                <br>
                <br>

                <p>Opmerking</p>

                <br>

                <textarea id="comment" max-length="255"></textarea>

                <br>
                <br>
                
                <a id="bestel-link" class="button" href="afrekenen.php?action=bestel">Bestelling plaatsen</a>
            </div>

            <form id="wijzig-info" style="display:none" method="post" action="afrekenen.php?action=wijzigAdres">
                <label for="wijzig_adres">Straat en Huisnr <input name="wijzig_adres" minlength="5" maxlength="45"
                        required type="text" value="<?php echo $user->getAdres(); ?>"></input></label>
                <br>
                <label for="wijzig_postcode">Postcode <input name="wijzig_postcode" type="text" minlength="4" required
                        maxlength="4"
                        value="<?php echo $plaatsSvc->getPlaatsById($user->getPlaatsId())->getPostcode(); ?>"></input></label>
                <br>
                <label for="wijzig_gemeente">Gemeente <input name="wijzig_gemeente" type="text" minlength="2"
                        maxlength="45" required
                        value="<?php echo $plaatsSvc->getPlaatsById($user->getPlaatsId())->getNaam(); ?>"></input></label>
                <br>
                <input id="bevestig" class="button" type="submit" value="Bevestig">
                <a id="annuleren" class="button" href="#">Annuleren</a>
            </form>

        </main>

    </div>

    <?php include('includes/footer.php') ?>

</body>

</html>
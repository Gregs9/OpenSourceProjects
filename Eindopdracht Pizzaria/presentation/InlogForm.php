<?php
declare(strict_types=1);

?>


<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Scorchini's Login</title>
    <link rel="stylesheet" href="css/global.css">
    <link rel="stylesheet" href="css/inlogform.css">
    <script src="scripts/inlogformulier.js" defer></script>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
</head>

<body>
    <?php include('includes/header.php'); ?>
    <!--START WRAPPER-->
    <div class="wrapper">
    <div id="forms">
        <form method="post" id="login" action="inloggen.php?action=login">

            <h1>Ik heb een account</h1>

            <label for="log_email">Email adres</label>
            <input type="email" id="log_email" name="log_email" placeholder="Je email.." required maxlength="50">

            <br>

            <label for="log_password">Wachtwoord</label>
            <input type="password" id="log_password" name="log_password" placeholder="Je wachtwoord.." required
                maxlength="50" minlength="8">

            <br>

            <input type="submit" value="Verder naar afrekenen" class="button">

        </form>


        
            <form method="post" id="register" action="inloggen.php?action=register">

                <h1>Ik heb geen account</h1>

                <label for="reg_familienaam">Familienaam</label>
                <input type="text" id="reg_familienaam" name="reg_familienaam" placeholder="Je familienaam.." required
                    maxlength="45">

                <br>

                <label for="reg_voornaam">Voornaam</label>
                <input type="text" id="reg_voornaam" name="reg_voornaam" placeholder="Je voornaam.." required
                    maxlength="45">

                <br>

                <label for="reg_adres">Straat + huisnr.</label>
                <input type="text" id="reg_adres" name="reg_adres" placeholder="Je straat + nummer.." required
                    maxlength="45">

                <br>

                <label for="reg_postcode">Postcode</label>
                <input type="text" id="reg_postcode" name="reg_postcode" placeholder="Je postcode.." required
                    maxlength="4">

                <br>

                <label for="reg_gemeente">Gemeente</label>
                <input type="text" id="reg_gemeente" name="reg_gemeente" placeholder="Je gemeente.." required
                    maxlength="45">

                <br>

                <label for="reg_tel">Telefoon</label>
                <input type="text" id="reg_tel" name="reg_tel" placeholder="Je telefoonnummer.." required
                    maxlength="45">

                <br>

                <label id="checkbox"><input type="checkbox" id="registreer" name="registreer"></input> Maak een account
                    aan</label>

                <br>

                <div id="include-register">

                    <label for="reg_email">Email adres</label>
                    <input type="email" id="reg_email" name="reg_email" placeholder="Je email.." maxlength="50">

                    <br>

                    <label for="reg_password">Wachtwoord</label>
                    <input type="password" id="reg_password" name="reg_password" placeholder="Je wachtwoord.."
                        maxlength="50">

                    <br>

                    <label for="reg_password2">Herhaal wachtwoord</label>
                    <input type="password" id="reg_password2" name="reg_password2" placeholder="Je wachtwoord.."
                        maxlength="50">

                    <br>

                </div>

                <input type="submit" value="Verder naar afrekenen" class="button">

            </form>
        </div>
        <p id="feedback"></p>


    </div>
    <!--END WRAPPER-->
    <?php include('includes/footer.php'); ?>
</body>

</html>
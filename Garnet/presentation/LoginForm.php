<!DOCTYPE html>
<html lang="en">

<head>
    <title>The Garnet: Login</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
    <link href="css/pages/login.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="scripts/UI.js" defer></script>
</head>

<body>
    <div class="wrapper">
        <img src="assets/logo.png" id="logo" alt="logo">

        <a href="about" target="_blank" class="regular-link">What is this?</a>

        <form method="post" id="login" action="login.php?action=login">

            <h1>LOG IN</h1>

            <input type="text" id="log_username" name="log_username" placeholder="Username.." required maxlength="50">

            <br>

            <input type="password" id="log_password" name="log_password" placeholder="Password.." required
                maxlength="50" minlength="8">

            <br>

            <input type="submit" value="Login" class="button">

        </form>

        <form method="post" id="register" action="login.php?action=register">

            <h1>REGISTER</h1>

            <input type="text" id="reg_username" name="reg_username" placeholder="Username.." required maxlength="45">

            <br>

            <input type="password" id="reg_password" name="reg_password" placeholder="Password.." required
                maxlength="50" minlength="8">

            <br>

            <input type="password" id="reg_password2" name="reg_password2" placeholder="Password.." required
                maxlength="50" minlength="8">

            <br>

            <input type="submit" value="Register" class="button">

        </form>
        <?php echo $feedback->getMessage(); ?>
    </div>
</body>

</html>
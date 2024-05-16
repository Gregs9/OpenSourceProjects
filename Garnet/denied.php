<?php
declare(strict_types=1);
require_once('components/authManager.php');
?>

<!DOCTYPE HTML>
<html>

<head>
  <link rel="stylesheet" href="css/GLOBAL.css">
  <title>The Garnet</title>
  <link rel="icon" href="assets/logo.ico" type="image/x-icon">
  <meta name="theme-color" content="#800000">
</head>

<body>

  <?php include('components/header.php'); ?>

  <!--START WRAPPER-->
  <div class="wrapper">
    <h1 style="width: 100%; text-align: center; padding-top: 2rem;">403 - Access Denied</h1>
    <img id="img-404" alt="403 Access denied" src="assets/acces_denied.png">
  </div>
  <!--END WRAPPER-->

  <?php include('components/footer.php'); ?>

</body>

</html>
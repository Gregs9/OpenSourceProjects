<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <title>The Garnet: Creators</title>
    <meta charset="UTF-8">
    <meta name="theme-color" content="#800000">
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/creators.css">
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <script src="scripts/creators_filter.js" defer></script>
</head>

<body>

    <?php include ('components/header.php'); ?>


    <div class="wrapper">

        <!--Select for sorting options-->
        <div id="creator-filters">
            <label for="creator-order-by">Order by</label>
            <select id="creator-order-by" name="creator-order-by">
                <option value="score desc">Highest score first</option>
                <option value="score asc">Lowest score first</option>
                <option value="name asc">Highest score first</option>
                <option value="date_of_birth desc">Youngest first</option>
                <option value="date_of_birth asc">Oldest first</option>
                <option selected value="occurrences desc">Most videos</option>
                <option value="occurrences asc">Least videos</option>
                <option value="views desc">Most views</option>
                <option value="views asc">Least views</option>
            </select>
            <br>

            <label for="search">Search</label>
            <input id="search-creator" class="input-element" name="search-creator" type="search" placeholder="Search.." title="Enter what you wish to search for." maxlength="100">

        </div>


        <!--Creators list populated by scripts/creators_filter.js-->
        <div id="creator-list">
        </div>

        <div class="pagination">
        </div>

    </div>
    <?php require_once ('components/Notification.php'); ?>
    <?php include ('components/footer.php'); ?>
</body>

</html>
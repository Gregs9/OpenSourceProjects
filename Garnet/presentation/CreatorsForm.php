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
</head>

<body>

    <?php include ('components/header.php'); ?>


    <div class="wrapper">

        <!--Select for sorting options-->
        <form method="post" action="creators" id="order-creators-by-container">
            <label for="creator-order-by">Order by</label>
            <select id="creator-order-by" name="creator-order-by">

                <!--If a order has been selected, which there always should be-->
                <?php
                //Determine which order has been selected, and get the text value based on that
                echo $order_by == "score desc" ? '<option selected value="score desc">Highest score first</option>' : '<option value="score desc">Highest score first</option>';
                echo $order_by == "score asc" ? '<option selected value="score asc">Lowest score first</option>' : '<option value="score asc">Lowest score first</option>';
                echo $order_by == 'name asc' ? '<option selected value="name asc">Alphabetically</option>' : '<option value="name asc">Alphabetically</option>';
                echo $order_by == 'date_of_birth desc' ? '<option selected value="date_of_birth desc">Youngest first</option>' : '<option value="date_of_birth desc">Youngest first</option>';
                echo $order_by == 'date_of_birth asc' ? '<option selected value="date_of_birth asc">Oldest first</option>' : '<option value="date_of_birth asc">Oldest first</option>';
                echo $order_by == 'occurrences desc' ? '<option selected value="occurrences desc">Most videos</option>' : '<option value="occurrences desc">Most videos</option>';
                echo $order_by == 'occurrences asc' ? '<option selected value="occurrences asc">Least videos</option>' : '<option value="occurrences asc">Least videos</option>';
                echo $order_by == 'views desc' ? '<option selected value="views desc">Most views</option>' : '<option value="views desc">Most views</option>';
                echo $order_by == 'views asc' ? '<option selected value="views asc">Least views</option>' : '<option value="views asc">Least views</option>';
                ?>
            </select>
            <br>

            <label for="search">Search</label>
            <input id="search-creator" name="search-creator" type="search" value="<?php if (isset($_SESSION['search-creator'])) {
                echo $_SESSION['search-creator'];
            } ?>" placeholder="Search.." title="Enter what you wish to search for." maxlength="100">

            <br>

            <input class="button" type="submit" value="go">
        </form>




        <?php foreach ($creator_list as $creator) {?>
            <div class="creator-container">

                <h2><?php echo $creator->getName(); ?></h2>

                <a href="creator?creator=<?php echo $creator->getId(); ?>">
                    <img class="creator-img" alt="" src="<?php echo $creator->getProfilePic() ?>">

                    <?php if ($creatorSvc->isBirthday($creator)) { ?>
                        <img class="party-hat" alt="" src="assets/party-hat.png">
                    <?php } ?>
                </a>

                <p class="creator-starred">Starred in
                    <?php echo $creatorSvc->getAmountStarredIn($creator); ?> videos
                </p>

            </div>
        <?php } ?>

        <div id="page_numbers">
            <?php
            if ($page > 1) {
                echo '<a href="creators?page=' . ($page - 1) . '"> < </a>';
            }
            for ($i = 1; $i <= $total_pages; $i++) {
                if ($i == $page) {
                    echo '<a class="active-page" href="creators?page=' . $i . '">' . $i . '</a>';
                } else {
                    echo '<a href="creators?page=' . $i . '">' . $i . '</a>';
                }
            }
            if ($page < $total_pages) {
                echo '<a href="creators?page=' . ($page + 1) . '"> > </a>';
            }
            ?>
        </div>

    </div>
    <?php include ('components/footer.php'); ?>
</body>

</html>
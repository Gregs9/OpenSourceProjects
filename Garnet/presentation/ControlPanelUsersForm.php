<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/control-panel.css">
    <title>The Garnet: Control panel</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
    <script src="scripts/warnings.js" defer></script>
    <script src="scripts/controlPanel_Searches.js" defer></script>
</head>

<body>

    <?php include('components/header.php'); ?>


    <div class="wrapper">

        <?php echo $feedback->getMessage(); ?>

        <!--USERS TABLE-->
        <h1 class="title">Users</h1>
        <div id="container-user-info" class="table-container">
            <div class="searchbar">
                <input title="Enter what you wish to search for." class="search" id="search-users" type="search"
                    placeholder="Search..">
            </div>
            <table id="table-user-info">
                <tr>
                    <th>ID</th>
                    <th>Username</th>
                    <th>Role</th>
                    <th>Creation</th>
                    <th>Status</th>
                </tr>
                <?php

                foreach ($userSvc->getUsers() as $user) {
                    echo
                        '
                    <tr>
                        <td>' . $user->getId() . '</td>
                        <td>' . $userSvc->getUserDeleteAction($user) . '</td>
                        <td>' . $userSvc->getUserRoleAction($user) . '</td>
                        <td>' . $user->getCreation()->format('Y-m-d H:i:s') . '</td>
                        <td>' . $userSvc->getUserStatusAction($user) . '</td>
                    </tr>';
                }

                ?>
            </table>
        </div>


    </div>
    <!--END WRAPPER-->

    <?php include('components/footer.php'); ?>

</body>

</html>
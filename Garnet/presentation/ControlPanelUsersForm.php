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

    <?php include ('components/header.php'); ?>


    <div class="wrapper">

        <!--USERS TABLE-->
        <h1 class="title">Users</h1>
        <div id="container-user-info" class="table-container">
            <?php include 'components/searchTable.php' ?>
            <table id="table-user-info">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Username</th>
                        <th>Role</th>
                        <th>Creation</th>
                        <th>Status</th>
                    </tr>
                </thead>

                <tbody>
                    <?php foreach ($userSvc->getUsers() as $user) { ?>
                        <tr>
                            <td><?= $user->getId() ?></td>
                            <td><?= $userSvc->getUserDeleteAction($user) ?></td>
                            <td><?= $userSvc->getUserRoleAction($user) ?></td>
                            <td><?= $user->getCreation()->format('Y-m-d H:i:s') ?></td>
                            <td><?= $userSvc->getUserStatusAction($user) ?></td>
                        </tr>
                    <?php } ?>
                </tbody>
            </table>
        </div>


    </div>
    <!--END WRAPPER-->
    <?php require_once ('components/Notification.php'); ?>
    <?php include ('components/footer.php'); ?>

</body>

</html>
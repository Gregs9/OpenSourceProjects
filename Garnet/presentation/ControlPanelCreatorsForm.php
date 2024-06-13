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
    <script src="scripts/controlPanel_Searches.js" defer></script>
</head>

<body>

    <?php include ('components/header.php'); ?>

    <div class="wrapper">

        <!--CREATORS TABLE-->
        <h1 class="title">Creators</h1>

        <form onsubmit="return confirm('Are you sure you want to add this creator?');" id="creator-adder"
            method="post" enctype="multipart/form-data" action="controlpanel-creators.php?action=add_creator">

            <h2>Add a new creator</h2>

            <!--CSRF protection token-->
            <?php require_once ('components/csrf_form_field.php'); ?>

            <!--CREATOR NAME-->
            <label for="input-new-creator">Name</label>
            <input class="input-element" title="Enter the name of the creator you want to add."
                id="input-new-creator" name="input-new-creator" type="text" placeholder="Enter creator's name.."
                minlength="1" maxlength="50" required>

            <!--CREATOR DESCRIPTION-->
            <label for="input-new-creator-description">Description</label>
            <textarea class="input-element" title="Enter the description of the creator you want to add."
                id="input-new-creator-description" name="input-new-creator-description" type="text"
                placeholder="Enter creator's description.." maxlength="2500"></textarea>

            <!--CREATOR PROFILE PIC-->
            <label for="thumbnailToUpload">Profile picture</label>
            <input class="input-element" title="Upload a profile picture for this creator." type="file"
                name="thumbnailToUpload" id="thumbnailToUpload" accept=".webp, .png, .jpg, .jpeg">

            <!--CREATOR ALIAS(ES)-->
            <label for="input-new-creator-alias">Alias(es)</label>
            <input class="input-element" title="Enter the alias(es) of the creator you want to add."
                id="input-new-creator-alias" name="input-new-creator-alias" type="text"
                placeholder="Enter creator's alias(es).." maxlength="50">

            <!--CREATOR DOB-->
            <label for="input-new-creator-dob">Date of birth</label>
            <input class="input-element" title="Enter the date of birth of the creator you want to add."
                id="input-new-creator-dob" name="input-new-creator-dob" type="date"
                placeholder="Enter creator's date of birth.." maxlength="50">

            <!--CREATOR NATIONALITY-->
            <label for="performat_nat">Nationality</label>
            <?php include ('components/nationalitySelector.php') ?>




            <h2>Socials</h2>

            <!--CREATOR SOCIAL IN-->
            <label for="input-new-creator-social_in">Instagram</label>
            <input class="input-element" title="Enter the Instagram link of the creator you want to add."
                id="input-new-creator-social_in" name="input-new-creator-social_in" type="url"
                placeholder="Enter creator's Instagram link.." maxlength="255"
                pattern="<?= $creatorSvc->getInPattern() ?>">

            <!--CREATOR SOCIAL X-->
            <label for="input-new-creator-social_x">X</label>
            <input class="input-element" title="Enter the X link of the creator you want to add."
                id="input-new-creator-social_x" name="input-new-creator-social_x" type="url"
                placeholder="Enter creator's X link.." maxlength="255" pattern="<?= $creatorSvc->getXPattern() ?>">

            <p>You can change this information later</p>

            <input type="submit" id="add-new-creator-button" class="button" value="Add"></button>

        </form>


        <div id="container-creator-info" class="table-container">
            <?php include 'components/searchTable.php' ?>
            <table id="table-creator-info">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Picture</th>
                        <th>Name</th>
                        <th>Alias</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($creatorSvc->getAll() as $creator) { ?>
                        <tr>
                            <td><a class="regular-link"
                                    href="edit-creator.php?id=<?= $creator->getId() ?>"><?= $creator->getId() ?></a></td>
                            <td class="profile-pic-container"><img class="profile-pic"
                                    src="<?= $creator->getProfilePic() ?>"></td>
                            <td><?= $creator->getName() ?></td>
                            <td><?= $creator->getAlias() ?></td>
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
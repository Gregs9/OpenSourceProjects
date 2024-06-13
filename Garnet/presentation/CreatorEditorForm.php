<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/edit-creator.css">
    <title>The Garnet: Control panel</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
    <script src="scripts/changeThumbnails.js" defer></script>
    <script src="scripts/warnings.js" defer></script>

</head>

<body>
    <?php include('components/header.php'); ?>
    <div class="wrapper">

        <h1 class="title">Editing creator with id
            <strong>
                <?= $creator->getId(); ?>
            </strong>
        </h1>

        <form action="edit-creator.php?id=<?= $creator->getId(); ?>&action=editcreator" method="post"
            enctype="multipart/form-data">

            <!--profile picture preview-->
            <img id="thumbnail-preview" alt="preview" src="<?= $creator->getProfilePic() ?>">

            <!--Change profile picture-->
            <label for="thumbnailToUpload">Change profile picture</label>
            <input class="input-element" title="Change this creator's profile picture." type="file" name="thumbnailToUpload"
                id="thumbnailToUpload" accept=".webp, .png, .jpg, .jpeg">

            <h2 id="title-socials">Creator information</h2>

            <!--Creator ID-->
            <label for="creator_ID">Creator ID</label>
            <input class="input-element" readonly title="This creator's ID." type="number" name="creator_ID" id="creator_ID"
                value="<?= $creator->getId() ?>">


            <!--Name-->
            <label for="creator_name">Name</label>
            <input class="input-element" title="This creator's name." type="text" name="creator_name" id="creator_name"
                value="<?= $creator->getName() ?>">


            <!--Alias-->
            <label for="creator_alias">Aliases</label>
            <input class="input-element" placeholder="Enter this creator's alias.." title="Change this creator's aliases." maxlength="255" type="text" name="creator_alias"
                id="creator_alias" value="<?= $creator->getAlias() ?>">

            <!--Description-->
            <label for="creator_description">Description</label>
            <textarea class="input-element" placeholder="Enter this creator's description.." title="Change this creator's description." maxlength="2500" type="text" name="creator_description"
                id="creator_description"><?= $creator->getDescription() ?></textarea>

            <!--DOB-->
            <label for="creator_dob">Date of birth</label>
            <input class="input-element" title="Change this creator's date of birth." maxlength="255" type="date" name="creator_dob"
                id="creator_dob" value="<?= $creator->getDateOfBirth() ?>">

            <!--Nationality-->
            <label for="creator_nat">Nationality</label>
            <?php include ('components/nationalitySelector.php')?>

            <!--SOCIALS-->
            <h2 id="title-socials">Socials</h2>

            <!--Instagram-->
            <label for="social_in">Instagram</label>
            <input class="input-element" placeholder="Enter this creator's Instagram link.." title="Change this creator's Instagram link." maxlength="255" type="url" name="social_in"
                id="social_in" value="<?= $creator->getSocialIn() ?>">

            <!--X-->
            <label for="social_x">X</label>
            <input class="input-element" placeholder="Enter this creator's X link.." title="Change this creator's X link." maxlength="255" type="url" name="social_x" id="social_x"
                value="<?= $creator->getSocialX() ?>">




            <div id="actions">
                <input title="Save changes made to this creator." class="button" type="submit"
                    value="Save changes"></input>

                <a title="Click to delete this creator." id="delete-creator-link" class="regular-link"
                    href="#"
                    data-creatorid="<?= $creator->getId(); ?>">Delete creator</a>

                <a title="Click to go to this creator's page." class="regular-link"
                    href="creator?creator=<?= $creator->getId() ?>">Go to creator</a>

                <a title="Return to control panel." class="regular-link" href="controlpanel-creators">Close</a>
            </div>

        </form>

    </div>
    <?php require_once ('components/Notification.php'); ?>
    <?php include('components/footer.php'); ?>
</body>


</html>
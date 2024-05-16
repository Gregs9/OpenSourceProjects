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
                <?php echo $creator->getId(); ?>
            </strong>
        </h1>

        <?php echo $feedback->getMessage(); ?>

        <form action="edit-creator.php?id=<?php echo $creator->getId(); ?>&action=editcreator" method="post"
            enctype="multipart/form-data">

            <!--profile picture preview-->
            <img id="thumbnail-preview" alt="preview" src="<?php echo $creator->getProfilePic() ?>">

            <!--Change profile picture-->
            <label for="thumbnailToUpload">Change profile picture</label>
            <input title="Change this creator's profile picture." type="file" name="thumbnailToUpload"
                id="thumbnailToUpload" accept=".webp">

            <h2 id="title-socials">Creator information</h2>

            <!--Creator ID-->
            <label for="creator_ID">Creator ID</label>
            <input readonly title="This creator's ID." type="number" name="creator_ID" id="creator_ID"
                value="<?php echo $creator->getId() ?>">



            <!--Name-->
            <label for="creator_name">Name</label>
            <input title="This creator's name." type="text" name="creator_name" id="creator_name"
                value="<?php echo $creator->getName() ?>">


            <!--Alias-->
            <label for="creator_alias">Aliases</label>
            <input placeholder="Enter this creator's alias.." title="Change this creator's aliases." maxlength="255" type="text" name="creator_alias"
                id="creator_alias" value="<?php echo $creator->getAlias() ?>">

            <!--Description-->
            <label for="creator_description">Description</label>
            <textarea placeholder="Enter this creator's description.." title="Change this creator's description." maxlength="2500" type="text" name="creator_description"
                id="creator_description"><?php echo $creator->getDescription() ?></textarea>

            <!--DOB-->
            <label for="creator_dob">Date of birth</label>
            <input title="Change this creator's date of birth." maxlength="255" type="date" name="creator_dob"
                id="creator_dob" value="<?php echo $creator->getDateOfBirth() ?>">

            <!--Nationality-->
            <label for="creator_nat">Nationality</label>
            <input placeholder="Enter this creator's nationality.." title="Change this creator's nationality." maxlength="255" type="text" name="creator_nat"
                id="creator_nat" value="<?php echo $creator->getNationality() ?>">


            <!--SOCIALS-->
            <h2 id="title-socials">Socials</h2>

            <!--Instagram-->
            <label for="social_in">Instagram</label>
            <input placeholder="Enter this creator's Instagram link.." title="Change this creator's Instagram link." maxlength="255" type="url" name="social_in"
                id="social_in" value="<?php echo $creator->getSocialIn() ?>">

            <!--X-->
            <label for="social_x">X</label>
            <input placeholder="Enter this creator's X link.." title="Change this creator's X link." maxlength="255" type="url" name="social_x" id="social_x"
                value="<?php echo $creator->getSocialX() ?>">




            <div id="actions">
                <input title="Save changes made to this creator." class="button" type="submit"
                    value="Save changes"></input>

                <a title="Click to delete this creator." id="delete-creator-link" class="regular-link"
                    href="#"
                    data-creatorid="<?php echo $creator->getId(); ?>">Delete creator</a>

                <a title="Click to go to this creator's page." class="regular-link"
                    href="creator?creator=<?php echo $creator->getId() ?>">Go to creator</a>

                <a title="Return to control panel." class="regular-link" href="controlpanel_creators">Close</a>
            </div>

        </form>

    </div>
    <?php include('components/footer.php'); ?>
</body>


</html>
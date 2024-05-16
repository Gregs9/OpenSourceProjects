<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
    <link rel="stylesheet" href="css/GLOBAL.css">
    <link rel="stylesheet" href="css/pages/edit-tag.css">
    <title>The Garnet: Control panel</title>
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
    <meta name="theme-color" content="#800000">
    <script src="scripts/changeThumbnails.js" defer></script>
    <script src="scripts/warnings.js" defer></script>
</head>

<body>
    <?php include('components/header.php'); ?>
    <div class="wrapper">

        <h1 class="title">Editing tag with id
            <strong>
                <?php echo $tag->getId(); ?>
            </strong>
        </h1>

        <?php echo $feedback->getMessage(); ?>

        <form action="edit-tag.php?id=<?php echo $tag->getId(); ?>&edit_tag=<?php echo $tag->getId(); ?>" method="post"
            enctype="multipart/form-data">

            <h1>Tag thumbnail</h1>

            <!--thumbnail preview-->
            <img id="thumbnail-preview" alt="preview" src="
                <?php
                $thumbnailFilename = strtolower(preg_replace("/[^a-zA-Z0-9]/", "", $tag->getName()));
                if (file_exists($contentPath . '/Categories/' . $thumbnailFilename . '.webp')) {
                    echo $contentPath . '/Categories/' . $thumbnailFilename . '.webp';
                } else {
                    echo 'assets/thumbnail_error.png';
                }
                ?>">

            <!--Change profile picture-->
            <label for="thumbnailToUpload">Change thumbnail</label>
            <input title="Change this category's thumbnail" type="file" name="thumbnailToUpload" id="thumbnailToUpload"
                accept=".webp">


            <!--Category ID-->
            <label for="tag_ID">Category ID</label>
            <input readonly title="This category's ID." type="number" name="tag_ID" id="tag_ID"
                value="<?php echo $tag->getId() ?>">



            <!--Name-->
            <label for="tag_name">Name</label>
            <input title="This category's name." type="text" name="tag_name" id="tag_name"
                value="<?php echo $tag->getName() ?>">


            <!--Description-->
            <label for="tag_description">Description</label>
            <input title="Change this category's description." maxlength="255" type="text" name="tag_description"
                id="tag_description" value="<?php echo $tag->getDescription() ?>">


            <!--Weight-->
            <label for="tag_weight">Weight</label>
            <input title="Change this tag's weight." maxlength="255" type="number" name="tag_weight" min="0" max="10"
                id="tag_weight" value="<?php echo $tag->getWeight() ?>">

            <!--Date added-->
            <label for="tag_dateadded">Date added</label>
            <input title="Change this creator's date of birth." readonly maxlength="255" type="date" name="tag_dateadded"
                id="tag_dateadded" value="<?php echo $tag->getDateAdded()->format('Y-m-d'); ?>">

            <div id="actions">
                <input title="Save changes made to this tag." class="button" type="submit" value="Save changes"></input>

                <a title="Click to delete this tag." id="delete-tag-link" class="regular-link" href="#">Delete category</a>

                <a title="Return to control panel." class="regular-link" href="controlpanel_tags">Close</a>
            </div>

        </form>

    </div>
    <?php include('components/footer.php'); ?>
</body>


</html>
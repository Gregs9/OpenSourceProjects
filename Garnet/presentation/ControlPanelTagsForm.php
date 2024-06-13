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

        <!--TAGS TABLE-->
        <h1 class="title">Tags</h1>

        <form onsubmit="return confirm('Are you sure you want to add this tag?');" id="tag-adder" method="post"
            enctype="multipart/form-data" action="controlpanel-tags.php?action=add_tag">

            <h2>Add a new tag</h2>

            <!--CSRF protection token-->
            <?php require_once ('components/csrf_form_field.php'); ?>

            <!--NEW TAG NAME-->
            <label for="input-new-tag">Name</label>
            <input class="input-element" title="Enter the name of the tag you want to add." id="input-new-tag"
                name="input-new-tag" type="text" pattern="[a-zA-Z0-9- ]+" placeholder="Enter tag name.." minlength="3"
                maxlength="30" required>

            <!--NEW TAG THUMBNAIL-->
            <label for="thumbnailToUpload">Thumbnail</label>
            <input class="input-element" title="Upload a thumbnail for this tag." type="file" name="thumbnailToUpload"
                id="thumbnailToUpload" accept=".webp, .png, .jpg, .jpeg" required>


            <!--NEW TAG WEIGHT-->
            <label for="input-new-tag-weight">Weight</label>
            <input class="input-element" title="Enter the weight (importance) of this tag, value between 0 and 10."
                id="input-new-tag-weight" name="input-new-tag-weight" type="number" placeholder="weight" min="0"
                max="10" required>


            <!--NEW TAG DESCRIPTION-->
            <label for="input-new-tag-description">Description</label>
            <input class="input-element" title="Enter the description of this new tag." id="input-new-tag-description"
                name="input-new-tag-description" type="text" placeholder="Description.." minlength="1" maxlength="255">





            <input type="submit" id="add-new-tag-button" class="button" value="Add"></button>
        </form>




        <div id="container-tag-info" class="table-container">
            <?php include 'components/searchTable.php' ?>
            <table id="table-tag-info">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Tagname</th>
                        <th>Weight</th>
                        <th>Description</th>
                        <th>Date added</th>
                    </tr>
                </thead>
                <tbody>
                    <?php
                    foreach ($tagSvc->getAllTags() as $tag) { ?>
                        <tr>
                            <td><a class="regular-link" href="edit-tag?id=<?= $tag->getId() ?>"><?= $tag->getId() ?></a>
                            </td>
                            <td><?= $tag->getName() ?></td>
                            <td><?= $tag->getWeight() ?></td>
                            <td><?= $tag->getDescription() ?></td>
                            <td><?= $tag->getDateAdded()->format('Y-m-d H:i:s') ?></td>
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
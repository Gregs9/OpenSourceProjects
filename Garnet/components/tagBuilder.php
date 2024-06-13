<head>
    <script src="scripts/TagBuilder.js" defer></script>
    <link rel="stylesheet" href="css/components/TagBuilder.css">
</head>


<!--TAG BUILDER-->
<div id="tag-builder">

    <div id="available-tags-container">
        <h2>Available tags</h2>
        <div id="available-tags">
            <input class="input-element" type="search" id="search-tags" placeholder="Search.." title="Search for a tag">
            <?php foreach ($tagSvc->getAllTags() as $tag) { ?>
                <a title="<?= $tag->getDescription() ?>" class="tag"
                    style="display:none"><?= $tag->getName() ?></a>
            <?php } ?>
        </div>
    </div>

    <div id="selected-tags-container">
        <h2>Selected tags</h2>
        <div id="submitted-tags">
        </div>
    </div>

</div>
<!--END TAG BUILDER-->
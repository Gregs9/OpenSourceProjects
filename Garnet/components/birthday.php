<?php
require_once('data/autoloader.php');
?>

<!DOCTYPE HTML>
<html>

<head>
    <link rel="stylesheet" href="css/components/birthday-box.css">
    <link rel="stylesheet" href="css/components/animated-border.css">
</head>


<div class="birthday-box">
    <h2>Birthday!</h2>

<div id="video-creators">
        <?php foreach ($arr_creators_with_birthday as $creator) { ?>
          <div class="creator-container">
          <a href="creator.php?creator=<?php echo $creator->getId(); ?>">            
              <img class="creator-thumbnail" alt="" src="<?php echo $creator->getProfilePic(); ?>">         
            <p class="creator-name">
              <?php echo $creator->getName(); ?>
            </p>
            </a>
          </div>
        <?php } ?>
      </div>




    <span class="border-top"></span>
    <span class="border-right"></span>
    <span class="border-bottom"></span>
    <span class="border-left"></span>
</div>
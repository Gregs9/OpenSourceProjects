<?php
declare(strict_types=1);
?>

<!DOCTYPE HTML>
<html>

<head>
  <title>The Garnet: Upload</title>
  <link rel="icon" href="assets/logo.ico" type="image/x-icon">
  <meta name="theme-color" content="#800000">
  <link rel="stylesheet" href="css/GLOBAL.css">
  <link rel="stylesheet" href="css/pages/upload.css">
  <script src="scripts/UploadFile_ValidateFile.js" defer></script>
</head>

<body>

  <?php include ('components/header.php'); ?>

  <!--START WRAPPER-->
  <div class="wrapper">

    <h1 id="upload-video">Upload video</h1>


    <form action="upload.php?action=upload" method="post" enctype="multipart/form-data" class="uploadform">

      <?php echo $feedback->getMessage() ?>

      <!--CSRF protection token-->
      <?php require_once('components/csrf_form_field.php'); ?>

      <p style="color: #aa0000">Please do not upload any inappropriate content.</p>

      <label for="fileToUpload">Video</label>
      <input title="Select a video to upload." type="file" name="fileToUpload" id="fileToUpload"
        accept=".mp4, .webm, .mkv" required>

      <span id="videoPreviewContainer" style="display: none">Preview
        <video controls id="videoPreview" alt="preview">
          <source id="sourcePreview" controls type="video/mp4">
        </video>
      </span>



      <label for="thumbnailToUpload">Thumbnail</label>
      <input title="Select a thumbnail to upload." type="file" name="thumbnailToUpload" id="thumbnailToUpload"
        accept=".webp">
      <span id="thumbnailPreviewContainer" style="display: none">Preview<img id="thumbnailPreview" alt="preview"
          style="display: none"></span>



      <label for="title">Title</label>
      <input title="Enter the title for this video." type="text" name="title" id="title" placeholder="e.g. .webm"
        maxlength="255">

      <label for="description">Description</label>
      <textarea title="Enter the description for this video." type="text" name="description" id="description"
        maxlength="1000"></textarea>

      <label for="extension">Extension</label>
      <input title="This video's extension." type="text" name="extension" id="extension" required readonly
        placeholder="e.g. .webm" maxlength="5">

      <label for="duration">Duration (hh:mm:ss)</label>
      <input title="This video's duration." type="text" name="duration" id="duration" required readonly
        placeholder="e.g. 00:00:00" pattern="[0-9][0-9]:[0-9][0-9]:[0-9][0-9]" maxlength="8">

      <label for="filesize">Filesize (kB)</label>
      <input title="This video's filesize." type="number" name="filesize" id="filesize" required readonly
        placeholder="e.g. 146969" maxlength="8">

      <!--hide this element since it servers no real purpose other than using it as a post value
      <label for="tags">Tags</label>-->
      <input title="This video's tagline." type="text" name="tags" id="tags" required onkeypress="return false;"
        minlength="3" maxlength="500" hidden>


      <?php include ('components/tagBuilder.php') ?>

      <!--hide this element since it servers no real purpose other than using it as a post value-->
      <input title="This video's creators." type="text" name="creators-line" id="creators-line"
        onkeypress="return false;" minlength="3" maxlength="500" hidden required>


      <?php include ('components/creatorBuilder.php') ?>


      <div id="upload-button-container">
        <input title="Upload this video." class="button" type="submit" value="Upload Video" name="submit">
      </div>
    </form>

  </div>
  <!--END WRAPPER-->

  <?php include ('components/footer.php'); ?>



</body>

</html>
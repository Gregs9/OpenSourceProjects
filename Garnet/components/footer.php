<!DOCTYPE HTML>
<html>

<head>
  <link rel="stylesheet" href="css/components/footer.css">
</head>

<footer>
  <section id="sitemap">
    <h2>Sitemap</h2>
    <a class="regular-link" href="home">Home</a>
    <a class="regular-link" href="shorts">Shorts</a>
    <a class="regular-link" href="categories">Categories</a>
    <a class="regular-link" href="creators">Creators</a>
    <a class="regular-link" href="upload">Upload</a>
    <a class="regular-link" href="login?action=logout">Log out</a>

  </section>

  <section id="useful-links">
    <h2>Useful links</h2>
    <a class="regular-link" href="#">Legal Stuff</a>
    <a class="regular-link" href="#">Privacy Policy</a>
    <a class="regular-link" href="presentation/cookieInformation">Cookie Policy</a>
    <a class="regular-link" href="#">Security</a>
  </section>

  <section id="contact">
    <h2>Contact</h2>
    <p>Mr. Cacodemon</p>
    <p>Good-Intentions Road</p>
    <p>E2M3 The Shores of Hell</p>
    <p>Hell</p>
  </section>

  <section>
    <?= unserialize($_COOKIE['user'], ['User'])->getRole() == 'admin' ? '<img src="assets/cacodemon.gif" style="width: 50px;">' : null ?>
    <p>© Copyright 2023-2024 Cacodemon All Rights Reserved.</p>

  </section>




</footer>
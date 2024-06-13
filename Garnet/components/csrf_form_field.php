<!--CSRF protection token-->
<?php $csrf_token = $_SESSION['csrf_token']; ?>
<input type="hidden" name="csrf_token" value="<?= htmlspecialchars($csrf_token); ?>">
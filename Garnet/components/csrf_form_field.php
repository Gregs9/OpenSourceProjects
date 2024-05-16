<!--CSRF protection token-->
<?php $csrf_token = $_SESSION['csrf_token']; ?>
<input type="hidden" name="csrf_token" value="<?php echo htmlspecialchars($csrf_token); ?>">
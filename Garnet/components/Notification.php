<head>
    <link href="scripts/flashjs/dist/flash.min.css" rel="stylesheet" />
    <script src="scripts/flashjs/dist/flash.min.js"></script>
</head>



<?php if (isset($_SESSION['feedback'])) {

    $message = json_decode($_SESSION['feedback'])->message ?? '';
    $type = json_decode($_SESSION['feedback'])->type ?? '';
    $redirect = json_decode($_SESSION['feedback'])->redirect ?? '';

    if (strtolower($type) == 'error'): ?>
        <script>
            window.FlashMessage.error('<?= $message ?>', {
                progress: true,
                interactive: true,
                timeout: 5000,
                appear_delay: 200,
                container: '.flash-container',
                theme: 'default',
                classes: {
                    container: 'flash-container',
                    flash: 'flash-message',
                    visible: 'is-visible',
                    progress: 'flash-progress',
                    progress_hidden: 'is-hidden'
                }
            });
        </script>
    <?php endif ?>

    <?php if (strtolower($type) == 'info'): ?>
        <script>
            window.FlashMessage.info('<?= $message ?>', {
                progress: true,
                interactive: true,
                timeout: 5000,
                appear_delay: 200,
                container: '.flash-container',
                theme: 'default',
                classes: {
                    container: 'flash-container',
                    flash: 'flash-message',
                    visible: 'is-visible',
                    progress: 'flash-progress',
                    progress_hidden: 'is-hidden'
                }
            });
        </script>
    <?php endif ?>

    <?php if (strtolower($type) == 'success'): ?>
        <script>
            window.FlashMessage.success('<?= $message ?>', {
                progress: true,
                interactive: true,
                timeout: 5000,
                appear_delay: 200,
                container: '.flash-container',
                theme: 'default',
                classes: {
                    container: 'flash-container',
                    flash: 'flash-message',
                    visible: 'is-visible',
                    progress: 'flash-progress',
                    progress_hidden: 'is-hidden'
                }
            });
        </script>
    <?php endif ?>

    <?php
    unset($_SESSION['feedback']);
    unset($_SESSION['feedback_color']);
}
?>
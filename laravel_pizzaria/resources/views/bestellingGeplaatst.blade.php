<?php
declare(strict_types=1);

?>

<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Scorchini's</title>
    <link href="{{ asset('css/global.css') }}" rel="stylesheet">  
    <link href="{{ asset('css/bestellingGeplaatst.css') }}" rel="stylesheet">  
    <link rel="icon" href="assets/logo.ico" type="image/x-icon">
</head>

@include('header')

<body>

    <div class="wrapper">
        <h1>Bestelling geplaatst!</h1>
        <p>Bedankt voor uw bestelling!</p>
        <p>Onze bezorger komt er zo snel mogelijk aan!</p>
        <div id="back">
            <a class="button" href="{{ route('home') }}">Terug naar overzicht</a>
        </div>
    </div>


</body>
@include('footer')
</html>
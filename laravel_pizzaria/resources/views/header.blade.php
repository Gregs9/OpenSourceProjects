<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Scorchini's Pizzaria</title>
    <link href="{{ asset('css/global.css') }}" rel="stylesheet">
    <link href="{{ asset('css/header.css') }}" rel="stylesheet">
    <script src="{{ asset('js/menu.js') }}" defer></script>
</head>
<body>
    <!--START HEADER-->
<header class="header">
    <nav class="menu">
    <a href="{{ route('home') }}" id="logo-link"><img src="{{ asset('assets/logo.webp') }}" id="logo" alt="logo"></a>
      <ul id="ul-menu">
        <li><a id="home" href="{{ route('home') }}">OVERZICHT</a></li>
        <li><a id="promoties" href="{{ route('promoties') }}">PROMOTIES</a></li>
        <li><a id="overons" href="{{ route('overons') }}">OVER ONS</a></li>
        <?php if (auth()->user()) { ?>
          <li><a id="logout" href="{{ route('logout') }}">LOG UIT</a></li>
        <?php } ?>
      </ul>
    </nav>
  </header>
  <!--EINDE HEADER-->
</body>
</html>
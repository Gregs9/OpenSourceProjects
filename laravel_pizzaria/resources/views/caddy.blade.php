<head>
    <link href="{{ asset('css/caddy.css') }}" rel="stylesheet">
    <script src="{{ asset('js/toevoegenAanWinkelmand.js') }}" defer></script>
</head>

<aside id="caddy">
    <h2>Winkelmandje</h2>
    <table id="selectie">
        <tr>
            <th>Naam</th>
            <th>Aantal</th>
            <th>Prijs</th>
            <th>Totaal</th>
        <tr>
            <!--Hier komen alle geselecteerde pizzas te staan-->
    </table>
    <a id="afrekenen" class="link-button" href="{{route('inloggen')}}">Afrekenen</a>
</aside>

<div id="caddy-icon-container">
    <p id="aantal"></p>
    <img id="caddy-icon" src="assets/basket.png" alt="caddy-icon">
</div>


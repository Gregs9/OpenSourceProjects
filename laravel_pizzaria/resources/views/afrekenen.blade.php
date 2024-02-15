<?php
use App\Models\Pizza;
use App\Models\Location;
?>

<!DOCTYPE HTML>
<html>
    <head>
        <link href="{{ asset('css/afrekenen.css') }}" rel="stylesheet">  
        <script src="{{ asset('js/updateCaddy.js') }}" defer></script>
        <script src="{{ asset('js/wijzigAdres.js') }}" defer></script>
    </head>
    @include('header')
<body>

    <div class="wrapper">
        @if(session()->has('error'))
        <p style="color: red;" id="feedback">{{session('error')}}</p>
        @endif
        @if(session()->has('message'))
        <p style="color: green;" id="feedback">{{session('message')}}</p>
        @endif
        <h1 class="titel">Overzicht</h1>
        <p id="feedback"></p>
        <main id="overzicht">
            @foreach ($orders as $orderLine)
            <div data-order_object={{str_replace(' ', '_', json_encode($orderLine)) }}" class="pizza-info">

                    <img class="thumbnail" src="{{ asset('assets/' . $orderLine->naam . '.png') }}">
                    <p>Pizza {{$orderLine->naam}}</p>
                    <br>
                    <br>
                    <p>Aantal: <input id="inputAantal" class="aantal" type="number" min="0" max="99" required value="{{$orderLine->aantal}}">Stuk(s)</p>
                    <br>
                    <p>Prijs per stuk: €{{number_format($orderLine->prijs,2)}}</p>
                    <br>
                    <br>
                    
                    <p>Ingrediënten: {{ Pizza::findOrFail($orderLine->id)->ingredienten }}</p>
                    <br>
                    <p>Allergenen: {{ Pizza::findOrFail($orderLine->id)->allergenen }}</p>
                    
            </div>
            @endforeach

            <div id="outer">
                <button class="button" id="update-caddy">Update winkelmand</button>
            </div>


            <h2 class="titel">Totaal: €{{number_format($totaal, 2)}}</h2>
            <h2 class="titel">Korting: {{$kortingsTarief}}%</h2>
            <h2 class="titel">Te betalen: €{{number_format($teBetalen, 2)}}</h2>

            <div id="lever-info">
                <p><u>Leveren naar:</u> </p>
                <p id="full-name">{{auth()->user()->last_name}} {{auth()->user()->first_name}}</p>
                <p id="address">
                    {{auth()->user()->adres}}
                </p>
                <p id="city">
                    {{Location::findOrFail(auth()->user()->plaatsId)->postcode}} {{Location::findOrFail(auth()->user()->plaatsId)->plaats}}
                </p>

                <br>

                <a id="wijzig-adres" class="button" href="#">wijzig</a>

                <br>
                <br>
                <br>

                <p>Opmerking</p>

                <br>

                <form method="post" action="{{ route('bestellingPlaatsen') }}">
                    @csrf
                    <textarea id="comment" name="comment" max-length="255"></textarea>
                    <input type="number" step=".01" name="teBetalen" id="teBetalen" value="{{$teBetalen}}" readonly hidden>

                    <br>
                    <br>
                
                    <input type="submit" id="bestel-link" class="button" value="Plaats bestelling">
                </form>
            </div>

            <form id="wijzig-info" style="display:none" method="post" action="{{ route('adresWijzigen') }}">
                @csrf
                <label for="wijzig_adres">Straat en Huisnr <input name="wijzig_adres" minlength="5" maxlength="45"
                        required type="text" value="{{auth()->user()->adres}}"></label>
                <br>
                <label for="wijzig_postcode">Postcode <input name="wijzig_postcode" type="text" minlength="4" required
                        maxlength="4"
                        value="{{Location::findOrFail(auth()->user()->plaatsId)->postcode}}"></label>
                <br>
                <label for="wijzig_gemeente">Gemeente <input name="wijzig_gemeente" type="text" minlength="2"
                        maxlength="45" required
                        value="{{Location::findOrFail(auth()->user()->plaatsId)->plaats}}"></label>
                <br>
                <input id="bevestig" class="button" type="submit" value="Bevestig">
                <a id="annuleren" class="button" href="#">Annuleren</a>
            </form>
        
        </main>

    </div>



</body>
@include('footer')
</html>
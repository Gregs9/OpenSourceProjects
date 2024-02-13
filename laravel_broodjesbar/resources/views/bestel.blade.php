<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Broodjesbar Login</title>
    <link href="../../default.css" rel="stylesheet" type="text/css">
</head>


<body>
    <!--START WRAPPER-->
    <div class="wrapper">
        <h2>Welkom,
            {{ auth()->user()->name }}
            <a href="{{ route('logout') }}">Uitloggen</a>
        </h2>
        


        <h1 class="titel">Bestelformulier</h1>
            @if(session()->has('message'))
                <p style="color: green;" id="feedback">{{session('message')}}</p>
            @endif
        <table id="broodjesInfo">
            <thead>
                <tr>
                    <th>Naam</th>
                    <th>Omschrijving</th>
                    <th>Prijs</th>
                    <th>Bestellen</th>
                </tr>
            </thead>
            <tbody>
                @foreach ($broodjes as $broodje)
                    <tr>
                        <td>{{ $broodje->name }}</td>
                        <td>{{ $broodje->omschrijving }}</td>
                        <td>€ {{ number_format($broodje->prijs, 2) }}</td>
                        <td><a href="{{route('bestel', ['broodje' => $broodje])}}">Bestel ></a></td>
                    </tr>
                @endforeach
            </tbody>
        </table>

    </div>
    <!--END WRAPPER-->

</body>

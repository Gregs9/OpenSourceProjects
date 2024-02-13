<?php

use App\Models\Broodje;
use App\Models\User;
?>

<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Broodjesbar overzicht</title>
    <link href="../../default.css" rel="stylesheet" type="text/css">
</head>

<body>
    <!--START WRAPPER-->
    <div class="wrapper">
        <div class="wrapper">
            <h2>Welkom,
                {{ auth()->user()->name }}
                <a href="{{ route('logout') }}">Uitloggen</a>
            </h2>
        <h1>Overzichtformulier</h1>
        @if(session()->has('message'))
        <p style="color: green;" id="feedback">{{session('message')}}</p>
        @endif
        @if(session()->has('error'))
        <p style="color: red;" id="feedback">{{session('error')}}</p>
        @endif

        <div class="scroller">
            <table id="besteldeBroodjes">
                <thead>
                    <tr>
                        <th>Broodje</th>
                        <th>klant ID</th>
                        <th>Klant Naam</th>
                        <th>Tijdstip bestelling</th>
                        <th>Prijs</th>
                        <th>Afwerken</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach ($bestellingen as $bestelling)
                    <tr>
                        <td>{{ Broodje::findOrFail($bestelling->broodje_ID)->name }}</td>
                        <td>{{$bestelling->klant_ID}}</td>
                        <td>{{User::findOrFail($bestelling->klant_ID)->name}}</td>
                        <td>{{$bestelling->created_at}}</td>
                        <td>€ {{ number_format(Broodje::findOrFail($bestelling->broodje_ID)->prijs, 2) }}</td>
                        <td>{{$bestelling->status}} 
                        @if ($bestelling->status == 'besteld')
                        <a href="{{route('afwerken', ['bestelling' => $bestelling])}}">(afwerken)</a>
                        @endif
                        @if ($bestelling->status == 'afgewerkt')
                        <a href="{{route('afhalen', ['bestelling' => $bestelling])}}">(afgehaald)</a>
                        @endif
                        </td>
                    </tr>
                @endforeach
                </tbody>
            </table>
        </div>

        <h1>Gebruikers</h1>
        <div class="scroller">
            <table id="gebruikers">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Naam</th>
                        <th>Email</th>
                        <th>Type</th>
                        <th>Status</th>
                    </tr>
                </thead>


                @foreach ($users as $user)
                    <tr>
                        <td>{{$user->id}}</td>
                        <td>{{$user->name}}</td>
                        <td>{{$user->email}}</td>
                        <td>{{$user->type}} 
                            @if ($user->type == 'medewerker')
                            <a href="{{route('demote', ['user' => $user])}}">(degradeer)</a>
                            @else 
                            <a href="{{route('promote', ['user' => $user])}}">(promoveer)</a>
                            @endif
                        </td>
                        <td>{{$user->status}} 
                            @if ($user->status == 'actief')
                            <a href="{{route('block', ['user' => $user])}}">(blokkeer)</a>
                            @else 
                            <a href="{{route('unblock', ['user' => $user])}}">(activeer)</a>
                            @endif
                        </td>
                    </tr>
                @endforeach

            </table>
            
        </div>
    </div>
    <!--EINDE WRAPPER-->

</body>

</html>
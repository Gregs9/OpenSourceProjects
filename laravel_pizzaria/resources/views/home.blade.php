<!DOCTYPE html>
<head>
    <link href="{{ asset('css/home.css') }}" rel="stylesheet">
</head>
@include('header')
@include('caddy')
<body>
    <div class="wrapper">
        @if(session()->has('error'))
        <p style="color: red;" id="feedback">{{session('error')}}</p>
        @endif
        <h1>Pizzas!</h1>
        <main id="overzicht">
            @foreach ($pizzas as $pizza)
                <div data-id="{{$pizza->id}}" data-naam="{{$pizza->naam}}" data-prijs="{{$pizza->prijs}}" class="pizza-info">
                <h2>{{$pizza->naam}}</h2>
                <img class="thumbnail" src="{{ asset('assets/' . $pizza->naam . '.png') }}">
                <p>€ {{number_format($pizza->prijs, 2)}}</p>
                <p>Ingrediënten: {{$pizza->ingredienten}}</p>
                <p>Allergenen: {{$pizza->allergenen}}</p>
                </div>
            @endforeach    
        </main>
    </div>
</body>
@include('footer')

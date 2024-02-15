<!DOCTYPE html>
<head>
    <link href="{{ asset('css/promoties.css') }}" rel="stylesheet">
</head>
@include('header')
@include('caddy')
<body>    
    <div class="wrapper" >
        <h1 class="title">Promoties!</h1>

        <div class="promo" id="promo1">
            <h1>Tijdelijk 2+1 gratis actie!</h1>
        </div>

        <div class="promo" id="promo2">
            <h1>Gratis levering vanaf €30!</h1>
        </div>
    </div>  
</body>
@include('footer')

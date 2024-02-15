

<!DOCTYPE HTML>
<html>

<head>
    <meta charset=utf-8>
    <title>Scorchini's Login</title>
    <link href="{{ asset('css/global.css') }}" rel="stylesheet">
    <link href="{{ asset('css/inlogform.css') }}" rel="stylesheet">
    <script src="{{ asset('js/inlogformulier.js') }}" defer></script>
</head>

@include('header')
<body>
    <!--START WRAPPER-->
    <div class="wrapper">

        @if(session()->has('error'))
        <p style="color: red;" id="feedback">{{session('error')}}</p>
        @endif
        @if($errors->any())
        <ul>
            @foreach($errors->all() as $error)
            <p style="color: red;" id="feedback">{{ $error }}</p>
            @endforeach
        </ul>
        @endif

        <div id="forms">
            <form method="post" id="login" action="{{ route('login') }}">
            @csrf
            <h1>Ik heb een account</h1>

            <label for="log_email">Email adres</label>
            <input type="email" id="log_email" name="log_email" placeholder="Je email.." required maxlength="50">

            <br>

            <label for="log_password">Wachtwoord</label>
            <input type="password" id="log_password" name="log_password" placeholder="Je wachtwoord.." required
                maxlength="50" minlength="8">

            <br>

            <input type="submit" value="Verder naar afrekenen" class="button">

            </form>
 
            <form method="post" id="register" action="{{ route('register') }}">
                @csrf
                <h1>Ik heb geen account</h1>

                <label for="reg_familienaam">Familienaam</label>
                <input type="text" id="reg_familienaam" name="reg_familienaam" placeholder="Je familienaam.." required
                    maxlength="45">

                <br>

                <label for="reg_voornaam">Voornaam</label>
                <input type="text" id="reg_voornaam" name="reg_voornaam" placeholder="Je voornaam.." required
                    maxlength="45">

                <br>

                <label for="reg_adres">Straat + huisnr.</label>
                <input type="text" id="reg_adres" name="reg_adres" placeholder="Je straat + nummer.." required
                    maxlength="45">

                <br>

                <label for="reg_postcode">Postcode</label>
                <input type="text" id="reg_postcode" name="reg_postcode" placeholder="Je postcode.." required
                    maxlength="4">

                <br>

                <label for="reg_gemeente">Gemeente</label>
                <input type="text" id="reg_gemeente" name="reg_gemeente" placeholder="Je gemeente.." required
                    maxlength="45">

                <br>

                <label for="reg_tel">Telefoon</label>
                <input type="text" id="reg_tel" name="reg_tel" placeholder="Je telefoonnummer.." required
                    maxlength="45">

                <br>

                <label id="checkbox"><input type="checkbox" id="registreer" name="registreer"> Maak een account
                    aan</label>

                <br>

                <div id="include-register">

                    <label for="email">Email adres</label>
                    <input type="email" id="email" name="email" placeholder="Je email.." maxlength="50">

                    <br>

                    <label for="reg_password">Wachtwoord</label>
                    <input type="password" id="reg_password" name="reg_password" placeholder="Je wachtwoord.."
                        maxlength="50">

                    <br>

                    <label for="reg_password_confirmation">Herhaal wachtwoord</label>
                    <input type="password" id="reg_password_confirmation" name="reg_password_confirmation" placeholder="Je wachtwoord.."
                        maxlength="50">

                    <br>

                </div>

                <input type="submit" value="Verder naar afrekenen" class="button">

            </form>
        </div>

    </div>
    <!--END WRAPPER-->

    @include('footer')
</body>

</html>
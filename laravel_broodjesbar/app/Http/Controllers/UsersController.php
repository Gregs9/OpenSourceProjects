<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Models\Bestelling;
use Illuminate\Http\Request;
use App\Models\User;

class UsersController extends Controller
{
    public function all()
    {
        if (auth()->user()->type == 'medewerker') {
            $users = User::all();
            $bestellingen = Bestelling::all();
            return view('overzicht', ['users' => $users, 'bestellingen' => $bestellingen]);
        } else {
            return redirect(route('besteloverzicht'))->with('error', 'U heeft geen toegang tot deze pagina');
        }

    }

    public function promote($user)
    {
        $user = User::findOrFail($user);
        $user->update(['type' => 'medewerker']);
        return redirect(route('overzicht'))->with('message', 'Gebruiker gepromoveerd!');
    }

    public function demote($user)
    {
        $user = User::findOrFail($user);
        $user->update(['type' => 'klant']);
        return redirect(route('overzicht'))->with('message', 'Gebruiker gedegradeerd!');
    }

    public function block($user)
    {
        $user = User::findOrFail($user);
        $user->update(['status' => 'geblokkeerd']);
        return redirect(route('overzicht'))->with('message', 'Gebruiker geblokkeerd!');
    }

    public function unblock($user)
    {
        $user = User::findOrFail($user);
        $user->update(['status' => 'actief']);
        return redirect(route('overzicht'))->with('message', 'Gebruiker gedeblokkeerd!');
    }
}

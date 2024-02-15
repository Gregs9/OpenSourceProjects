<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Models\Location;
use App\Models\User;
use Illuminate\Http\Request;
use Auth;
use Illuminate\Support\Facades\Session;


class UsersController extends Controller
{
    function wijzigAdres(Request $request)
    {


        $request->validate([
            'wijzig_adres' => 'required|max:100',
            'wijzig_postcode' => 'required|max:4',
            'wijzig_gemeente' => 'required|max:50'
        ]);

        $toegelatenPostcodes = ['3600', '3530', '3520', '3500', '3590', '3740', '3550'];
        if (!in_array($request->wijzig_postcode, $toegelatenPostcodes)) {
            return redirect(route('afrekenen'))->with('error', 'We leveren niet aan deze gemeente. We leveren enkel in 3600 Genk, 3530 Houthalen-Helchteren, 3520 Zonhoven, 3500 Hasselt, 3590 Diepenbeek, 3740 Bilzen en 3550 Heusden-Zolder');
        }


        //get plaatsId with given postcode - This should be replaceable using the find() function, no?
        $plaatsId = Location::where('postcode', $request->wijzig_postcode)->first();


        if ($plaatsId) {

            if (auth()->user()) {
                $user = Auth::user();

                $user->update(['plaatsId' => $plaatsId->id]);
                $user->update(['adres' => $request->wijzig_adres]);

                return redirect(route('afrekenen'))->with('message', 'Adres succesvol gewijzigd!');
            } else {
                Session::put('adres', $request->wijzig_adres);
                Session::put('plaatsId', $plaatsId->id);
                return redirect(route('afrekenen'))->with([
                    'message' => 'Adres succesvol gewijzigd!'
                ]);
            }
        } else {
            return redirect(route('afrekenen'))->with('error', 'Ongeldige postcode');
        }

    }


}

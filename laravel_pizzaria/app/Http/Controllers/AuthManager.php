<?php

namespace App\Http\Controllers;

use Auth;
use App\Models\User;
use App\Models\Location;
use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Session;

class AuthManager extends Controller
{

    function loginPost(Request $request)
    {
        $request->validate([
            'log_email' => 'required',
            'log_password' => 'required'
        ]);

        $credentials = ['email' => $request->log_email, 'password' => $request->log_password];

        if (Auth::attempt($credentials)) {
            return redirect(route('afrekenen'));
        }

        return redirect(route('inloggen'))->with('message', 'Ongeldige inloggegevens');
    }

    function registerPost(Request $request)
    {
        $request->validate([
            'reg_familienaam' => 'required|string|max:50',
            'reg_voornaam' => 'required|string|max:50',
            'reg_adres' => 'required|max:100',
            'reg_postcode' => 'required',
            'reg_gemeente' => 'required|string|max:50'
        ]);

        $toegelatenPostcodes = ['3600', '3530', '3520', '3500', '3590', '3740', '3550'];
        if (!in_array($request->reg_postcode, $toegelatenPostcodes)) {
            return redirect(route('inloggen'))->with('error', 'We leveren niet aan deze gemeente. We leveren enkel in 3600 Genk, 3530 Houthalen-Helchteren, 3520 Zonhoven, 3500 Hasselt, 3590 Diepenbeek, 3740 Bilzen en 3550 Heusden-Zolder');
        }

        $data['first_name'] = $request->reg_voornaam;
        $data['last_name'] = $request->reg_familienaam;
        $data['adres'] = $request->reg_adres;
        $data['tel'] = $request->reg_tel;
        $data['plaatsId'] = Location::where('postcode', $request->reg_postcode)->first()->id;
        $data['kortingsTarief'] = 0;


        //  If user wants to register, validate email & password and
        if ($request->has('registreer')) {
            $request->validate([
                'email' => 'required|email|unique:users',
                'reg_password' => 'required|confirmed|string|min:8|max:50'
            ]);

            $data['email'] = $request->email;
            $data['password'] = Hash::make($request->reg_password);

            $user = User::create($data);
            // Automatically log in the newly registered user
            Auth::login($user);

            return redirect(route('afrekenen'));
        } else {
            Session::put('last_name', $data['last_name']);
            Session::put('first_name', $data['first_name']);
            Session::put('adres', $data['adres']);
            Session::put('plaatsId', $data['plaatsId']);

            return redirect(route('afrekenen'));
        }




    }

    function logout()
    {
        Session::flush();
        Auth::logout();
        return redirect(route('home'))->with('message', 'U bent uitgelogd.');
    }



}

<?php

namespace App\Http\Controllers;

use Auth;
use App\Models\User;
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
            if (auth()->user()->status !== 'geblokkeerd') {
                if (auth()->user()->type == 'klant') {
                    return redirect()->intended('bestel');
                } else {
                    return redirect()->intended('overzicht');
                }
            } else {
                return redirect(route('home'))->with('message', 'Dit account is geblokkeerd.');
            }
        }


        return redirect(route('home'))->with('message', 'Ongeldige inloggegevens');
    }

    function registerPost(Request $request)
    {
        $request->validate([
            'reg_username' => 'required',
            'email' => 'required|email|unique:users',
            'reg_password' => 'required',
            'reg_password2' => 'required'
        ]);

        if ($request->reg_password == $request->reg_password2) {
            $data['name'] = $request->reg_username;
            $data['email'] = $request->email;
            $data['type'] = 'klant';
            $data['status'] = 'actief';
            $data['password'] = Hash::make($request->reg_password);
            $user = User::create($data);
            return redirect(route('home'))->with('success', 'Account aangemaakt, u kan nu inloggen.');
        } else {
            return redirect(route('home'))->with('message', 'De gegeven wachtwoorden komen niet overeen');
        }
    }

    function logout()
    {
        Session::flush();
        Auth::logout();
        return redirect(route('home'))->with('message', 'U bent uitgelogd.');
    }



}

<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Pizza;

class PizzaController extends Controller
{
    function all()
    {
        $pizzas = Pizza::all();
        return view('home', ['pizzas' => $pizzas]);
    }

    function getOrder()
    {
        //get orders from cookie
        $orders = json_decode($_COOKIE['order']);

        //calculate total price of order
        $totaal = 0;
        $kortingsTarief = 0;

        //if user is logged in, get their kortingsTarief
        if (auth()->user()) {
            $kortingsTarief = auth()->user()->kortingsTarief;
        }
        
        if (count($orders) < 1) {
            return redirect(route('home'))->with('error','Er zit niets in uw winkelmandje.');

        }

        foreach ($orders as $order) {
            $totaal += (intval($order->aantal) * floatval($order->prijs));
        }
        $teBetalen = $totaal * ((100 - $kortingsTarief) / 100);

        if (auth()->user()) {
            return view('afrekenen', ['orders' => $orders, 'totaal' => $totaal, 'kortingsTarief' => $kortingsTarief, 'teBetalen' => $teBetalen]);
        } else {
            return view('afrekenenGast', ['orders' => $orders, 'totaal' => $totaal, 'kortingsTarief' => $kortingsTarief, 'teBetalen' => $teBetalen]);
        }
        
    }


}

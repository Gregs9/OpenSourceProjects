<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Location;
use App\Models\Order;
use App\Models\OrderLine;
use Illuminate\Support\Facades\Session;
use Illuminate\Support\Facades\Cookie;

class OrderController extends Controller
{
    function create(Request $request)
    {
        //calculate total price of order
        if (auth()->user()) {
            $data['klant_id'] = auth()->user()->id;
            $data['afleveradres'] = auth()->user()->adres . ' ' . Location::find(auth()->user()->plaatsId)->postcode . ' ' . Location::find(auth()->user()->plaatsId)->plaats;
            $data['opmerking'] = $request->comment;
            $data['verkoopprijs'] = $request->teBetalen;
        } else {
            $data['klant_id'] = 0;
            $data['afleveradres'] = Session::get('adres') . ' ' . Location::find(Session::get('plaatsId'))->postcode . ' ' . Location::find(Session::get('plaatsId'))->plaats;
            $data['opmerking'] = $request->comment;
            $data['verkoopprijs'] = $request->teBetalen;
        }

        //  create order
        $order = Order::create($data);

        //get order details from cookie
        $orderDetails = json_decode($_COOKIE['order']);

        //for each item in the order, write a order_line
        foreach ($orderDetails as $orderline) {
            $orderData['bestelbon_id'] = $order->id;
            $orderData['pizza_id'] = $orderline->id;
            $orderData['aantal'] = $orderline->aantal;
            OrderLine::create($orderData);
        }

        //  delete temporary session variables used for storing guest data
        if (auth()->user()) {
            Session::remove('first_name');
            Session::remove('last_name');
            Session::remove('adres');
            Session::remove('plaatsId');
        }

        //  delete order cookie after placing the order
        unset($_COOKIE['order']);
        setcookie('order', '', -1, '/');

        return redirect(route('bestellingGeplaatst'));

    }


}

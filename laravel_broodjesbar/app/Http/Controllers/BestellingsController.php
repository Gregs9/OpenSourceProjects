<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Broodje;
use App\Models\Bestelling;

class BestellingsController extends Controller
{
    public function create($broodje)
    {
        $data['klant_ID'] = auth()->user()->id;
        $data['broodje_ID'] = $broodje;
        $data['status'] = 'besteld';

        $bestelling = Bestelling::create($data);

        return redirect(route('besteloverzicht'))->with('message', 'Broodje succesvol besteld!');
    }

    public function afwerken($bestelling)
    {
        $bestelling = Bestelling::findOrFail($bestelling);

        $bestelling->update(['status' => 'afgewerkt']);

        return redirect(route('overzicht'))->with('message', 'Broodje succesvol afgewerkt!');
    }

    public function afhalen($bestelling)
    {
        $bestelling = Bestelling::findOrFail($bestelling);

        $bestelling->update(['status' => 'afgehaald']);

        return redirect(route('overzicht'))->with('message', 'Broodje succesvol afgehaald!');
    }
}

<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Broodje;

class BroodjesController extends Controller
{
    public function all() {
        $broodjes = Broodje::all();
        return view('bestel', ['broodjes' => $broodjes]); 
    }

}

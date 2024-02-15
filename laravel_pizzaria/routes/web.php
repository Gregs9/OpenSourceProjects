<?php

use App\Http\Controllers\PizzaController;
use App\Http\Controllers\UsersController;
use App\Http\Controllers\OrderController;
use App\Http\Controllers\AuthManager;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "web" middleware group. Make something great!
|
*/

//  overzicht page with an array of all pizzas to display
Route::get('/', [PizzaController::class, 'all'])->name('home');

//  simple view that doesn't require any variables
Route::get('/promoties', function () {
    return view('promoties'); })->name('promoties');

//  simple view that doesn't require any variables
Route::get('/overons', function () {
    return view('overons'); })->name('overons');

//  when the user is redirected to the login page, if they are already logged in, redirect to afreken page
Route::get('/inloggen', function () {
    if (auth()->user()) {
        return redirect(route('afrekenen'));
    } else {
        return view('inloggen');
    }
})->name('inloggen');

//routes for posting the login/registration data to the controller
Route::post('/login', [AuthManager::class, 'loginPost'])->name('login');
Route::post('/register', [AuthManager::class, 'registerPost'])->name('register');
Route::get('/afrekenen', [PizzaController::class, 'getOrder'])->name('afrekenen');
Route::post('/afrekenen', [UsersController::class, 'wijzigAdres'])->name('adresWijzigen');
Route::post('/bestellingGeplaatst', [OrderController::class, 'create'])->name('bestellingPlaatsen');
Route::get('/bestellingGeplaatst', function () {
    return view('bestellingGeplaatst'); })->name('bestellingGeplaatst');


Route::middleware(['auth'])->group(function () {
    Route::get('/logout', [AuthManager::class, 'logout'])->name('logout');
});
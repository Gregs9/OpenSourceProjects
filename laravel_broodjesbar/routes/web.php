<?php

use App\Http\Controllers\UsersController;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\AuthManager;
use App\Http\Controllers\BroodjesController;
use App\Http\Controllers\BestellingsController;

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

Route::get('/', function () {
    if (auth()->user()) {
        if (auth()->user()->type == 'medewerker') {
            return redirect(route('overzicht'));
        } else {
            return redirect(route('besteloverzicht'));
        }
    } else {
        return view('welcome');
    }

})->name('home');

Route::post('/login', [AuthManager::class, 'loginPost'])->name('login');
Route::post('/register', [AuthManager::class, 'registerPost'])->name('register');

Route::middleware(['auth'])->group(function () {
    Route::get('/overzicht', [UsersController::class, 'all'])->name('overzicht');
    Route::get('/bestel', [BroodjesController::class, 'all'])->name('besteloverzicht');
    Route::get('/bestel/{broodje}', [BestellingsController::class, 'create'])->name('bestel');
    Route::get('/logout', [AuthManager::class, 'logout'])->name('logout');
    Route::get('/overzicht/afwerken/{bestelling}', [BestellingsController::class, 'afwerken'])->name('afwerken');
    Route::get('/overzicht/afhalen/{bestelling}', [BestellingsController::class, 'afhalen'])->name('afhalen');
    Route::get('/overzicht/promote/{user}', [UsersController::class, 'promote'])->name('promote');
    Route::get('/overzicht/demote/{user}', [UsersController::class, 'demote'])->name('demote');
    Route::get('/overzicht/block/{user}', [UsersController::class, 'block'])->name('block');
    Route::get('/overzicht/unblock/{user}', [UsersController::class, 'unblock'])->name('unblock');
});



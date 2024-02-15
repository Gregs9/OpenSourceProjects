<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Order extends Model
{
    use HasFactory;
    protected $fillable = [
        'created_at',
        'updated_at',
        'klant_id',
        'afleveradres',
        'opmerking',
        'verkoopprijs'
    ];
}

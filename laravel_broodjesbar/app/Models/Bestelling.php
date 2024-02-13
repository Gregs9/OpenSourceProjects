<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Bestelling extends Model
{
    use HasFactory;
    protected $fillable = [
        'klant_ID',
        'broodje_ID',
        'status'
    ];

    protected $table = "bestellingen";
}

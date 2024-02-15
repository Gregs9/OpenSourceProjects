<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class OrderLine extends Model
{
    public $timestamps = false;
    use HasFactory;
    protected $fillable = [
        'id',
        'bestelbon_id',
        'pizza_id',
        'aantal'
    ];

    
}

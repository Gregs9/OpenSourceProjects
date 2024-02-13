<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('broodjes', function (Blueprint $table) {
            $table->id();
            $table->string('name');
            $table->text('omschrijving');
            $table->double('prijs');
        });

        // Insert some stuff
        DB::table('broodjes')->insert(
            array(
                [
                    'name' => 'Kaas',
                    'omschrijving' => 'Broodje met jonge kaas',
                    'prijs' => 1.90
                ],
                [
                    'name' => 'Ham',
                    'omschrijving' => 'Broodje met natuurham',
                    'prijs' => 1.90
                ],
                [
                    'name' => 'Kaas en ham',
                    'omschrijving' => 'Broodje met kaas en ham',
                    'prijs' => 2.10
                ],
                [
                    'name' => 'Fitness kip',
                    'omschrijving' => 'kip natuur, yoghurtdressing, perzik, tuinkers, tomaat en komkommer',
                    'prijs' => 3.50
                ],
                [
                    'name' => 'Broodje Sombrero',
                    'omschrijving' => 'kip natuur, andalousesaus, rode paprika, maïs, sla, komkommer, tomaat, ei en ui',
                    'prijs' => 3.70
                ],
                [
                    'name' => 'Broodje americain-tartaar',
                    'omschrijving' => 'americain, tartaarsaus, ui, komkommer, ei en tuinkers',
                    'prijs' => 3.50
                ],
                [
                    'name' => 'Broodje Indian kip',
                    'omschrijving' => 'kip natuur, ananas, tuinkers, komkommer en curry dressing',
                    'prijs' => 4.00
                ],
                [
                    'name' => 'Grieks broodje',
                    'omschrijving' => 'feta, tuinkers, komkommer, tomaat en olijventapenade',
                    'prijs' => 3.90
                ],
                [
                    'name' => 'Tonijntino',
                    'omschrijving' => 'tonijn pikant, ui, augurk, martinosaus en (tabasco)',
                    'prijs' => 2.60
                ],
                [
                    'name' => 'Wrap exotisch',
                    'omschrijving' => 'kip natuur, cocktailsaus, sla, tomaat, komkommer, ei en ananas',
                    'prijs' => 3.70
                ],
                [
                    'name' => 'Wrap kip/spek',
                    'omschrijving' => 'Kip natuur, spek, BBQ saus, sla, tomaat en komkommer',
                    'prijs' => 4.00
                ]
            )
        );
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('broodjes');
    }
};

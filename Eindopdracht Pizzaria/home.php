<?php
declare(strict_types=1);
require_once('data/autoloader.php');

$pizzaSvc = new PizzaService();
$lijst_pizzas = $pizzaSvc->getPizzas();



include('presentation/OverzichtPizzas.php');
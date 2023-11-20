<?php
declare(strict_types=1);
require_once('data/autoloader.php');
class PizzaService
{
    public function getPizzas(): array
    {
        $pizzaDAO = new PizzaDAO();
        $lijst_pizzas = $pizzaDAO->getAll();
        return $lijst_pizzas;
    }

    public function getPizzaById(int $pizza_id): ?Pizza
    {
        $lijst_pizzas = $this->getPizzas();
        foreach ($lijst_pizzas as $pizza) {
            if ($pizza->getId() === $pizza_id) {
                return $pizza;
            }
        }
    }
}
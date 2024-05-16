<?php
declare(strict_types=1);

class CustomException
{
    private $message;
    private $color;

    public function __construct(string $message, string $color)
    {
        $this->message = $message;
        $this->color = $color;
    }

    public function getMessage(): string
    {
        if ($this->message !== '') {
            return '<p id="feedback" 
            style="color:' . $this->color . '; width: 90%; cursor: pointer; text-align: center; background-color: #00000067; border-radius: 8px; display: block; padding: 0.5rem 0 0.5rem 0; margin: 0 auto;">' . $this->message . '</p>';
        } else {
            return '<p id="feedback"></p>';
        }
        
    }
}
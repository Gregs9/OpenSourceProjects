<?php
declare(strict_types=1);

class User
{
    private $id;
    private $username;
    private $email;
    private $password;
    private $status;
    private $type;
    private $creation;

    public function __construct(int $id, string $username, string $email, string $password, string $status, string $type, string $creation)
    {
        $this->id = $id;
        $this->username = $username;
        $this->email = $email;
        $this->password = $password;
        $this->status = $status;
        $this->type = $type;
        $this->creation = $creation;
    }

    public function getId()
    {
        return $this->id;
    }

    public function getUsername()
    {
        return $this->username;
    }

    public function getEmail()
    {
        return $this->email;
    }

    public function getPassword()
    {
        return $this->password;
    }

    public function getStatus()
    {
        return $this->status;
    }

    public function getType()
    {
        return $this->type;
    }

    public function getCreation()
    {
        return $this->creation;
    }
}
?>
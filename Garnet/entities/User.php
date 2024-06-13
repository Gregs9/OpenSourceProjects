<?php

class User
{
    private int $id;
    private string $username;
    private string $password;
    private string $role;
    private dateTime $creation;
    private string $status;
    private ?dateTime $last_score;

    public function __construct(int $id, string $username, string $password, string $role, DateTime $creation, string $status, ?dateTime $last_score)
    {
        $this->id = $id;
        $this->username = $username;
        $this->password = $password;
        $this->role = $role;
        $this->creation = $creation;
        $this->status = $status;
        $this->last_score = $last_score;
    }

    public function getId() : int
    {
        return $this->id;
    }

    public function getUsername() : string
    {
        return $this->username;
    }

    public function getPassword() : string
    {
        return $this->password;
    }

    public function getRole() : string
    {
        return $this->role;
    }

    public function getCreation() : DateTime
    {
        return $this->creation;
    }

    public function getStatus() : string
    {
        return $this->status;
    }
    public function getLastScore() : ?DateTime
    {
        return $this->last_score;
    }
}

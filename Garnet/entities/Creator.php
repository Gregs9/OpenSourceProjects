<?php

class Creator
{
    private int $id;
    private string $name;
    private string $alias;
    private $dateOfBirth;
    private string $nationality;
    private string $social_in;
    private string $social_x;
    private string $description;



    public function __construct(int $id, string $name, string $alias, $dateOfBirth, string $nationality, string $social_in, string $social_x, string $description)
    {
        $this->id = $id;
        $this->name = $name;
        $this->alias = $alias;
        $this->dateOfBirth = $dateOfBirth;
        $this->nationality = $nationality;
        $this->social_in = $social_in;
        $this->social_x = $social_x;
        $this->description = $description;
    }

    public function getId(): int
    {
        return $this->id;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getAlias(): string
    {
        return $this->alias;
    }

    public function getDateOfBirth()
    {

        if (date("Y", strtotime($this->dateOfBirth)) !== "0001") {
            return $this->dateOfBirth;
        }
        return null;
        
    }

    public function getNationality(): string
    {
        return $this->nationality;
    }

    public function getSocialIn(): string
    {
        return $this->social_in;
    }

    public function getSocialX(): string
    {
        return $this->social_x;
    }

    public function getDescription(): string
    {
        return $this->description;
    }

    public function getProfilePic() : string
    {
        require ('components/DBNameSnippet.php');

        if (file_exists($contentPath . '/Creators/' . $this->id . '.webp')) {
          return $contentPath . '/Creators/' . $this->id . '.webp';
        }

        return $contentPath . '/Creators/0.webp';
    }

    public function getFlag() : string
    {

        if (file_exists('assets/flags/' . strtolower($this->nationality) . '.png')) {
          return 'assets/flags/' . $this->nationality . '.png';
        }

        return 'assets/flags/unknown.png';
    }

    public function getAge() : ?int 
    {
        if ($this->dateOfBirth) {
            $date = new DateTimeImmutable($this->dateOfBirth);
            echo $date->format('j F Y');
            $year = (date('Y') - date('Y', strtotime($this->dateOfBirth)));
            return $year;
        }
        return null;

    }

}

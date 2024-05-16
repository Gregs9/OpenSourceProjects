<?php
declare(strict_types=1);

class Tag 
{
    private int $id;
    private string $name;
    private int $weight;
    private string $description;
    private $date_added;

    public function __construct(int $id, string $name, int $weight, string $description, $date_added)
    {
        $this->id = $id;
        $this->name = $name;
        $this->weight = $weight;
        $this->description = $description;
        $this->date_added = $date_added;
    }

    public function getId(): int
    {
        return $this->id;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getWeight(): int
    {
        return $this->weight;
    }

    public function getDescription(): string
    {
        return $this->description;
    }

    public function getDateAdded()
    {
        return $this->date_added;
    }

    public function getThumbnail(): string
    {
        require('components/DBNameSnippet.php');

        $category_thumbnail = $contentPath . '/Categories/' . str_replace(' ', '', strtolower($this->name)) . '.webp';

        $category_thumbnail = str_replace('-', '', $category_thumbnail);

        if (file_exists($category_thumbnail)) {
            return $category_thumbnail;
        } else {
            return 'assets/thumbnail_error.png';
        } 
    }
}
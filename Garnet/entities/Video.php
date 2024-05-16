<?php
declare(strict_types=1);

class Video
{
    private int $id;
    private string $filename;
    private string $extension;
    private DateTime $dateAdded;
    private int $score;
    private ?string $description;
    private ?array $tags;
    private int $views;
    private string $title;
    private string $duration;
    private int $filesize;
    private int $uploaded_by;

    public function __construct(int $id, string $filename, string $extension, DateTime $dateAdded, int $score, ?string $description, ?array $tags, int $views, string $title, string $duration, int $filesize, int $uploaded_by)
    {
        $this->id = $id;
        $this->filename = $filename;
        $this->extension = $extension;
        $this->dateAdded = $dateAdded;
        $this->score = $score;
        $this->description = $description;
        $this->tags = $tags;
        $this->views = $views;
        $this->title = $title;
        $this->duration = $duration;
        $this->filesize = $filesize;
        $this->uploaded_by = $uploaded_by;

    }

    public function getId(): int
    {
        return $this->id;
    }

    public function getFilename(): string
    {
        return $this->filename;
    }

    public function getExtension(): string
    {
        return $this->extension;
    }

    public function getDateAdded(): DateTime
    {
        return $this->dateAdded;
    }

    public function getScore(): int
    {
        return $this->score;
    }

    public function getDescription(): ?string
    {
        return $this->description;
    }

    public function getTags(): ?array
    {
        return $this->tags;
    }

    public function getTagsAsString(): string
    {
        $stringBuilder = '';
        foreach ($this->tags as $tag) {
            $stringBuilder .= $tag->getName() . ';';
        }

        //remove last semicolon from stringBuilder
        $stringBuilder = rtrim($stringBuilder, ";");

        return $stringBuilder;
    }

    public function getViews(): int
    {
        return $this->views;
    }

    public function getTitle(): ?string
    {
        return $this->title;
    }

    public function getDuration(): string
    {
        return $this->duration;
    }

    public function getDurationFormatted(): ?string
    {
        //Remove the hours mark in case it isn't neccesarry
        //current format is hh:mm:ss
        if ($this->duration !== '') {

            $formattedDuration = '';

            $arr_time = explode(':', $this->duration);
            $hours = $arr_time[0];
            if ($hours == '00') {
                $formattedDuration = $arr_time[1] . ':' . $arr_time[2];
            } else {
                $formattedDuration = $arr_time[0] . ':' . $arr_time[1] . ':' . $arr_time[2];
            }

            if ($formattedDuration[0] == '0') {
                $formattedDuration = substr($formattedDuration, 1);
            }
            return $formattedDuration;
        } else {
            return '';
        }
    }

    public function getFileSize(): int
    {
        return $this->filesize;
    }
    public function getUploadedBy(): int
    {
        return $this->uploaded_by;
    }

    public function getAspectRatio(): ?float
    {
        require ('components/DBNameSnippet.php');
        //check if thumbnail exists
        if (file_exists($contentPath . '/Thumbnails/' . $this->filename . '.webp')) {
            $thumbnailPath = $contentPath . '/Thumbnails/' . $this->filename . '.webp';
            //get image aspect ratio

            list($width, $height, $type, $attr) = getimagesize($thumbnailPath);

            return floatval(strval($width / $height));

        }
        return null;
    }

    public function getThumbnail(): string
    {
        require ('components/DBNameSnippet.php');

        if (file_exists($contentPath . '/Thumbnails/' . $this->filename . '.webp')) {
            return $contentPath . '/Thumbnails/' . $this->filename . '.webp';
        }
        return 'assets/thumbnail_error.png';
    }





}
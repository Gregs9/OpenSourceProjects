<?php
declare(strict_types=1);
require_once('data/autoloader.php');

class TagService
{
    public function getAllTags(): array
    {
        $tagDAO = new TagDAO();
        return $tagDAO->getAllTags();
    }

    public function getAllPopularTags(int $limit) : array
    {
        $tagDAO = new TagDAO();
        return $tagDAO->getAllPopularTags($limit);
    }

    public function getAllRecommendedTags(int $limit, User $user) : array
    {
        $tagDAO = new TagDAO();
        return $tagDAO->getAllRecommendedTags($limit, $user);
    }

    public function getTagOccurences() : array
    {
        $tagDAO = new TagDAO();
        return $tagDAO->getTagOccurences();
    }
    public function getTagById(int $tagId) : ?Tag
    {
        $tagDAO = new TagDAO();
        foreach ($tagDAO->getAllTags() as $search_tag) {
            if ($search_tag->getId() == $tagId) {
                return $search_tag;
            }
        }
    }

    public function getTagByName(string $tag_name) : ?Tag
    {
        $tagDAO = new TagDAO();
        foreach ($tagDAO->getAllTags() as $search_tag) {
            if (strtolower($search_tag->getName()) == strtolower($tag_name)) {
                return $search_tag;
            }
        }
        return null;
    }

    public function getAllTagsAsString(): string
    {
        $tagSvc = new TagService();
        $list_tags = $tagSvc->getAllTags();
        $new_list = array();
        foreach ($list_tags as $tag) {
            array_push($new_list, $tag->getName());
        }
        $new_list = implode(';', $new_list);

        return $new_list;
    }


    public function removePrimaryTagById(Tag $tag)
    {
        $TagDAO = new TagDAO();
        $TagDAO->removePrimaryTag($tag);
    }

    public function addPrimaryTag(string $tagName, int $tagWeight, string $description)
    {
        $tagsDAO = new TagDAO();
        $now = new DateTime('now');
        $tag = new Tag(0, $tagName, $tagWeight, $description, $now);
        $tagsDAO->addPrimaryTag($tag);
    }

    public function getAmountOfVideosWithTag(Tag $tag) : int
    {
        $tagDAO = new TagDAO();
        return $tagDAO->getAmountOfVideosWithTag($tag);
    }

    public function isNew(Tag $tag) : bool
    {
        $date_added = $tag->getDateAdded();
        $current_date = new DateTime();

        $current_date->modify('-1 month');
        if ($date_added < $current_date) {
            return false;
        } else {
            return true;
        }
    }

    public function removeAllTagsFromVideo(Video $video)
    {
        $tagDAO = new TagDAO();
        $tagDAO->removeAllTagsFromVideo($video);
    }

    public function updateTag(Tag $tag)
    {
        $tagDAO = new TagDAO();
        $tagDAO->updateTag($tag);
    }
}
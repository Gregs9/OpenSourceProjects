<?php
declare(strict_types=1);
require_once('data/autoloader.php');
class UserService
{
    public function getUsers(): array
    {
        $userDAO = new UserDAO();
        $lijst = $userDAO->getAll();
        return $lijst;
    }

    public function getUserById(int $id): ?User
    {
        $lijst_users = $this->getUsers();
        foreach ($lijst_users as $user) {
            if ($user->getId() === $id) {
                return $user;
            }
        }
    }

    public function getUserIdNameList() : array
    {
        $userDAO = new UserDAO();
        return $userDAO->getUserIdNameList();
    }

    public function addUser(string $username, string $password)
    {
        $userDAO = new UserDAO();
        $userDAO->addUser($username, $password);
    }

    public function blockUser(User $user)
    {
        $userDAO = new UserDAO();
        $userDAO->blockUser($user);
    }

    public function unblockUser(User $user)
    {
        $userDAO = new UserDAO();
        $userDAO->unblockUser($user);
    }

    public function validateUser(string $username, string $password): ?User
    {
        $userDAO = new UserDAO();
        $user = $userDAO->validateUser($username, $password);
        if ($user !== null) {
            return $user;
        } else {
            return null;
        }
    }

    public function checkUserStatus(User $user) 
    {
        if ($user->getStatus() == 'active') {
            return true;
        } else {
            return false;
        }
    }

    public function validatePasswordRepetition(string $password, string $password2): bool
    {
        if ($password === $password2) {
            return true;
        } else {
            return false;
        }
    }

    public function validateUsername(string $username): bool
    {
        //Controleer als het email adres al bestaat in de database
        $alreadyExists = true;
        $list_users = $this->getUsers();
        foreach ($list_users as $user) {
            if ($user->getUsername() === $username) {
                $alreadyExists = false;
                break;
            }
        }

        return $alreadyExists;
    }

    public function promoteUser(User $user) 
    {
        $userDAO = new UserDAO();
        $userDAO->promoteUser($user);
    }

    public function demoteUser(User $user) 
    {
        $userDAO = new UserDAO();
        $userDAO->demoteUser($user);
    }

    public function getUserStatusAction(User $user): string
    {
        $string_status = 'active <img style="height: 2rem;"src="assets/spinningrat.gif">';

        if (($user->getStatus() == 'active') && ($user->getRole() !== 'admin')) {
            $string_status = 'active <a title="Click to block this user." class="regular-link" href="controlpanel-users?block_id=' . $user->getId() . '">(Block)</a>';
        } elseif (($user->getStatus() == 'blocked') && ($user->getRole() !== 'admin')) {
            $string_status = 'blocked <a title="Click to reactivate this user." class="regular-link" href="controlpanel-users?activate_id=' . $user->getId() . '">(Activate)</a>';
        }
        return $string_status;
    }

    public function getUserRoleAction(User $user): string
    {
        $string_status = 'user';

        if ($user->getUsername() == 'cacodemon') {
            $string_status = 'The Cacodemon';

        } elseif (($user->getRole() == 'user') && ($user->getUsername() !== 'admin')) {
            $string_status = 'user <a title="Click to promote this user." class="regular-link" href="controlpanel-users?promote_id=' . $user->getId() . '">(Promote)</a>';
        } elseif (($user->getRole() == 'admin') && ($user->getUsername() !== 'admin')) {
            $string_status = 'admin <a title="Click to demote this user." class="regular-link" href="controlpanel-users?demote_id=' . $user->getId() . '">(Demote)</a>';
        }
        return $string_status;
    }

    public function getUserDeleteAction(User $user) : string
    {
        if ($user->getUsername() == 'cacodemon') {
            $string_action = 'cacodemon <img style="height: 2rem;"src="assets/cacopog.png">';
        } else {
            $string_action = $user->getUsername() . ' <a title="Click to delete this user." class="regular-link delete-user-link" href="#" data-userid="' . $user->getId() . '">(Delete user)</a>';
        }
        return $string_action;
    }

    public function removeUser(int $user_id)
    {
        $user = $this->getUserById($user_id);
        $userDAO = new UserDAO();
        $userDAO->removeUser($user);
    }

    public function updateLastScore(User $user)
    {
        $userDAO = new UserDAO();
        $userDAO->updateLastScore($user);
    }

    public function favoriteCreator(User $user, Creator $creator)
    {
        $userDAO = new userDAO;

        //check if creator isn't already added to this user's favorites
        foreach ($this->getFavoriteCreators($user) as $check_creator) {
            if ($check_creator->getId() == $creator->getId()) {
                return;
            }
        }

        $userDAO->favoriteCreator($user, $creator);
    }

    public function unfavoriteCreator(User $user, Creator $creator)
    {
        $userDAO = new userDAO;
        $userDAO->unfavoriteCreator($user, $creator);
    }

    public function getFavoriteCreators(User $user) : array
    {
        $userDAO = new UserDAO;
        return $userDAO->getFavoriteCreators($user);
    }

    public function isCreatorFavorited(User $user, Creator $creator) : bool
    {
        $userDAO = new UserDAO;
        return $userDAO->isCreatorFavorited($user, $creator);
    }

    public function favoriteVideo(User $user, Video $video)
    {
        $userDAO = new userDAO;

        //check if video isn't already added to this user's favorites
        foreach ($this->getFavoriteVideos($user) as $check_video) {
            if ($check_video->getId() == $video->getId()) {
                return;
            }
        }

        $userDAO->favoriteVideo($user, $video);
    }

    public function unfavoriteVideo(User $user, Video $video)
    {
        $userDAO = new userDAO;
        $userDAO->unfavoriteVideo($user, $video);
    }

    public function getFavoriteVideos(User $user) : array
    {
        $userDAO = new UserDAO;
        return $userDAO->getFavoriteVideos($user);
    }

    public function isVideoFavorited(User $user, Video $video) : bool
    {
        $userDAO = new UserDAO;
        return $userDAO->isVideoFavorited($user, $video);
    }

    public function getWatchHistory(User $user) : array
    {
        $userDAO = new UserDAO;
        return $userDAO->getWatchHistory($user);
    }

    public function getLatestScores(User $user) : array
    {
        $userDAO = new UserDAO;
        return $userDAO->getLatestScores($user);
    }
}
  _________                  .___       .__       .__      ___.                 
 /   _____/____    ____    __| _/_  _  _|__| ____ |  |__   \_ |__ _____ _______ 
 \_____  \\__  \  /    \  / __ |\ \/ \/ /  |/ ___\|  |  \   | __ \\__  \\_  __ \
 /        \/ __ \|   |  \/ /_/ | \     /|  \  \___|   Y  \  | \_\ \/ __ \|  | \/
/_______  (____  /___|  /\____ |  \/\_/ |__|\___  >___|  /  |___  (____  /__|   
        \/     \/     \/      \/                \/     \/       \/     \/       

Introduction
This is the developer documentation for the sandwich bar aka De Broodjesbar. This project is developed as an exercise for my Full-Stack Developer course, and therefore is primarily written with Dutch variable & function names. A lot of methods used in this project may not be optimal, as I am still learning to work with Laravel. Styling is done in regular css files instead of using the built-in Tailwind framework. To function, this project requires Laravel installed.

About
This website is an exercise in Laravel. I had to create a webpage, that allows users to register and login. Users have a customer role by default, but their accounts can be promoted to administrator. Customers can select a sandwich from the "bestel" page. Administrators can update orders, and block or re-activate users. The goal of this website is to properly separate a user's role and allow them to access certain pages, while preventing them from accessing other pages.

Structure
This project follows Laravel's built-in expanded version of the MVC approach, therefore there is little leniency when it comes to where what file or code goes in the directory (which is a good thing!)
I will further expand on the primary directories and files used.

Migrations
Inside the root/database/migrations directory, you will find the database migrations, running "php artisan migrate" in your terminal will create the required database tables.
Make sure the DB_NAME, DB_USERNAME a DB_PASSWORD is set correctly in your root/.env file.

Models
Inside root/Models you will find the three required models for this application. Each model has properties containing all data we need. The Broodje model is empty since all data was provided and editing/adding/remove a Broodje was outside the scope of this project.
The user Model has some basic properties, along with a status and role property. The status is either blocked or active, which allows administrators of the website to prevent malicious users from accessing the website.

Routes
Inside root/routes/web.php you can find all routes for this website. The first route you will see is "/" named "home", this is the home page, and if the user is not logged in, it will return the "welcome" view. If the user is logged in, it will automatically redirect the user to either the "overzicht" or "besteloverzicht" depending on the type of the user. If the user's type (or role) is customer, they will be redirected to the "bestel" page, where they can order a sandwich. If the user's type is administrator ("medewerker"), they will be redirect to the "overzicht" page.
As you can see, the routes for the home page, login and register pages are accessible by all users, since they need to have the opportunity to create an account or log in of course. All other routes, like viewing the protected pages, creating an order, changing user types and so on are protected. These pages can only be accessed once the user is logged in. To protect these routes, we use Laravel's built-in authentication middleware.

Controllers
To handle all user actions regarding logging in, out and registering, I created an AuthManager.php controller, which contains all logic.
The loginPost method, will retrieve the entered data by the user on the login page (more on this later) and validate this data. If the data is successfully validated, the user will be redirect to the correct page, depending on their account type. It will also check if the account isn't blocked. If the user entered incorrect credentials, or their account is blocked, we will return to the home page with an additional message informing the user what went wrong.
Similar to logging in, the registerPost method will retrieve the data entered by the user in the registration form, validate this data, and create an account if all data entered was valid. The user's given password will be properly encrypted before being stored in the database, for obvious security reasons.
Once the user's account is created, we will return them to the home page and display the proper message.
The logout method is a very simple function, that will simply flush the session storage (to forget the user) and use Laravel's Auth middleware to call the logout function. A message will be displayed and we're done.

the "BestellingsController.php" is the controller handling all logic for creating and updating customer orders. To know what user ordered what sandwich, we can simply retrieve the logged in user's ID when creating an order. This controller contains a few very basic CRUD operations.

The "BroodjesController.php" only contains a single function that retrieves all "Broodjes", so we can display them when the user is selecting a sandwich to order.

The "UsersController" is the controller that handles all user actions. Not to be confused with the AuthManager, which contains all logic for handling user data like logging in, out and registering. This controller is for updating user account types and blocking or activating accounts.

Views
Inside the root/resources/views directory, you can find the actual layout for each web page. 
Note that all these files contain the blade extension, which means the blade templating engine is used.
Starting with the "welcome.blade.php" file, this is the first page the user you will see when first accessing the website. This page contains both a login and registration form. This view will also always check whether the message or success variables have been set, and if so, display their message. This will retrieve any messages or errors thrown by the controller and display them. As you would, expect, the action attributes of the form point to the route for handling that logic.

The "bestel.blade.php" view is a page customers will be able to see once they are logged in. This page displays a table containing all relevant data about the sandwiches. Each row in the table contains a link that when clicked, will place an order for that sandwich by the logged in user. On the top of this view you will also see a simple link pointing to the logout route for when the user wishes to log out.

The "overzicht.blade.php" view contains a table for all orders, and users. Administrators on this page are able to update orders using links pointing towards the appropriate routes. The same thing goes for updating user accounts.

CSS
I did not use Laravel's built-in Tailwind framework for css in the project yet. Normally, css files are stored in the resources/css directory, and when compiled, will be moved to the public/css directory. However, for easier development, I stored them directly in the public directory, along with all required assets for simplicity.





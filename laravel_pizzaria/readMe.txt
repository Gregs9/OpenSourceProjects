______ _                   _       
| ___ (_)                 (_)      
| |_/ /_ __________ _ _ __ _  __ _ 
|  __/| |_  /_  / _` | '__| |/ _` |
| |   | |/ / / / (_| | |  | | (_| |
\_|   |_/___/___\__,_|_|  |_|\__,_|
                                   
About
This web application is an exercise in my Full-Stack Developer course using the Laravel framework. The goal is to re-create a functional website customers are able to use to order a pizza. The scope of this project is limited to being able to select items using a caddy, login, and register (or checkout as guest) and place an order for the business to see. Real-life use cases like adding new Pizza's, functional promotions, and more are not within the scope of this project and therefore not functional.
Since the scope of this project is limited, the database used is not fully normalized. I do not use separate tables for storing addresses and such. The database is however properly normalized for the data we do require like postal codes, orders, order lines, and more.

Disclaimer
Please do not use any real data when registering on this web application. Passwords are properly encrypted, but just in case a vulnerability is discovered, the data you entered may be compromised. Given email addresses and phone numbers do not have to be verified through your inbox, so you can just enter anything that looks like an email address or phone number.
I'm not sure if I should add this to the disclaimer as well, but just in case. Even though you may receive a message stating your order has been placed. You will not receive any actual items. Like I said, this is just a demo.

Let's investigate the files!

Routes are stored in root/routes/web.php.
You will see three basic routes first, which are for navigating the three first pages of the website.
The first route "home" is the route that will retrieve all pizzas from the PizzaController, and use these to display all pizzas on the home page.
The second route "promoties" is the route that will simply return the “promoties” view, which is a basic page displaying promotional information.
The third route "overons" is the route that will also simply return a view containing information about the business selling the pizzas, with some customer reviews.

The "inloggen" route will check if the user is already logged in using the auth() middleware, and if so, immediately redirect the user to the "besteloverzicht" page.
If the user is not already logged in, they will first be prompted to the login/register page, where they can create an account or log in if they already have one.
The login & register post routes are used for sending this data entered by the user to the controller, which will validate this data and add it to the database if needed.
The "afrekenen" route will return a view containing this user's selected order, since the contents of the caddy is stored in a cookie, the PizzaController will read this cookie and return the data to this new page.

On the bestelOverzicht page, the user can check their address, and change it if needed. the "adresWijzigen" route will retrieve data entered by the user when they wish to change their address. The UsersController will validate this data.

As you may notice, no routes are protected by the Auth middleware except the logout route. This is because the user doesn't have to create an account in order to place an order and can also just checkout as guest. Protecting these order routes would prevent users from ordering unless they made an account.

Controllers are stored in root/app/Http/Controllers.
The AuthManager is a controller that contains all logic for logging in users, registering users and logging users out.
One of the requirements for this web application is that the business only delivered to certain postal codes, therefore, users can only create an account when their postal code is within the given array of possibilities.

Additionally, the register method will also check if the user wishes to create an account, if they do, their given email and password are also verified, if not, the data they entered is simply stored in the browser's session storage and will be deleted once they close the web application.

OrderController contains the logic for adding an order to the database. We will first check if the user is logged in, if so, retrieve their data from the database. If the user is not logged in, we will retrieve their data from the browser's session storage instead. We will write an order containing the customer's necessary data and write an order line for each item ordered by the customer. Once the order is placed, we will also delete potentially stored session storage from the browser and remove the cookie containing their order since it has now been ordered.

The pizzaController has a simple function that will retrieve all pizzas from the Pizza model and return them. This is only used for displaying the pizzas on the home page. An additional function this controller contains, is the getOrder() function, which will return all required data for placing an order from the user's order cookie, and potentially existence within the database. It will do some extra validation and calculate the total order price and return this information too.
Based on if the user is logged in or a guest, I return a different view. We could do this in a single view, and check if the user is logged in on the view itself, but to keep the view clean of any logic, I chose to split these views. More on these views later.

The UsersController contains a single function that will validate and change the user's address on the bestelOverzicht page. It will check if the user is logged in and update their data in the database when they changed their address. If the user is not logged in, it will instead overwrite existing session storage containing the new information the user entered.

Models are stored in root/app/Models.
The models in this project speak for themselves, each model is a representation of a table in the database and has properties containing the table names. These Eloquent models are an improved way over normal OOP, since these models represent an entire state of the database rather than creating the objects individually.

Views are stored in root/resources/views.
These are the views used by this web application. As you may notice, the header, footer, and caddy views are split into separate views. However, they will be included wherever we need them. This way we can easily make adjustments later if needed, and we create a more organized application. You will also see two separate afrekenen pages, one regular, and one for guest users. Since the data we retrieve on this page is different for logged in users and guest users, I have decided to split this page into two views for a more organized application.

Css/JS/Assets are stored in the public folder.
This directory contains the required css, js and asset files used in this web application. The JS contains all the script used, like managing the colors of the header menu, adding items to the caddy, updating the caddy (on the afreken page) and some other display functionality.


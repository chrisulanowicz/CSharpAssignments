Index of C#/.NET assignments progressing from the basics to more advanced

SECTION I - C#/.NET FUNDAMENTALS  (in Console Applications)
===========================================================

  1. first_csharp
  		- beginning 'Hello World' app

  2. fundamentalsI
  		- basic loops and conditionals with FizzBuzz

  3. collectionsPractice
  		- working with Arrays, Multi-Dimensional Arrays, Lists, and Dictionaries

  4. boxingUnboxing
  		- basics of Boxing and Unboxing

  5. basic13
  		- 13 simple algorithms

  6. puzzles
  		- using Random, coin toss simulator, and a shuffle function

  7. human
  		- basic OOP creating a Human class with fields, methods, and constructor

  8. deckOfCards
  		- more OOP creating Card, Deck, and Player classes with some methods that could be 		used as a foundation to a card game

  9. wizardNinjaSamurai
  		- cont'd OOP inheriting from previous Human assignment
  		- create 3 new Human inherited classes with methods to interact with each other

 10. musicLinq
      - basic LINQ queries done on given JSON sets

 11. simpleCrudWithMySQL
      - connect to an existing MySQL database
      - implement basic CRUD queries


 SECTION II - ASP.NET CORE I
 ==================================================================

 12. callingCard
      - setup a simple ASP.NET Core web app that takes in route parameters and returns a json object
      - starts with just the 'C' (Controller) of 'MVC'

 13. RapperApi
      - create a basic API using the JsonData from the previous musicLinq assignment
      - practice with routes, route parameters, LINQ, JSON

 14. TimeDisplay
      - simple web app that just displays the current date and time
      - adds the 'V' (View) in 'MVC' along with the Razor View Engine

 15. Portfolio
      - basic multi-page website making use of static files
      - Please ignore the ugly styling, this is a C# course, so I didn't want to spend a lot of time on CSS, only enough to make sure all static files are working properly

 16. SurveyForm
      - web app that takes some form data and then displays it on a separate view
      - practice with POST requests and sending data from the Controller to View with ViewBag

 17. RandomPasscode
      - simple web app that generates a random password/passcode
      - introduces Session to keep count of passcodes generated
      - includes 2 generators, one requiring a server refresh and a second via AJAX using jQuery while still persisting count in Session

 18. DachiPet
      - Virtual Pet game where you perform actions that affect your pet's attributes
      - Builds on previous assignments and adds more complexity
      - Practice with OOP, Classes, AJAX, jQuery, Session, VC of MVC, routes, JSON
      - DEPLOYED LIVE ON AZURE   http://dachipet.azurewebsites.net/


 SECTION III - ASP.NET CORE II
 ==================================================================

 19. PokemonInfo
      - Displays info from an external API using Backend API calls
      - Project spun up using Yeoman Candyman
      - Implements View _Layout

 20. AzureDeployments
      - Text file with urls of deployed assignments on Azure
      - Currently contains DachiPet

 21. QuotingApp
      - Connect to MySQL database
      - simple app that allows user to add a quote that's stored in db and view all quotes

 22. AJAX Notes
      - app that allows user to add a note, edit it, and delete it
      - adds rest of CRUD when connecting to database
      - connection to database made more secure and involves Dependency Injection
      - AJAX portion of assignment skipped for now due to time and need to focus on ASP.NET

 23. Form Submission
      - adds Models (M) to complete the MVC
      - validates form inputs and either displays error messages or directs to success page
      - uses DataAnnotations

 24. Login and Registration
      - Complete User Login & Registration form with full validations and error message display
      - Once validated User is saved in DB/logged in and sent to page that lists all users
      - Implements Frontend and Backend Model Binding plus tag helpers

 25. The Wall
      - A Message Board app that allows users to post messages and comments to messages
      - Includes a login & registration
      - Combines prior exercises for a more complex web app
      - Practice with MVC, Session, MySQL, DB Connection, Validations, Model Binding, etc.


SECTION IV - ORMS - ADDING ENTITY FRAMEWORK CORE TO ASP.NET CORE
=============================================================================

 26. RESTauranter
      - simple app that allows users to leave reviews for restaurants
      - add Entity Framework Core basics* and custom validation
      - * Ran into roadblock. Course uses an Entity-MySql connector that doesn't work with ASP.NET Core version 2.0 which caused a MissingMethodException (exception wasn't too descriptive and took a while to figure out the version incompatability).  Eventually found another connector by Pomelo which does work.

 27. BankAccounts
      - app where users can register/login, open bank accounts and make transactions
      - adds Entity Framework Relationships to the mix
      - also added more features to registration/login along with password hashing
      - ASP.NET Core 2.0, Entity Framework Core, MySQL

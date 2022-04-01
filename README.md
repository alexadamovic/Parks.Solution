# State & National Park Lookup API

#### A C# API built within an ASP.NET Core MVC framework with Entity to integrate MySQL databases

#### By Alex Adamovic

## Technologies Used

* _C#_
* _HTML_
* _MySQL_

### Dependencies

* _Entity_
* _ASP.NET Core_
* _Swashbuckle_

## Description

_This C# API acts as a utility to interact with a database of State and National parks, utilizing a MySQL database that connects ```locations``` and ```parks``` tables in a One-To-Many relationship. The user is able to query the API at multiple endpoints to return lists or singular instances of ```Park``` or ```Location``` objects according to several queryable parameters (see table below). The API follows RESTful standards, and the user is given full CRUD access to both classes. Swagger documentation is included and is accessible via the browser when running the application._

### Endpoints

|           Page Name          |                                  Description                                       | 
| :--------------------------: | :--------------------------------------------------------------------------------: |
| Quotes  | A quote generator that utilizes the [ProgrammingQuotesApi](https://programming-quotes-api.herokuapp.com/index.html) to relay quotes from famous programmers with a humorous banana themed twist |
| Jokes | Call a random banana joke from the [wowthatsbig](https://wowthatsbig.net/) API |
| Facts | Display a random banana fact. Fact: All of the facts are true facts |
| Conversion | Users are able to enter a unit of measurement, a number of units, and then convert that measurment to its equivalent size or volume in bananas. Users are also treated to the banana equivalent of a random item called from the [wowthatsbig](https://wowthatsbig.net/) API when they submit |
| BPH  | Convert a speed in miles per hour to bananas per hour  |
| TicTacBanana | Play a friendly game of "tic tac toe" locally on your device. Banana vs. Kiwi. Who will win??? |
| Jump Game | Jump over the kiwi as many times as you can. Test your high score! |
| CLB | Play rock (coconut), paper (leaf), scissors (banana) against the computer |
| Pong Banana | How much time do you have to waste? We dare you to try to beat our AI in a game of banana pong |
| Meet the Kingz | Get to know the team behind bananakingz.net! |

## Setup/Installation Requirements

#### To Install MySQL & MySQL Workbench

* _go to https://dev.mysql.com/downloads/ and install **MySQL Community Server** and **MySQL Workbench** for your operating system_
* _follow the instructions at [learnhowtoprogram](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql) for proper installation_

#### To Set Up Project With Dependencies

* _clone repository from https://github.com/wcjameson/RecipeBox_
* _navigate to the project directory in your terminal/command line_
* _navigate to the subdirectory Factory and enter ```dotnet restore``` to install project dependencies_

#### To Create appsettings.json

* _navigate to the subdirectory Factory and create the file ```appsettings.json```_
* _add the following code:_
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR_DATABASE];uid=[YOUR_USER_ID];pwd=[YOUR_PASSWORD];"
  }
}
```
* _replace the applicable sections with your database name, your user ID, and your password_

#### To Create Database using Migrations

* _navigate to the project directory in your terminal/command line_
* _navigate to the subdirectory Factory and enter ```dotnet ef database update``` to create a new local database for the project_
* _the database will take the name specified in your ```appsettings.json``` file and can be viewed using MySQL_

#### To Run the Web Application

* _navigate to the subdirectory Factory and enter ```dotnet run``` for a snapshot server or ```dotnet watch run``` for a live updating server for the application_
* _access the server in your browser by entering ```localhost:5000``` into your navigation bar_
* _click the hyperlinks and submit forms to navigate between the views_
* _enter ```ctrl``` + ```c``` for Windows or ```command``` + ```.``` for Mac in your terminal/command line to stop the server_

## Known Bugs

* _None_

## License

_MIT License_

Copyright (c) _2022_ _Alex Adamovic_
Copyright (c) _2022_ _William Jameson_ 

## Contact Information

alexanderadamovic@gmail.com | williamjameson90@gmail.com
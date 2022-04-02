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

|   Request | URL  |  Description  | 
| :----------: | :------------------------: | :----------------------------: |
| GET | localhost:5000/api/parks  | Returns a list of all parks |
| GET | localhost:5000/api/parks/{id} | Returns a park with the specified int {id} |
| GET | localhost:5000/api/parks?name={name} | Returns a park with the exact match for string {name} |
| GET | localhost:5000/api/parks?statePark=true | Returns a list of State parks (bool set to false unless specified true) |
| GET | localhost:5000/api/parks?nationalPark=true | Returns a list of National parks (bool set to false unless specified true) |
| GET | localhost:5000/api/locations  | Returns a list of all locations |
| GET | localhost:5000/api/locations/{id}  | Returns a location with the specified int {id} |
| GET | localhost:5000/api/locations?state={state}  | Returns a location with the exact match for string {state} |
| GET | localhost:5000/api/locations?mostParks=yes  | Returns a descending list of locations by the number of parks associated with each location (must be set to string {yes}) |
| GET | localhost:5000/api/locations?minParks={int}  | Returns a list of all locations with at least int {int} number of parks associated with each location |
| POST | localhost:5000/api/parks  | Add a new park |

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
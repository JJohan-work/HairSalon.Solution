# Salon Database

#### Database program for keeping track of Stylists and clients of a hair salon

#### By Jonah Johansen

* * *

## Technologies Used

* _C#_
* _.Net v5.0_
* _ASP.Net Core_
* _MYSQL_
* _MYSQL WorkBench_
* _Entity Framework Core_
* _REPL_
* _Git and Github_

## Description
This web app can keep track of stylists and clients, sorting Clients by Stylists, adding new Stylists and Clients and modifing pre-existing entries. MySQL is used to keep permenant records as long as the mysql database is kept connected to the program.
* * *

## Setup/Installation

* .Net 5.0 is required to build and execute this program.
* MySql is required to connect the webserver to a Database


* Download Repo from github or clone using ```git clone {gitURL}```

<ins>Creating the database from mysql</ins>  
* Open terminal and start sql using ```mysql -u[sqlUserName] -p[sqlPassword]```.
* run command ```SOURCE [FULL_PATH_TO_PROJECT]/jonah_johansen.sql``` to create database and tables.

<ins>Creating ```appsettings.json```</ins>  
appsettings.json is used to connect webserver to the sql server.
* Create file ```appsettings.json``` in ```~/HairSalon/```.
* Copy into appsettings.json this blurb replacing username and password with your sql database details.
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=jonah_johansen;uid=[YourUserAccount];pwd=[YourPassword];"
  }
}
```

<ins>Starting Web Server from Terminal:</ins>
* Navigate from root directory to ```~/HairSalon/``` and run command ```dotnet restore``` to download and build project dependencies.
* To Run Program: While in ```~/HairSalon/``` run command ```dotnet run```. Program should compile and execute in terminal. If successful terminal will display the url page can be accessed by like ```http://localhost:5000/```.
* Open page in browser using url given in terminal. Default: ```http://localhost:5000/```.


* * *

## Known Bugs

*none tracked at this time*

* * *

## License:
> *&copy; Jonah Johansen, 2021*

Licensed under [MIT license](https://mit-license.org/)

* * *

## Contact Information
_Jonah Johansen: [Email](johansenjonah+git@gmail.com)_
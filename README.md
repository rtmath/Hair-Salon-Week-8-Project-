

# Hair Salon Webpage

### by Ryan Mathisen 12/9/2016

## Description

This project is a SQL exercise with C#.

## Installation
To Install this Program:
  * In SQL Server Management Studio (instructions may vary for SQLCMD users):
    * Connect to:
      * Service Type: Database Engine
      * Server Name: (localdb)\mssqllocaldb
      * Authentication: Windows Authentication
    * Select _'New Query'_
    * Enter the following Query into the query window:
      * CREATE DATABASE hair_salon;
    * Click _'Execute'_
    * Then enter the following Query into the query window:
      * USE hair_salon;
      * CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));
      * CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);
    * Click _'Execute'_ again
  * In Windows Powershell:
    * Clone this repository to the desired location on your computer
    * Run the command _"dnu restore"_
    * Run the command _"dnx kestrel"_
  * In your favorite internet browser:
    * Access the url "localhost:5004"
  * Enjoy!

I have also included the SQL scripts for this project (located in /SQL Scripts), which you can import in SSMS by doing the following:
  * Select _File > Open > File_ and select the .sql File
  * If you haven't already created the database, add the following code to the top of the script file:
      * CREATE DATABASE hair_salon
      * GO
  * Click _'Execute'_ and enjoy!


## Specifications

| Behavior                                                                           |
|------------------------------------------------------------------------------------|
| The user can add new Stylists to the system                                        |
| The user can access a list of all Stylists                                         |
| This user can access the details of a Stylist and a list of that Stylist's Clients |
| The user can add new Clients to a specific Stylist                                 |
| The user can update a Stylist's details                                            |
| The user can update a Client's details                                             |
| The user can delete a Stylist                                                      |
| The user can delete a Client                                                       |

## Technologies Used
* HTML5/CSS (+ Bootstrap)
* C# (+ Nancy/Razor)
* SQL (using SQL Server Management Studio)

## License
Copyright (c) 2016 Ryan Mathisen

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

# University Registrar Webpage

#### Project for Epicodus, 07/19/2016

#### By Shradha Pulla & Wolfgang Warneke

## Description

Longer succinct description of program.

## Setup/Installation Requirements

This program can only be accessed on a PC with Windows 10, and with Git, Atom, and Sql Server Management Studio (SSMS) installed.

* Clone this repository
* Import the database and test database:
  * Open SSMS
  * Select the following buttons from the top nav bar to open the database scripts file: File>Open>File>"Desktop\RepositoryName\Sql Databases\database_name.sql"
  * Save the database_name.sql file
  * To create the database: click the "!Execute" button on the top nav bar
  * Repeat the above steps to import the test database
* Test the program:
  * Type following command into PowerShell > dnx test
  * All tests should be passing, if not run dnx test again
* View the web page:
  * Type following command into PowerShell > dnx kestrel
  * Open Chrome and type in the following address: localhost:5004

## Known Bugs

No known bugs.

## Specifications

The program should ... | Example Input | Example Output
----- | ----- | -----
Add student information to database | "Jane Doe","999999", "07-19-2016" | Jane Doe added to database
View all students in database | --- | ---
Find one student based on student number | --- | ---
Add course information to database | "Intro to Programming", "CS101", "000000" | Intro to Programming added to database
View all courses in database | --- | ---
Find one course based on course number | --- | ---
Add students to course | --- | ---
View all students in one course | --- | ---

## Future Features

HTML | CSS | C#
----- | ----- | -----
----- | ----- | -----

## Support and Contact Details

Contact Epicodus for support in running this program.

## Technologies Used

* HTML
* CSS
* Bootstrap
* C#

## License

*This software is licensed under the Microsoft ASP.NET license.*

Copyright (c) 2016 Shradha Pulla & Wolfgang Warneke

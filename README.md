**Project Description**
CCG

**_Crud Class Generator_** has developed to generate class which is object model of a database table. 
Via these generated classes, many CRUD processes can be done without writing SQL query.

**CCG is easy to use**, because; it is developer-friendly
**CCG is practical**, because; it allows to make many crud processes without writing sql query
**CCG is fast**, because; it’s object size very small and it allows to make more than one processes at a time.

**For example;** fallowing processes can be done in a transaction at a time.
-Insert some rows to Table1 and get returned Identity value.
-Insert some other rows to Table2 by using Identity value of Table1 and get returned Identity value of Table2,
-Update some rows on Table3 by using Identity value of Table2,
-Delete some rows on Table4,
-Select some rows from Table1

_Do all these processes with just one command at a time_

**Some Features:**

*It has a simple and easy-to-use interface.

*Generated classes are easy to use and performant.

*In addition to the CRUD class, the Interface class can also be generated.

*Parameter class can be generated as a separate file or inside a CRUD or Interface class.

*CRUD operations can be logged.

*Both ADO and SQL transaction can be used.

*AdHoc query can be run and this query can be logged.

*Stored Procedure can be called.

*Multiple generated insert commands can be sent to the database in bulk.

*More than one command prepared for different operations can be sent to the database at the same time.

*During the CRUD process, the database name, connection string name and command timeout can be changed.

*Dataset can be returned in DataTable type or class type.

*Aggregate functions such as MIN, MAX, SUM, AVG, COUNT can be used.

*Support MS-SQL AlwaysOn ROR (Read Only Routing) feature.

*Enums can be automaticly generated from Lookup or other tables with all data or partial data by writing sql query.

*Connection string can be read from config file or from registry.

*Prevents SQL Injections.

*You can generate CRUD classes by selecting as many tables as you want at the same time.


***------------------***

To get current source codes and downloads visit https://sourceforge.net/projects/ccg4dal/

To get help about CCG please visit http://ccg.snazzydocs.com/

You can send your questions and suggestions to ccg4dal@gmail.com

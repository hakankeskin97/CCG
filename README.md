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

**Some Other Features:**
-ADO or SQL transections can be used.
-CRUD processes can be logged.
-Typed DataSet integration is possible.

**+To start to use this Data-Access_Layer; +**

**Download the fallowing files:**
1. +For SQL Server 2005 or Higher:+
.....a.	CCG 3.2.5 S
.....b.	CCGDataService 3.0.0 S
.....c.	Helper 3.0.0
2. +For SQL Server 2005 or Higher and For Oracle:+
.....a.	CCG 3.2.5 SO
.....b.	CCGDataService 3.0.0 SO
.....c.	Helper 3.0.0

**_Setup;_** "CCG 3.2.5 S" or "CCG 3.2.5 SO",
**_Set_** database connection string, solution path and project names,
**_Save_** these settings,
**_select_** schema and table to be generated,
**_Include_** generated classes to the projects and 
**_start to write code._**

# Bet-eCommereceMaster  E-Commerce

-This app was designed using Visual Studio 2017, .Net Core 2.1 framework 

The Bet-eCommerece API is an API used for Shopping and Making Orders.   
This project is currently in development stage.

## Table Of Content
1. [General Info] (#general-info)
2. [Technologies] (#technologies)
3. [Installation] (#installation)
4. [Collaboration] (#collaboration)
5. [API Flow] (#apiflow)

## Technologies
***
A list of technologies used within the project:
* [Visual Studio 2019] (https://visualstudio.microsoft.com/downloads/)
* [.Net Core] (https://dotnet.microsoft.com/download/dotnet/3.1)
* [Sql Server Management Studio 18] (https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)



## Installation
***
You need to create a database, update the connection string then run the API.
***
1. git clone https://github.com/Sbu1/StudentsAPI.git using git or download the project direct https://github.com/Zizwemkz/Bet-eCommerceMaster
2. Execute BETecommerceDB script in sql server which is in the project root folder.
3. Open the project using visual studio.
4. If you are using local sql server you don't need to update your connection string but if you using testing environment please change the server name in the connection string to point to your testing server.
6. If you need postman collection, you can find it in the root folder of the project


-Database server: MS SQL Server 2014 LocalDb Express

-You might also need to first insert Departments categories and items to the database to test the functionality of the order feature.


## FAQs

## High Level Architecture

## API Flow
1.You need to account User using hidden end point 


2.Login to the system using your credentials you created 

3. First Create a Department that will be using the system 

4. Second Create a Cartegories that will be using the system 

5. Third Creat Items in Stock that will Apear to shopping.

6. To See all the items in a shoping Manner select By department All departments

7. User Local DB Database To run all the tables on the  project you have to add-migrations and update that database 

8. Create Department
9. Create Categories 
10. Create Item
11. Create Cart
12. Create a CartItem
13. Create Order




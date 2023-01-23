# MediClaim-CRUD

Simple Mediclaim CRUD app made in ASP.NET MVC Core and .NET Web API.

## Tech Stack

- ### Frontend : ASP.NET Core, Razor Pages
- ### Backend : .NET Core Web API 
- ### Database : MS SQL

## Steps to run project in development mode

- Create Database named as ClaimManagement and Create Table by running the CreateTable.sql file.
- Run the WebApiDemo project first by opening its solution in Visual Studio.
- Run the FrontendDemo project first by opening its solution in Visual Studio.
- Incase if dependencies are not installed properly or database is not getting connected then follow [these steps](https://gist.github.com/Gstar1525/7729a3ddf943ad18f280599213c0ee17).

## API routes

- Create Claim (POST) - ``` /api/mediclaims ```
- Read All Claims (GET) - ``` /api/mediclaims ```
- Read Claim by Id (GET) - ``` /api/mediclaims/{id} ```
- Update Claim (PUT) - ``` /api/mediclaims/{id} ```
- Delete Claim (DELETE) - ``` /api/mediclaims/{id} ```

## Client routes

- Create - ``` /mediclaim/create ```
- Read - ``` / ```
- Read By Id - ``` /mediclaim/details ```
- Update - ``` /mediclaim/edit ```
- Delete - ``` /mediclaim/delete ```

## Screenshots

- ### Home Page - Read
![read](https://user-images.githubusercontent.com/52004037/214099900-841f9feb-ee40-45de-8f3d-c2dbfe096ed7.png)

<br/>

- ### Create Page
![create](https://user-images.githubusercontent.com/52004037/214099939-a543c1fd-e870-468b-be10-c9f72c1986c0.png)

<br/>

- ### Read/Delete/Update By Id
![byId](https://user-images.githubusercontent.com/52004037/214100059-8fa7472b-a1f1-4a14-ba03-4f8572cf8422.png)

<br/>

- ### Update Page
![update](https://user-images.githubusercontent.com/52004037/214099969-19bc95f7-e65a-4f12-9fb3-bac0932d5d7a.png)

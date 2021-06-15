# Customer Management

## Sign in

| User | Password |
| ------ | ------ |
| admin@app.com | admin@123 |
| seller1@app.com | admin@123 |
| seller2@app.com | admin@123 |

## Preview
<img src="https://raw.githubusercontent.com/saulocorrea/customer-management/master/sig-in.jpg">


<img src="https://raw.githubusercontent.com/saulocorrea/customer-management/master/customer.jpg">

## Tech

Customer Management uses a number of open source projects to work properly:

- [AngularJS 8.2] - HTML enhanced for web apps
- [Visual Studio 2019] - project editor
- [Bootstrap 4.6] - UI boilerplate for modern web apps
- [.NET Core 3.1] - LTS version for the backend API
- [Entity Framework Core 5] - object-relational mapper
- [Microsoft SQL Server Express 14] - database


## Installation

Create database with name "stf" from files located in the repo.
```sh
exec sp_attach_db 'stf', 'C:\Program Files\Microsoft SQL Server\<your instance>\MSSQL\DATA\Database.mdf', 'C:\Program Files\Microsoft SQL Server\<your instance>\MSSQL\DATA\Database_log.ldf'
```
Install the dependencies and devDependencies for the front-end be runned properly.

```sh
cd \customer-management\ManagementCustomer\ManagementCustomer\ClientApp
npm i
```
Then open Project Solution to run the environment.

<img src="https://raw.githubusercontent.com/saulocorrea/customer-management/master/run.jpg">

## URL Address
https://localhost:5001/

# Employee Management CRUD API (.NET 8)

This is a simple **Employee Management Web API** built using **.NET 8** and **Dapper** to perform CRUD operations.

## 🚀 Technologies Used
- ASP.NET Core Web API (.NET 8)
- Dapper (Micro ORM)
- Microsoft.Data.SqlClient
- SQL Server
- Swagger UI

## 📌 Features
- Get all employees
- Get employee by ID
- Create new employee
- Update existing employee
- Delete employee
- Clean layered architecture (Controller, Service, Repository)

## 🧪 API Testing
All endpoints are tested and documented using **Swagger UI**.

## 🗂 Database
```sql
CREATE TABLE Employee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100),
    Department VARCHAR(200)
);

Linkedin: https://www.linkedin.com/in/mohammad-usman-buriro/

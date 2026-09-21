# ASP.NET Core Database First CRUD, Stored Procedure & ViewComponent

An ASP.NET Core MVC practice project demonstrating **Database-First development, Stored Procedures, CRUD operations, ViewComponents, and Aggregate Views** using SQL Server.

## 📌 Project Overview

This project demonstrates several important ASP.NET Core MVC and SQL Server development techniques using an existing database.

The main concepts covered in this project are:

* Database-First Development
* Entity Framework Core
* Stored Procedures
* CRUD Operations
* ViewComponents
* Aggregate Views
* SQL Server
* Razor Views
* ASP.NET Core MVC

## 🚀 Features

* Database-First approach
* SQL Server integration
* Entity Framework Core
* Stored Procedure integration
* Create, Read, Update and Delete operations
* ViewComponents
* Aggregate Views
* Razor Views
* Model Binding
* Server-side data processing
* Reusable UI components

## 🗄️ Database-First

The application follows the **Database-First** approach.

The database structure is created first and the ASP.NET Core application works with the existing database objects such as:

* Tables
* Relationships
* Stored Procedures
* Queries

## 🔄 CRUD Operations

The project demonstrates the complete CRUD workflow:

```text id="x7g5uk"
Create
  ↓
Read
  ↓
Update
  ↓
Delete
```

| Operation | Purpose                 |
| --------- | ----------------------- |
| Create    | Add new records         |
| Read      | Display records         |
| Update    | Modify existing records |
| Delete    | Remove records          |

## ⚙️ Stored Procedures

The application demonstrates using **SQL Server Stored Procedures** from the ASP.NET Core application.

Stored Procedures can be used for operations such as:

```text id="k4j9br"
Insert
Select
Update
Delete
Aggregate / Summary Queries
```

This demonstrates how application logic can communicate with database-level Stored Procedures.

## 🧩 ViewComponents

The project demonstrates **ASP.NET Core ViewComponents** for creating reusable UI components with server-side logic.

A ViewComponent can:

1. Receive a request from a Razor View
2. Execute server-side logic
3. Retrieve data
4. Return a partial UI representation

Example:

```text id="7h3x8w"
Razor View
    │
    ▼
ViewComponent
    │
    ├── Query Data
    │
    ├── Process Data
    │
    └── Return View
```

## 📊 Aggregate View

The project also demonstrates an **Aggregate View** for presenting summarized or combined information.

Instead of displaying only individual database records, an Aggregate View can display calculated or grouped information such as:

* Total records
* Total sales
* Total quantity
* Sum
* Average
* Count
* Grouped data
* Summary information

Example:

```text id="k2u6z9"
Database Records
       │
       ▼
Aggregate Query
       │
       ├── Count
       ├── Sum
       ├── Average
       └── Group By
       │
       ▼
Aggregate View
       │
       ▼
Summary / Dashboard
```

## 🏗️ Application Architecture

```text id="u5ezn4"
User
 │
 ▼
ASP.NET Core MVC
 │
 ├── Controllers
 │
 ├── Models / ViewModels
 │
 ├── ViewComponents
 │
 └── Razor Views
        │
        ▼
 Entity Framework Core
        │
        ▼
    SQL Server
        │
        ├── Tables
        ├── Stored Procedures
        └── Aggregate Queries
```

## 🛠️ Technologies Used

* C#
* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* Stored Procedures
* ViewComponents
* Aggregate Queries / Views
* Razor
* HTML
* CSS
* Bootstrap

## 🎯 Learning Objectives

This project was created to practice:

* ASP.NET Core MVC
* Database-First development
* Entity Framework Core
* SQL Server
* Stored Procedures
* CRUD operations
* ViewComponents
* Aggregate Views
* Aggregate queries
* Razor Views
* Model Binding
* Database integration

## ▶️ Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/AspNetCoreDatabaseFirstCRUDStoredProcedureViewComponent.git
```

### 2. Open the Project

Open the solution in Visual Studio.

### 3. Configure SQL Server

Update the connection string in:

```text
appsettings.json
```

according to your local SQL Server configuration.

### 4. Configure Database Objects

Make sure the required:

* Database
* Tables
* Stored Procedures
* Relationships

are available in SQL Server.

### 5. Run the Application

Run the project from Visual Studio or:

```bash
dotnet run
```

## ⚠️ Security Note

Do not commit real database passwords, API keys, connection strings containing credentials, or other sensitive information to a public GitHub repository.

## 👨‍💻 Author

**MD. KAYUM HOSSAIN**

# Inventory Management API

A backend Inventory Management System built using **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**.  
This project demonstrates real-world backend concepts such as product management, stock tracking, validation, and RESTful API design.

---

## 🚀 Features

- Product management (Create & View)
- Stock In and Stock Out operations
- Prevents negative stock
- Stock summary for all products
- Stock summary for a single product
- Stock movement history (IN / OUT log)
- Swagger API documentation
- SQL Server database with EF Core migrations

---

## 🛠 Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server Express
- Swagger (OpenAPI)
- .NET 9.0

---

## ✅ Prerequisites

- .NET SDK 9.0
- SQL Server Express
- SQL Server Management Studio (optional)

---

## ▶️  How to Run

1. Clone the repository 
```bash
git clone https://github.com/your-username/InventoryManagement.API.git
```
2. Navigate to the project folder
3. Run the application
4. Open Swagger in browser
```bash
https://localhost:xxxx/swagger
```
(The port will be shown in the terminal)

---

## 🗄 Database

Database is created automatically on first run
Name: InventoryDB

---

## 🔗 API Endpoints

POST /api/Products
GET /api/Products
POST /api/Stock/in
POST /api/Stock/out
GET /api/Stock/summary
GET /api/Stock/summary/{productId}
GET /api/Stock/history/{productId}

---

## 🧪 Testing

All endpoints can be tested using Swagger UI without a frontend application.

# TemplarTaskManager API ⚔️

Simple .NET 8 Core Web API for managing tasks.
Built as a training project for backend development concepts (CRUD, Entity Framework, SQLite).

## 🚀 Features
- **Create** new tasks
- **Read** all tasks or specific task by ID
- **Update** existing tasks (status & description)
- **Delete** unwanted tasks
- **Persistence:** Uses SQLite database with Entity Framework Core

## 🛠️ Tech Stack
- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core (SQLite)
- Swagger UI (for testing)

## 📦 How to run
1. Clone the repository
2. Open in Visual Studio 2022
3. Run `Update-Database` in Package Manager Console (to create local DB file)
4. Press `F5` to start the server
5. Test endpoints via Swagger UI at `https://localhost:xxxx/swagger`

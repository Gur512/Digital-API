# Digital-QueueAPI

## Description
This is a **Web API** developed using ASP.NET Core. It provides full CRUD functionality for four main entities and follows RESTful principles. The project implements Data Transfer Objects (DTOs), AutoMapper for mapping between models, and supports proper validation and error handling.

---


##  Project Structure
```
Digital-queueAPI/
│
├── Controllers/           # API endpoints
├── BLL/                   # Services (business logic)
├── DAL/                   # Repositories + DbContext
├── Models/                # Entities and enums
├── DTOs/                  # Data Transfer Objects (UserDto, NotificationDto, etc.)
├── Migrations/            # EF Core migrations
├── Program.cs             # App configuration
├── appsettings.json       # Database connection
├── README.md              # This file
```

---


## Setup Instructions

### Prerequisites
- .NET SDK (6.0 or later)
- Visual Studio 2022 or later
- SQL Server (or LocalDB)

### Steps to Run

- 1. **Clone the repository**  
   ```bash
   git clone https://github.com/Gur512/Digital-API.git

- 2. **Open the project in Visual Studio**
     Open the .sln file.

- 3. Set up the database
     Update your connection string in appsettings.json.

- 4. Apply migrations (if using EF Core Code First)
     dotnet ef database update

- 5. Run the project
     Press F5 or use:
     dotnet run

- 6. Swagger UI
     Navigate to https://localhost:<port>/swagger to view and test API endpoints.


## API Usage
- Common Endpoints
- GET     /api/User           → Get all entries
- GET     /api/User/{id}      → Get entry by ID
- POST    /api/User           → Create a new entry
- PUT     /api/User/{id}      → Update an existing entry
- DELETE  /api/User/{id}      → Delete an entry


## Features

-  12–15 total endpoints across 4 entities
-  Follows RESTful conventions and naming
-  Entity-specific validation using data annotations
-  DTOs to prevent over-posting and data leakage
-  AutoMapper for model <-> DTO translation
-  Centralized error handling using status codes and messages
-  Async/await usage for non-blocking performance
-  Swagger UI for interactive testing/documentation
-  Clean, scalable folder structure

---

## Technologies Used

- ASP.NET Core 6
- Entity Framework Core
- SQL Server / LocalDB
- AutoMapper
- Data Transfer Objects (DTOs)
- Swagger / OpenAPI
- C#
- Visual Studio 2022

---

## Testing the API
- You can test the API using:
- Swagger UI (built-in)

---

## License
- This project is licensed under the MITT License.


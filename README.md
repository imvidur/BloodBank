# BloodBank Management System

A web application for managing blood donations in a blood bank. This API allows users to add, update, delete, search, and paginate blood donations. The project uses ASP.NET Core Web API for the backend and serves as a simple system for tracking blood donations, donors, and their status.

## Features
- **CRUD Operations**: Create, Read, Update, and Delete blood bank entries.
- **Pagination**: Fetch blood bank entries with pagination support.
- **Search**: Search for blood donations based on blood type.
- **Status Management**: Track the status of donations (Available, Expired, Rejected).

## Technologies Used
- **ASP.NET Core**: Backend framework
- **C#**: Programming language
- **Swagger UI**: API documentation and testing interface
- **JSON**: Data format for communication

## Getting Started

### Prerequisites
To run the project locally, make sure you have the following installed:

- .NET 6 or later (for ASP.NET Core)
- Visual Studio or Visual Studio Code
- Git (for version control)

### Installation

1. **Clone the repository:**
   Open a terminal and clone the repository using Git:
   ```bash
   git clone https://github.com/your-username/BloodBankManagement.git
   cd BloodBankManagement

 2. **Install dependencies:**
   If you’re using Visual Studio, open the solution file (BloodBankManagement.sln) and restore the packages.
   Alternatively, use the .NET CLI to restore packages:
    ```bash
    dotnet restore


3. **Run the project:**
   To run the project locally:
    ```bash
  dotnet run

### Testing the API with Swagger UI
  Once the project is running, open your browser and navigate to:
    ```bash
  https://localhost:7261/swagger
  This will open Swagger UI, where you can view and test all the available API endpoints directly.


### ENDPOINTS
1. **GET /api/bloodbank**
   -**Description:** Get all blood bank entries.
   -**Response:** Returns a list of all blood bank entries.
    -**Example:**







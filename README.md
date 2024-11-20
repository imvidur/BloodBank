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
   - **Description:** Get all blood bank entries.

2. **GET /api/bloodbank/search/bloodtype**
   - **Description:** Search for blood donations by blood type.
   - **Query Parameter:** `bloodType` - The blood type to search for.

3. **POST /api/bloodbank**
   - **Description:** Add a new blood donation entry.
   - **Request Body:** A JSON object representing the blood donation.

4. **PUT /api/bloodbank/{id}**
   - **Description:** Update an existing blood donation entry.
   - **Request Body:** JSON object with updated data.

5. **DELETE /api/bloodbank/{id}**
   - **Description:** Delete a blood donation entry by ID.

6. **GET /api/bloodbank/paginate**
   - **Description:** Fetch paginated blood donation entries.
   - **Query Parameters:**
     - `page`: The page number (default is 1).
     - `size`: The number of entries per page (default is 10).

### Running the Tests
   To run tests for this project, you can use the built-in test framework.
   
   Run the following command:

   ```bash
   dotnet test


### Contributing
   **We welcome contributions! If you'd like to contribute, please follow these steps:**
   
   1. **Fork the repository.**
   2. **Create a new branch (git checkout -b feature-branch).**
   3. **Make your changes and commit them (git commit -am 'Add new feature').**
   4. **Push to the branch (git push origin feature-branch).**
   5. **Create a new pull request.**

### License
   **This project is licensed under the MIT License - see the LICENSE.md file for details.**






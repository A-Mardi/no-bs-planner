# NoBS Planner
## Project Overview
NoBS Planner is a full-stack web application designed to manage and organize tasks. Built using .NET Core (ASP.NET Core) for the backend and Razor Pages for the frontend, this project allows users to create, view, edit, and delete planner items.

## Features
- Create Planner Items: Add new tasks with details including title, description, due date, and completion status.
- View Planner Items: Display a list of tasks with options to view details.
- Edit Planner Items: Modify existing tasks.
- Delete Planner Items: Remove tasks from the planner.
## Tech Stack
- Frontend: Razor Pages with Bootstrap/Tailwind CSS for styling.
- Backend: .NET Core (ASP.NET Core) for API handling.
- Authentication: JWT for user authentication and authorization.
- Database: SQL Server using Entity Framework Core for data management.
- Version Control: GitHub for version control and repository hosting.
## Prerequisites
- Visual Studio 2022: For development.
- .NET Core 7.0+ SDK: For building and running the application.
- SQL Server: For database management.
## Setup Instructions
- Clone the Repository 
`git clone https://github.com/yourusername/NoBSPlanner.git`

- Install Dependencies Navigate to the project directory and restore the required packages.
`dotnet restore`

- Configure the Database Update the `appsettings.json` file with your database connection string.
  
- Apply Migrations
`dotnet ef database update`

- Run the Application
`dotnet run`

## Usage
- Navigate to the Planner Items Pages: Use the navigation links to access Create, View, Edit, and Delete pages.
- Add Items: Go to the Create page, fill out the form, and submit it to add a new task.
- View Items: Access the Index page to see a list of all tasks.
- Edit Items: Go to the Edit page, make changes, and save them.
- Delete Items: Access the Delete page and confirm the deletion of tasks.
<!--
## Deployment
Azure App Service
Publish to Azure: Right-click the project in Visual Studio, select Publish, and choose Azure.
Configure: Follow the prompts to set up an Azure App Service.
Deploy: Click Publish to deploy the application to Azure.
## Testing
- Add Functionality: Test adding tasks by navigating to the Create page, entering data, and submitting the form.
- Delete Functionality: Test deleting tasks by navigating to the Delete page and confirming the deletion. ] -->
  
## Troubleshooting
- Build Errors: Ensure all dependencies are installed and configurations are correct. Check the build output for detailed error messages.
- Database Issues: Verify your connection string and ensure the database is properly set up.
- Missing Files: Ensure all required .cshtml and .cshtml.cs files are present in the project.
## License
This project is licensed under the MIT License.

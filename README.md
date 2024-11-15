![Screenshot 2024-10-07 111743](https://github.com/user-attachments/assets/31e319b9-6494-4874-a469-0a1a12e1fcb1)

# No BS Planner
## Project Overview
No BS Planner is a full-stack web application designed to manage and organize tasks. this app allows users to create, view, edit, and delete tasks.

This project was initially implemented with .NET for the backend, SQL Server for data storage, and Razor Pages for the frontend, utilizing Docker for containerization and deployment via Doku.

It has since been rewritten to use .NET Core (ASP.NET Core) for the backend and React with vanilla CSS for the frontend. The application is now hosted on Azure, with an Azure SQL Database for cloud-based data storage.


## Features
- Create Planner Items: Add new tasks with details including title, description, due date, and completion status.
- View Planner Items: Display a list of tasks with options to view details.
- Edit Planner Items: Modify existing tasks.
- Delete Planner Items: Remove tasks from the planner.
## Tech Stack
- Frontend: React with vanilla CSS for styling a minimal and fuss free database.
- Backend: .NET Core (ASP.NET Core) & Entity Framework Core for a multi-layered data management and API handling backend.
- Database: Azure SQL database.
- Version Control: GitHub for version control and repository hosting.
- Hosting: Azure
## Prerequisites
- Visual Studio 2022: For development.
- .NET Core 7.0+ SDK: For building and running the application.
- Node.js: For managing dependencies and running the React frontend.
- Azure Account: For hosting the application and Azure SQL Database.
## Setup Instructions
- Clone the repository 
`git clone https://github.com/A-Mardi/no-bs-planner.git`

- Install dependencies Navigate to the project directory and restore the required packages.
`dotnet restore`

- Configure the database Update the `Connection String` with your Azure sql database connection string.

- Run the server application
`dotnet run`

- Frontend Build: If applicable, you might need to build the React frontend before running the application:

```
cd ClientApp

npm run build
```

- Environment Variables: Ensure any necessary environment variables are set, such as those for API keys and the Azure backend app service.

## Deployment
- Create Azure App Services for both the client app and the server app  
- Publish to Azure: Right-click the server app project in Visual Studio, select Publish, and choose Azure.
- Configure: Follow the prompts to set up an Azure App Service.
- Deploy: Click Publish to deploy the application to Azure.

## Usage

- Make sure to click on the backend hosted api ->> [No Bs Backend](https://nobsbackend-cpf0bea5bxamcqfs.canadacentral-01.azurewebsites.net/)

        due to free service limitations on Azure, the backend cannot be set to 'always on'.
- Visit the hosted frontend app ->> [No Bs Backend](https://calm-bush-08355fa0f.5.azurestaticapps.net/) for a bette user experience
- Navigate to the Tasks Pages: Use the navigation links to access Task list.
- Add Taks: fill out the form, and submit it to add a new task.
- View Tasks: Press Expand to see a list of all tasks.
- Edit Tasks: Press the Edit Button, make changes, and save them.
- Delete Tasks: Press the Delete button and confirm the deletion of tasks.

  
## Troubleshooting
- Build Errors: Ensure all dependencies are installed and configurations are correct. Check the build output for detailed error messages.
- Database Issues: Verify your connection string and ensure the database is properly set up.

## License
MIT License.

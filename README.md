Task – Fullstack Developer .NET 

## Made by RAISSI ZAKARIA

# Ticket Management System

This project is a Ticket Management System that allows users to manage tickets through a web interface. The application supports CRUD (Create, Read, Update, Delete) operations for managing tickets and includes additional features such as pagination, sorting, and filtering.



https://github.com/user-attachments/assets/5c905bcd-7254-4507-bbfe-e96f8907e48a



## Table of Contents

- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
  - [Backend Setup](#backend-setup)
  - [Frontend Setup](#frontend-setup)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Project Structure](#project-structure)

## Technologies Used

- **Backend**
  - .NET 8
  - Entity Framework
  - SQL Server
  - ASP.NET Core Web API

- **Frontend**
  - Angular 18
  - TypeScript
  - Tailwind CSS
  - ngx-toastr (Notification library)

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (version 18 or above)
- [Angular CLI](https://angular.io/cli) (for Angular projects) 
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) for the database


## Installation

### Backend Setup

1. Clone the repository:

   ```bash
   git clone  https://github.com/zakaria0101/Hahn-Task-Fullstack-Developer-.NET.git
2. Navigate to the backend directory:

   ```bash
   cd Hahn-Task\Back-End\Back-End
3. Configure the database connection in appsettings.json:

   Replace the Data source with your SQL server name and add your login credentials
   
   ```bash
   "ConnectionStrings": {
      "DefaultConnection": "Data Source=Zakaria-LT;Initial Catalog=hahn_database;Integrated Security=True;TrustServerCertificate=True;"
    },
4. Install dependencies:

   ```bash
   dotnet restore

5. Apply migrations to the database:

   ```bash
   dotnet ef database update

### Frontend Setup

1. Navigate to the frontend folder:

   ```bash
   cd ../frontend

2. Install dependencies:

   ```bash
   npm install

## Running the Application

### Backend 

1. Start the backend server:

   ```bash
   dotnet watch run

  The API will be available at **http://localhost:5096/api/ticket**.

### Frontend 

1. Start the frontend server:

   ```bash
   ng serve

  The frontend will be available at **http://localhost:4200**


## API Endpoints

- **GET `/api/ticket`**: Fetch paginated tickets.
  - *Params*: `pageNumber` (optional), `pageSize` (optional).
- **POST `/api/ticket`**: Create a new ticket.  
- **GET `/api/ticket/{id}`**: Fetch a ticket by ID.  
- **PUT `/api/ticket/{id}`**: Update a ticket by ID.  
- **DELETE `/api/ticket/{id}`**: Delete a ticket by ID.

## Project Structure

### Backend

![image](https://github.com/user-attachments/assets/73e6759f-db74-48a4-98ce-eda89a5726a2)

### Frontend

![image](https://github.com/user-attachments/assets/7aa71c71-0ff0-45a7-9ab5-384e197cb80d)

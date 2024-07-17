# .NET Onion Architecture Task Management System

This project is a comment management system developed using .NET Onion Architecture. This API allows users to manage comments on tasks within the system. Users can create, read, update, and delete comments, ensuring efficient collaboration and feedback on tasks. 

The project utilizes technologies such as **Entity Framework, CQRS, LINQ, DTO, MediatR, AutoMapper, FluentValidation, Global Handling Exception, JWT, Pipelines, Redis Cache, Serilog, Dynamic.LINQ, MailKit, and MimeKit.**

## Key Features:

- **Comment Management:** Users can add comments to tasks, edit existing comments, delete comments, and retrieve a list of comments. Additionally, comments can be filtered based on specific criteria to enhance usability.

- **Email Verification:** When users register, a verification code is sent to their email. Users are required to verify their accounts by entering this code, ensuring secure account management.

- **Authorization and Role System:** The system implements a robust authorization framework. Thanks to the role-based access control, users cannot delete or update resources they do not have permission for, ensuring data integrity and security.

## Project Architecture

### Layers

- **Core**: Contains core functionalities like pipelines, middleware, and other components that are not dependent on external services. These components can be easily reused in other projects.
- **Domain**: Contains the domain entities.
- **Application**: Implements business rules, uses the CQRS pattern, defines services, and contains abstract repositories.
- **Infrastructure**: Contains external dependencies like email services.
- **Persistence**: Contains data access layer and concrete repositories.
- **WebAPI**: Defines and exposes API endpoints.

## Technologies and Tools Used

### ORM and Data Access

- **Entity Framework Core**: ORM tool for data access.
- **MSSQL**: Database management system.

### Design Patterns and Architectures

- **Onion Architecture**: Layered architecture pattern.
- **CQRS**: Command Query Responsibility Segregation.
- **Repository Pattern**: Data access using repository pattern.
- **Dependency Injection**: Dependency injection for service management.

### Data Transfer and Mapping

- **DTO (Data Transfer Object)**: Data transfer objects.
- **AutoMapper**: Object-to-object mapping.

### MediatR

- **MediatR**: Implements CQRS pattern using MediatR library.

### Pipeline

- **Pipeline**: Pipeline behaviors for authorization, caching, logging, performance measurement and validation.

### Validation

- **FluentValidation**: Input validation for requests.

### Business Rules

- **Business Rules**: Separate business rules implemented for each entity.

### Caching

- **Redis**: Caching using Redis Cloud.
- **ICachableRequest and ICachableRemoverRequest**: Interfaces for caching operations.

### Logging

- **Serilog**: Logging using Serilog.
- **File and MSSQL Log**: Logs are saved both to file and MSSQL database.

### Exception Handling

- **Global Exception Handling**: Middleware for global exception handling.

### Security

- **JWT (JSON Web Token)**: For secure authentication and authorization mechanisms.
- **Password Hashing + Salting**: Hashing and salting for user passwords.

### Pagination and Performance

- **Pagination**: Pagination for all GetList methods.
- **Performance Measurement**: Simple mechanism for performance measurement in milliseconds.

### Email Verification

- **MailKit and MimeKit**: Email verification using MailKit and MimeKit libraries.

### Dynamic Filtering

- **Dynamic LINQ**: Enables dynamic query building using string expressions.

### User Role Management

- **OperationClaim**: Stores role names.
- **UserOperationClaim**: Assigns roles to users.

### Additional Features

- **User Management**: Efficient management of user information.
- **Roles**: Role-based access control and management.
- **Logging**: Detailed logging for monitoring and troubleshooting.
- **Caching**: Enhanced performance through caching mechanisms.
- **Performance Measurement**: Tools for measuring and optimizing application performance.
- **Email Verification**: Users verify email to activate accounts.

## API Endpoint Overview

This project utilizes the following API endpoints for interaction with various resources:

- **Assignment:** POST (Create), PUT (Update), DELETE (Remove), GET by ID (Retrieve details), GET list (List all), GET list dynamic (Filter).
- **Comment:** POST (Create), PUT (Update), DELETE (Remove), GET by ID (Retrieve details), GET list (List all), GET list dynamic (Filter).
- **Auth:** POST (Login), POST (Register), PUT (Change password).
- **RegisterWithEmail:** POST (Register), POST (Verify email), POST (Login).
- **OperationClaim:** POST (Create), PUT (Update), DELETE (Remove), GET by ID (Retrieve details), GET list (List all).
- **UserOperationClaim:** POST (Create), PUT (Update), DELETE (Remove), GET by ID (Retrieve details), GET list (List all).
- **User:** POST (Create), PUT (Update), DELETE (Remove), GET by ID (Retrieve details), GET list (List all).

Each endpoint is designed in accordance with RESTful principles to support the core functionality of the project.

## Installation and Running the Project

### Prerequisites

- .NET 8 SDK
- MSSQL Server
- Redis Cloud account
- SMTP (for email service)

### Steps

1. Clone the Repository

```
git clone this repository
cd <your-repository-directory>
```

2. Install Dependencies

```
dotnet restore
```

3. Configure Connection Strings

```
Update the appsettings.json file with your database connection strings (and look BaseDbContext in Persistence Layer), Redis configuration and email configuration
```

4. Run Migrations

Tools -> NuGet Package Manager -> Package Manager Console

```
Add-Migration MigrationName
Update-Database
```

**Note:** After running the migrations, your database will be populated with seed data, ensuring that you have initial data available for use.

5. Run the Application

```
dotnet run
```

### Testing the API

You can use tools like Postman or curl to test the API endpoints once the application is running. Additionally, Swagger is already set up in this project, allowing you to directly explore and test the API endpoints through its interactive interface.

## Contribution

If you would like to contribute to this project, please open an issue first to discuss what you would like to change.

## Screenshots

<img src="./imgs/1.png" width="900" height="650">

--------------------------------------------------------------------

<img src="./imgs/2.png" width="900" height="600">

--------------------------------------------------------------------

<img src="./imgs/3.png" width="900" height="500">

--------------------------------------------------------------------

<img src="./imgs/4.png" width="900" height="650">

--------------------------------------------------------------------

<img src="./imgs/5.png" width="700" height="500">

--------------------------------------------------------------------

<img src="./imgs/6.png" width="600" height="350">

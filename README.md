# BlazorCalendar

BlazorCalendar is a full-stack Blazor application showcasing the implementation of Domain-Driven Design (DDD), Command Query Responsibility Segregation (CQRS), utilizing MongoDB for data storage, and leveraging WebAssembly for client-side execution.

## Features

- **Domain-Driven Design (DDD)**: Follows the principles of DDD for a well-structured domain model.
- **CQRS (Command Query Responsibility Segregation)**: Separates reads and writes to optimize the application's performance and scalability.
- **MongoDB**: Utilizes MongoDB as the database for storing application data.
- **WebAssembly**: Employs WebAssembly for executing .NET code on the client-side, enabling rich and interactive user interfaces.
- [Add more features here]

## Installation

To run this project locally, make sure you have the following prerequisites installed:

- .NET 8 SDK or later
- MongoDB installed and running locally or or deployed in a Docker container

Follow these steps to get started:

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/BlazorCalendar.git
   dotnet restore
   dotnet build
   dotnet run

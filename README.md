# Car Information System API

This project is a demonstration of backend development skills using .NET. The Car Information System API is designed to manage cars and companies, showcasing modern software development practices and clean architecture principles.

## Purpose

The goal of this project is to demonstrate:

- **Clean architecture principles** like Vertical Slice Architecture.
- **Advanced patterns** such as CQRS, Unit of Work, and Dependency Injection.
- **Lightweight endpoint design** with Minimal APIs.

This is a foundational project with plans for future improvements like authentication, microservices, and a frontend built with Angular.

---

## Features

### CRUD Operations
- Full create, update, delete, and retrieve functionality for cars and companies.

### Vertical Slice Architecture
- Organized by features, with each feature handling its own commands, queries, handlers, models, and repositories.

### CQRS
- **Commands** handle data-modifying operations (e.g., creating or updating entities).
- **Queries** handle data retrieval operations (e.g., fetching by ID or getting all records).

### Unit of Work
- Centralized transaction management ensures repository operations are consistent within a single request.

### Dependency Injection
- Core services such as repositories, unit of work, and MediatR are injected to ensure loose coupling and modularity.

### Entity Framework Core
- Manages database interactions using an in-memory database for development and testing.

### Minimal APIs
- Simplified and expressive endpoint definitions with reduced boilerplate code.

### DTOs (Data Transfer Objects)
- Securely shape API responses, ensuring internal models are not overexposed.

### Swagger Integration
- Automatically generated API documentation for easy testing and exploration.

---

## Project Structure

The project is divided by features, using a vertical slice approach. Each feature (e.g., Car and Company) includes:

- **Commands** for data-modifying operations.
- **Queries** for data retrieval.
- **Handlers** to process the commands and queries.
- **DTOs** to format API responses.
- **Models and Repositories** for database interaction.

---

## Future Enhancements

- Add authentication and authorization using JWT.
- Build a user interface with Angular.
- Refactor into microservices for scalability.
- Add comprehensive unit and integration tests.

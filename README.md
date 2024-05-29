# FlightBookingSystem

## Overview

FlightBookingSystem is a Single Page Application (SPA) designed to facilitate flight bookings. The application uses Angular for the client side and ASP.NET Core for the backend API. The project includes functionalities such as searching for flights, viewing flight details, and booking flights.

## Features

- **Search Flights**: Users can search for flights based on source, destination, dates, and number of passengers.
- **View Flight Details**: Detailed information about selected flights.
- **Book Flights**: Users can book flights by providing necessary booking details.

## Technologies

- **Frontend**: Angular
- **Backend**: ASP.NET Core
- **Database**: SQL (configured with Entity Framework Core)

## Prerequisites

- Node.js and npm
- .NET SDK
- SQL Server

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/patino-davian/FlightBookingSystem.git
cd FlightBookingSystem
```

### Backend Setup

1. **Navigate to the backend directory**:
    ```bash
    cd FlightBookingSystem/Backend
    ```

2. **Restore NuGet packages**:
    ```bash
    dotnet restore
    ```

3. **Update Database**:
    Ensure your SQL Server is running and update the connection string in `appsettings.json` if necessary. Then run:
    ```bash
    dotnet ef database update
    ```

4. **Run the application**:
    ```bash
    dotnet run
    ```

### Frontend Setup

1. **Navigate to the frontend directory**:
    ```bash
    cd FlightBookingSystem/Frontend
    ```

2. **Install npm packages**:
    ```bash
    npm install
    ```

3. **Generate API services**:
    If you make changes to the API, regenerate Angular services using:
    ```bash
    npx ng-openapi-gen
    ```

4. **Run the application**:
    ```bash
    ng serve
    ```

5. **Open your browser** and navigate to `http://localhost:4200`.

## Project Structure

### Backend

- **Controllers**: Defines API endpoints (e.g., `FlightController.cs`).
- **Entities**: Defines database entities and context (e.g., `Flight.cs`, `Entities.cs`).
- **DataTransferObjs**: DTOs for data transfer between client and server.
- **ReadModels**: Models for reading data from the database.

### Frontend

- **Components**: Angular components (e.g., `SearchFlightsComponent`).
- **Services**: Angular services for API calls (e.g., `FlightService`).
- **Models**: Data models for the application.

## Usage

### Search Flights

1. Navigate to the search flights page.
2. Enter search criteria (source, destination, dates, number of passengers).
3. Click the search button to view available flights.

### Book Flights

1. Select a flight from the search results.
2. Enter booking details (passenger email, number of seats).
3. Click the book button to complete the booking.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes and commit (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a pull request.

## License

This project is licensed under the MIT License.

## Contact

For any inquiries, please reach out to patinodavian@gmail.com

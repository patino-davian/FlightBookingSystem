FlightBookingSystem
Overview:

FlightBookingSystem is a Single Page Application (SPA) designed to facilitate flight bookings. The application uses Angular for the client side and ASP.NET Core for the backend API. The project includes functionalities such as searching for flights, viewing flight details, and booking flights.

Features:

Search Flights: Users can search for flights based on source, destination, dates, and number of passengers.
View Flight Details: Detailed information about selected flights.
Book Flights: Users can book flights by providing necessary booking details.

Technologies
Frontend: Angular
Backend: ASP.NET Core
Database: SQL (configured with Entity Framework Core)

Prerequisites
Node.js and npm
.NET SDK
SQL Server

Getting Started

Clone the Repository:

git clone https://github.com/patino-davian/FlightBookingSystem.git
cd FlightBookingSystem

Backend Setup:

Navigate to the backend directory:
cd FlightBookingSystem/Backend

Restore NuGet packages:
dotnet restore

Update Database:

Ensure your SQL Server is running and update the connection string in appsettings.json if necessary. Then run:
dotnet ef database update

Run the application:
dotnet run
Frontend Setup

Navigate to the frontend directory:
cd FlightBookingSystem/ClientApp

Install npm packages:
npm install -packagename

Generate API services:
If you make changes to the API, regenerate Angular services using:
npx ng-openapi-gen

Project Structure
Backend
Controllers: Defines API endpoints (e.g., FlightController.cs).
Entities: Defines database entities and context (e.g., Flight.cs, Entities.cs).
DataTransferObjs: DTOs for data transfer between client and server.
ReadModels: Models for reading data from the database.
Frontend
Components: Angular components (e.g., SearchFlightsComponent).
Services: Angular services for API calls (e.g., FlightService).
Models: Data models for the application.
Usage
Search Flights
Navigate to the search flights page.
Enter search criteria (source, destination, dates, number of passengers).
Click the search button to view available flights.
Book Flights
Select a flight from the search results.
Enter booking details (passenger email, number of seats).
Click the book button to complete the booking.
Contributing
Fork the repository.
Create a new branch (git checkout -b feature-branch).
Make your changes and commit (git commit -m 'Add new feature').
Push to the branch (git push origin feature-branch).
Create a pull request.
License
This project is licensed under the MIT License.

Contact
For any inquiries, please reach out to patinodavian@gmail.com

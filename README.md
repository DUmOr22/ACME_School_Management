# ACME School Management

## Overview
The ACME School Management project is designed to facilitate the management of courses and students within the ACME School. This application allows for the registration of adult students, the creation of courses, and the enrollment of students in those courses after payment of the enrollment fee.

## Project Structure
The project is organized into three main layers: Core, Domain, and Infrastructure.

- **Core**: Contains interfaces that define the services for managing students and courses.
- **Domain**: Contains the models for students and courses, including their properties and methods.
- **Infrastructure**: Implements the service interfaces, providing the functionality to manage students and courses.

### Directory Layout
```
src/
    ACME.SchoolManagement.Core/
        ACME.SchoolManagement.Core.csproj
        Interfaces/
    ACME.SchoolManagement.Domain/
        ACME.SchoolManagement.Domain.csproj
        Models/
    ACME.SchoolManagement.Infrastructure/
        ACME.SchoolManagement.Infrastructure.csproj
        Services/
    ACME.SchoolManagement.sln
tests/
    ACME.SchoolManagement.Tests/
        ACME.SchoolManagement.Tests.csproj
        Services/
```

## Features
- Register a student by specifying their name and age (only adults can be registered).
- Register a course with a name, enrollment fee, start date, and end date.
- Enroll a student in a course after payment of the enrollment fee.
- Retrieve a list of courses and their enrolled students within a specified date range.

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd ACME-School-Management
   ```
3. Open the solution in your preferred IDE.
4. Restore the NuGet packages:
   ```
   dotnet restore
   ```
5. Build the solution:
   ```
   dotnet build
   ```

## Running Tests
To run the unit tests, navigate to the test project directory and execute:
```
dotnet test
```

## Future Enhancements
This project is designed with extensibility in mind. Future enhancements may include:
- Exposing the functionality as a web API.
- Implementing a database for persistent storage of students and courses.
- Integrating a payment gateway for processing enrollment fees.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.
# ACME School Management

## Overview / Descripción General
The ACME School Management project is designed to facilitate the management of courses and students within the ACME School. This application allows for the registration of adult students, the creation of courses, and the enrollment of students in those courses after payment of the enrollment fee.

El proyecto de Gestión Escolar de ACME está diseñado para facilitar la gestión de cursos y estudiantes dentro de la Escuela ACME. Esta aplicación permite el registro de estudiantes adultos, la creación de cursos y la inscripción de estudiantes en esos cursos después del pago de la tarifa de inscripción.

## Project Structure / Estructura del Proyecto
The project is organized into three main layers: Core, Domain, and Infrastructure.

El proyecto está organizado en tres capas principales: Core, Domain e Infrastructure.

- **Core**: Contains interfaces that define the services for managing students and courses. / Contiene interfaces que definen los servicios para gestionar estudiantes y cursos.
- **Domain**: Contains the models for students and courses, including their properties and methods. / Contiene los modelos para estudiantes y cursos, incluidas sus propiedades y métodos.
- **Infrastructure**: Implements the service interfaces, providing the functionality to manage students and courses. / Implementa las interfaces de servicio, proporcionando la funcionalidad para gestionar estudiantes y cursos.

### Directory Layout / Estructura de Directorios
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

## Features / Características
- 📋 Register a student by specifying their name and age (only adults can be registered). / Registrar un estudiante especificando su nombre y edad (solo se pueden registrar adultos).
- 📚 Register a course with a name, enrollment fee, start date, and end date. / Registrar un curso con un nombre, tarifa de inscripción, fecha de inicio y fecha de finalización.
- 📝 Enroll a student in a course after payment of the enrollment fee. / Inscribir a un estudiante en un curso después del pago de la tarifa de inscripción.
- 📅 Retrieve a list of courses and their enrolled students within a specified date range. / Recuperar una lista de cursos y sus estudiantes inscritos dentro de un rango de fechas especificado.

## Setup Instructions / Instrucciones de Configuración
1. Clone the repository: / Clona el repositorio:
   ```
   git clone https://github.com/DUmOr22/ACME_School_Management
   ```
2. Navigate to the project directory: / Navega al directorio del proyecto:
   ```
   cd ACME-School-Management
   ```
3. Open the solution in your preferred IDE. / Abre la solución en tu IDE preferido.
4. Restore the NuGet packages: / Restaura los paquetes NuGet:
   ```
   dotnet restore
   ```
5. Build the solution: / Construye la solución:
   ```
   dotnet build
   ```

## Running Tests / Ejecutando Pruebas
To run the unit tests, navigate to the test project directory and execute: / Para ejecutar las pruebas unitarias, navega al directorio del proyecto de pruebas y ejecuta:
```
dotnet test
```


## Future Enhancements / Mejoras Futuras
This project is designed with extensibility in mind. Future enhancements may include: / Este proyecto está diseñado con la extensibilidad en mente. Las mejoras futuras pueden incluir:
- 🌐 Exposing the functionality as a web API. / Exponer la funcionalidad como una API web.
- 🗄️ Implementing a database for persistent storage of students and courses. / Implementar una base de datos para el almacenamiento persistente de estudiantes y cursos.
- 💳 Integrating a payment gateway for processing enrollment fees. / Integrar una pasarela de pagos para procesar las tarifas de inscripción.

## License / Licencia
This project is licensed under the MIT License. See the LICENSE file for more details. / Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.

# Questions / Preguntas

> ## Why did you do things this way and any other considerations you think are appropriate? / ¿El por qué de las cosas y cualquier otra consideración que consideres apropiada?

### Project Description in .Net8 with C# / Descripción del Proyecto en .Net8 con C#
This project has been developed using .Net8 with C#. The implemented architecture is a layered architecture, which is used to divide the code into different layers, each with specific defined responsibilities. This approach favors code maintainability and scalability.

Este proyecto ha sido desarrollado utilizando .Net8 con C#. La arquitectura implementada es una arquitectura de capas (Layered Architecture), la cual se emplea para dividir el código en diferentes capas, cada una con responsabilidades específicas definidas. Este enfoque favorece la mantenibilidad y escalabilidad del código.

### Architecture Objectives / Objetivos de la Arquitectura:
- 🛠️ Maintainability: Facilitates updating and modifying the code without affecting other layers. / Mantenibilidad: Facilita la actualización y modificación del código sin afectar otras capas.
- 📈 Scalability: Allows adding new functionalities without compromising the existing structure. / Escalabilidad: Permite agregar nuevas funcionalidades sin comprometer la estructura existente.

### Additional Considerations / Consideraciones Adicionales:
- 🖥️ Presentation Layer: A presentation layer can be added to improve user interaction. / Capa de Presentación: Se puede añadir una capa de presentación para mejorar la interacción con el usuario.
- 💳 Payment Gateway: There is the possibility of integrating a payment gateway for courses. / Pasarela de Pagos: Existe la posibilidad de integrar una pasarela de pagos para los cursos.

### Project Openings / Aperturas del Proyecto:
- 🌐 API Creation: The architecture is prepared for the creation of an API that exposes the functionality as a service. / Creación de API: La arquitectura está preparada para la creación de una API que exponga el funcionamiento como servicio.
- 🗄️ Database Connection: It is possible to connect to databases using ORM models, SQL, or NoSQL. / Conexión con Bases de Datos: Es posible conectar con bases de datos utilizando modelos ORM, SQL o NoSQL.

> ## What things did you want to do but didn't do? / ¿Qué cosas habrías querido hacer pero no hiciste?

- I wanted to implement an authentication system using JWT (JSON Web Token) with expiration for security reasons. Additionally, I wanted to develop a user permissions management system, allowing roles to be identified and divided, and assigning these roles to users who possess the token. Additionally, I would have liked to integrate a payment gateway as an independent asynchronous service to manage payments. Although it was not necessary for the PoC, I would also have liked to use asynchronous methods to improve the efficiency and scalability of the system.

- Quería implementar un sistema de autenticación utilizando JWT (JSON Web Token) con expiración por motivos de seguridad. Además, quería desarrollar una gestión de permisos para los usuarios, permitiendo identificar y dividir roles, y asignar estos roles a los usuarios que posean el token. Adicionalmente, me hubiera gustado integrar una pasarela de pagos como un servicio asincrónico independiente para gestionar los pagos. Aunque para el PoC no era necesario, también me hubiera gustado utilizar métodos asincrónicos para mejorar la eficiencia y la escalabilidad del sistema.

> ## What things did you do but think could be improved or would need to be revisited if the project progresses? / ¿Qué cosas hiciste pero crees que podrían mejorarse o sería necesario volver a ellas si el proyecto avanza?

- 🧪 **Unit Tests**: The current unit tests could be expanded to cover more test cases and ensure greater code coverage. Additionally, integration tests could be implemented to verify the interaction between different components of the system. / Pruebas Unitarias: Las pruebas unitarias actuales podrían ampliarse para cubrir más casos de prueba y asegurar una mayor cobertura del código. Además, se podrían implementar pruebas de integración para verificar la interacción entre diferentes componentes del sistema.

- ⚠️ **Error Handling**: Error handling could be improved to provide more detailed and specific error messages, which would facilitate debugging and improve the user experience. / Manejo de Errores: El manejo de errores podría mejorarse para proporcionar mensajes de error más detallados y específicos, lo que facilitaría la depuración y mejoraría la experiencia del usuario.

- 🚀 **Performance Optimization**: Queries and data access operations could be reviewed and optimized to improve the overall performance of the system, especially when working with large volumes of data. / Optimización del Rendimiento: Se podrían revisar y optimizar las consultas y operaciones de acceso a datos para mejorar el rendimiento general del sistema, especialmente cuando se trabaja con grandes volúmenes de datos.

- 🔄 **Asynchrony**: Implement asynchronous methods to improve the efficiency and scalability of the system, especially in operations that can be blocking or require significant wait time. / Asincronía: Implementar métodos asincrónicos para mejorar la eficiencia y la escalabilidad del sistema, especialmente en operaciones que pueden ser bloqueantes o que requieren tiempo de espera significativo.

> ## What third-party libraries have you used? and why? / ¿Qué bibliotecas de terceros has usado? y ¿por qué?

The additional libraries I used are: / Las bibliotecas adicionales que utilicé son:
 - Microsoft.NET.Test.Sdk
 - xunit
 - Moq

They were necessary for running the tests and correctly visualizing the results, making test doubles using Moq as a mock. No additional libraries were needed for the PoC objective.

Fueron necesarias para la ejecución de las pruebas, y visualizar correctamente los resultados, haciendo dobles de prueba usando Moq como simulacro. No fueron necesarias bibliotecas adicionales para el objetivo del PoC.

> ## How much time have you spent on the project and what things did you have to research and what things were new to you? / ¿Cuánto tiempo has invertido en hacer el proyecto y qué cosas has tenido que investigar y qué cosas eran nuevas para ti?

I have dedicated approximately six hours to the project. During this time, I conducted detailed research on the Moq library, which proved to be highly effective for creating mock objects used in the tests.

He dedicado aproximadamente seis horas a la realización del proyecto. Durante este tiempo, realicé una investigación detallada sobre la librería Moq, lo cual resultó ser altamente efectivo para la creación de objetos simulados (dummies) utilizados en las pruebas.

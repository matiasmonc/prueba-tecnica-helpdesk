# Helpdesk - Backend

Resumen
Aplicación backend para un sistema de helpdesk implementada en .NET 8. Este repositorio contiene la solución backend organizada en capas (N capas) para separar responsabilidades y facilitar mantenimiento y pruebas.

Estructura y arquitectura
- Arquitectura: N capas (separación por responsabilidades).
- Proyectos principales:
  - backend/Helpdesk (API Web - capa de presentación)
  - backend/Helpdesk.Business (lógica de negocio / servicios)
  - backend/Helpdesk.Infraestructure (acceso a datos / EF Core)
  - backend/Helpdesk.Domain (entidades e interfaces de dominio)

Patrones de diseño y prácticas utilizadas
- Inyección de dependencias (DI) con el contenedor de ASP.NET Core.
- Repository Pattern: repositorios genéricos y específicos (IGenericRepository<>, TicketRepository, etc.).
- Service Layer: servicios que encapsulan la lógica de negocio (ITicketService/TicketService).
- AutoMapper para mapeo entre entidades y DTOs.
- Entity Framework Core como ORM con DbContext (AppDbContext).
- Uso de Swagger (Swashbuckle) en entorno de desarrollo para documentar/explorar la API.

Dependencias y versiones
- .NET Target Framework: net8.0
- Microsoft.EntityFrameworkCore.SqlServer: 8.0.27
- Microsoft.EntityFrameworkCore.Tools: 8.0.27
- AutoMapper: 16.1.1
- Swashbuckle.AspNetCore: 6.6.2

Requisitos del entorno
- .NET 8 SDK
- SQL Server (o instancia compatible) para la base de datos
- Visual Studio 2026 (recomendado) o Visual Studio Code

Configuración importante
- Cadena de conexión: configurar la clave "DefaultConnection" en appsettings.json o en los secretos del proyecto. Ejemplo:

  "ConnectionStrings": {
	"DefaultConnection": "Server=localhost;Database=HelpdeskDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }

- CORS: por defecto la API permite peticiones desde http://localhost:5173; ajustar si el frontend usa otro origen.

Flujo general del funcionamiento
- Los controladores del proyecto Helpdesk exponen endpoints REST.
- Los controladores delegan a servicios en Helpdesk.Business que contienen la lógica de negocio.
- Los servicios usan repositorios implementados en Helpdesk.Infraestructure para acceder a la base de datos mediante EF Core.
- AutoMapper realiza los mapeos entre modelos/entidades y DTOs empleados por la API.

Pasos para ejecutar el proyecto (línea de comandos)
1. Abrir una terminal en la raíz del repositorio.
2. Restaurar paquetes: dotnet restore
3. (Opcional) Aplicar migraciones/crear base de datos:
   dotnet ef database update --project backend/Helpdesk.Infraestructure/Helpdesk.Infraestructure.csproj --startup-project backend/Helpdesk/Helpdesk.csproj
4. Ejecutar la API:
   dotnet run --project backend/Helpdesk/Helpdesk.csproj
5. En desarrollo, abrir Swagger en: https://localhost:{puerto}/swagger

Ejecutar desde Visual Studio
- Abrir la solución backend/backend.slnx en Visual Studio.
- Establecer el proyecto Helpdesk como proyecto de inicio y ejecutar (F5 o Ctrl+F5).

Notas finales
- Revisar appsettings.json para logging, cadenas de conexión y configuración de entornos.
- Ajustar la política de CORS si el frontend se sirve desde otro origen.


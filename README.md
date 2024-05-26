# pos-pizzeria
Proyecto POS para la gestion de una pizzeria.

## Entorno de Base de Datos

- **Version de SQL Server:** SQL Server 2019
- **Edicion:** Standard Edition (64-bit)
- **Nivel de Producto:** RTM

Para configurar la base de datos, siga los siguientes pasos:

1. **Ejecute los scripts ubicados en la ruta de GitHub:** `proyecto/scriptdb`
   - **Script #1:** Crear la base de datos y sus respectivas tablas.
   - **Script #2:** Insertar datos en cada tabla para pruebas.

## Entorno de Desarrollo con .NET

### Backend
- **Version de .NET:** Microsoft .NET 8.0.3
- **Proyecto:** ASP.NET Core Web API
- **Diseno:** Estructura Organizacional + Arquitectura en Capas
- **Framework ORM:** Entity Framework Core
- **Seguridad:** `Microsoft.AspNetCore.Authentication.JwtBearer` 8.0.5
- **Encriptamiento de Datos:** `BCrypt.Net-Next` 4.0.3
- **Mapeo de Entidades:** `AutoMapper` 13.0.1

### Frontend


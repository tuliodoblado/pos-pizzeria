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
- **Framework ORM:** `microsoft.entityframeworkcore.sqlserver`
- **Seguridad:** `Microsoft.AspNetCore.Authentication.JwtBearer` 8.0.5
- **Encriptamiento de Datos:** `BCrypt.Net-Next` 4.0.3
- **Mapeo de Entidades:** `AutoMapper` 13.0.1

**Otras librerias utilizadas:** 
   - **.** `microsoft.entityframeworkcore.relational`
   - **.** `microsoft.entityframeworkcore.tools`
   - **.** `microsoft.identitymodel.tokens`
   - **.** `newtonsoft.json`
   - **.** `system.identitymodel.tokens.jwt`

### Frontend
Actualmente, el proyecto no incluye una interfaz grafica de usuario, ya que mi experiencia en la creacion de Windows Forms es limitada, el backend esta funcional y listo para ser integrado con cualquier frontend que se desee desarrollar. Se me expuso en la reunion que dejara este comentario.

### Saludos

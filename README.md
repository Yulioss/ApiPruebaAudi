# ApiPruebaAudi

API REST desarrollada con **ASP.NET Core 8** como parte de la prueba técnica.

El proyecto implementa la gestión de **estudiantes, profesores y notas**, incluyendo operaciones CRUD, paginación, búsqueda y un dashboard con información agregada.

La solución está organizada utilizando una arquitectura por capas para separar responsabilidades entre la API, la lógica de aplicación, el dominio y el acceso a datos.

---

## Tecnologías

* .NET 8
* ASP.NET Core Web API
* C#
* Entity Framework Core 8
* PostgreSQL
* Npgsql
* AutoMapper
* Swagger / OpenAPI
* LINQ
* Repository Pattern
* Dependency Injection

---

## Arquitectura

Arquitectura por capas (Layered Architecture)

La solución está dividida en las siguientes capas:

```text
ApiPruebaAudi
│
├── ApiPruebaAudi
│   ├── Controllers
│   ├── Middleware
│   ├── Program.cs
│   └── appsettings.json
│
├── ApiPruebaAudi.Application
│   ├── DTOs
│   ├── Exceptions
│   ├── Interfaces
│   ├── Mapings
│   └── Services
│
├── ApiPruebaAudi.Domain
│   ├── Entities
│   └── Interfaces
│
└── Infraestructure
    ├── Configuration
    ├── Data
    ├── Migrations
    └── Repositories
```

### API

Contiene los controladores HTTP, configuración de la aplicación y middleware.

### Application

Contiene los DTOs, interfaces, servicios de aplicación, excepciones y perfiles de AutoMapper.

### Domain

Contiene las entidades y contratos principales del dominio.

### Infrastructure

Contiene el acceso a datos mediante Entity Framework Core, repositorios, configuraciones de entidades y migraciones de base de datos.

La solución actualmente contiene controladores para `Students`, `Teachers`, `Notes` y `Dashboard`.

---

# Funcionalidades

## Estudiantes

El módulo de estudiantes permite:

* Consultar estudiantes.
* Consultar un estudiante por ID.
* Crear estudiantes.
* Actualizar estudiantes.
* Eliminar estudiantes.
* Realizar búsquedas.
* Utilizar paginación.

El endpoint de consulta acepta los parámetros:

```text
pageNumber
pageSize
searchTerm
```

Por defecto se utiliza:

```text
pageNumber = 1
pageSize = 10
```

---

## Profesores

El módulo de profesores permite realizar las operaciones CRUD correspondientes sobre los profesores.

---

## Notas

El módulo de notas permite:

* Consultar notas.
* Consultar una nota por ID.
* Crear notas.
* Actualizar notas.
* Eliminar notas.
* Buscar notas.
* Paginar resultados.
* Generar notas de forma masiva.

### Consultar notas

```http
GET /api/Notes
```

Ejemplo:

```http
GET /api/Notes?pageNumber=1&pageSize=10&searchTerm=matematicas
```

### Consultar una nota

```http
GET /api/Notes/{id}
```

### Crear una nota

```http
POST /api/Notes
```

### Actualizar una nota

```http
PUT /api/Notes/{id}
```

### Eliminar una nota

```http
DELETE /api/Notes/{id}
```

### Generar notas

```http
POST /api/Notes/Generate
```

La generación recibe la cantidad de notas que se desean generar.

---

# Dashboard

La API cuenta con un endpoint destinado a obtener información agregada para el dashboard.

```http
GET /api/Dashboard
```

---

# Base de datos

El proyecto utiliza **PostgreSQL** como motor de base de datos.

El acceso se realiza mediante:

```text
Entity Framework Core
        ↓
Npgsql
        ↓
PostgreSQL
```

La aplicación registra `AppDbContext` utilizando `UseNpgsql` y obtiene la cadena de conexión mediante `DefaultConnection`.

---

# Configuración de la base de datos

Crear una base de datos PostgreSQL para el proyecto.

Por ejemplo:

```text
Database: ApiPruebaAudi
Host: localhost
Port: 5432
Username: postgres
Password: ********
```

La cadena de conexión se configura mediante:

```text
ConnectionStrings:DefaultConnection
```

Ejemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ApiPruebaAudi;Username=postgres;Password=YOUR_PASSWORD"
  }
}
```

> Por seguridad, las credenciales reales no deben almacenarse en el repositorio.

---

# Migraciones de Entity Framework Core

El proyecto utiliza **Code First** mediante Entity Framework Core.

Las migraciones se encuentran en:

```text
Infraestructure/Migrations
```

Actualmente el proyecto incluye una migración inicial:

```text
20260903221835_InitialCreate
```

junto con su archivo Designer y el `AppDbContextModelSnapshot`.

## Instalar Entity Framework Core CLI

Si `dotnet ef` no está instalado:

```bash
dotnet tool install --global dotnet-ef
```

Verificar la instalación:

```bash
dotnet ef --version
```

---

## Aplicar las migraciones existentes

Desde la raíz del proyecto:

```bash
dotnet ef database update \
  --project Infraestructure \
  --startup-project ApiPruebaAudi
```

En Windows:

```powershell
dotnet ef database update --project Infraestructure --startup-project ApiPruebaAudi
```

Esto aplicará las migraciones pendientes sobre la base de datos configurada.

---

## Crear una nueva migración

Cuando se realicen cambios en las entidades o en las configuraciones de Entity Framework, se puede generar una nueva migración:

```bash
dotnet ef migrations add NombreMigracion \
  --project Infraestructure \
  --startup-project ApiPruebaAudi
```

Ejemplo:

```bash
dotnet ef migrations add AddStudentEmail \
  --project Infraestructure \
  --startup-project ApiPruebaAudi
```

La nueva migración será creada dentro de:

```text
Infraestructure/Migrations
```

Después se debe aplicar a la base de datos:

```bash
dotnet ef database update \
  --project Infraestructure \
  --startup-project ApiPruebaAudi
```

---

## Migración automática al iniciar

Además de mantener las migraciones en el repositorio, la aplicación ejecuta:

```csharp
db.Database.Migrate();
```

durante el inicio de la aplicación.

Esto permite que las migraciones pendientes se apliquen automáticamente cuando se inicia el backend.

Por lo tanto, para un entorno local, después de configurar correctamente la cadena de conexión, también es posible ejecutar directamente la API y permitir que Entity Framework aplique las migraciones pendientes.

---

# Ejecutar el proyecto

Clonar el repositorio:

```bash
git clone https://github.com/Yulioss/ApiPruebaAudi.git
```

Ingresar al directorio:

```bash
cd ApiPruebaAudi
```

Restaurar dependencias:

```bash
dotnet restore
```

Compilar:

```bash
dotnet build
```

Ejecutar:

```bash
dotnet run --project ApiPruebaAudi
```

---

# Swagger

En ambiente de desarrollo se encuentra habilitado Swagger/OpenAPI.

Al ejecutar la API se puede acceder a la interfaz de Swagger mediante la URL proporcionada por ASP.NET Core, por ejemplo:

```text
https://localhost:xxxx/swagger
```

Swagger permite consultar y probar los endpoints disponibles.

La configuración de Swagger se encuentra registrada directamente en `Program.cs`.

---

# CORS

La API tiene configurada una política CORS llamada:

```text
Angular
```

Los orígenes permitidos se obtienen desde la configuración:

```text
Cors:AllowedOrigins
```

La política permite:

* Headers.
* Métodos HTTP.

Esto permite que el frontend pueda consumir la API desde un origen autorizado.

---

# Manejo de errores

La aplicación utiliza un middleware global:

```text
ExceptionMiddleware
```

Este middleware centraliza el manejo de excepciones generadas durante el procesamiento de las solicitudes.

Esto permite mantener una respuesta consistente ante errores de la aplicación.

---

# Repository Pattern

El acceso a datos se encuentra abstraído mediante repositorios.

El flujo general de la aplicación es:

```text
HTTP Request
     │
     ▼
Controller
     │
     ▼
Application Service
     │
     ▼
Repository
     │
     ▼
Entity Framework Core
     │
     ▼
PostgreSQL
```

Esto permite separar las responsabilidades y facilita el mantenimiento y las pruebas del código.

---

# AutoMapper

Se utiliza **AutoMapper** para realizar la conversión entre entidades y DTOs.

Los perfiles se registran en la aplicación para los diferentes módulos:

```text
NoteProfile
StudentProfile
TeacherProfile
```

Esto evita realizar manualmente las transformaciones entre los objetos de dominio y los DTOs.

---

# Paginación y búsqueda

Los endpoints de estudiantes y notas implementan paginación.

Ejemplo:

```http
GET /api/Students?pageNumber=1&pageSize=10
```

También es posible enviar un término de búsqueda:

```http
GET /api/Students?pageNumber=1&pageSize=10&searchTerm=Juan
```

La misma estrategia se utiliza en el endpoint de notas.

---

# Comandos útiles

### Restaurar paquetes

```bash
dotnet restore
```

### Compilar

```bash
dotnet build
```

### Ejecutar

```bash
dotnet run --project ApiPruebaAudi
```

### Ejecutar pruebas

```bash
dotnet test
```

### Ver migraciones

```bash
dotnet ef migrations list \
  --project Infraestructure \
  --startup-project ApiPruebaAudi
```

### Crear migración

```bash
dotnet ef migrations add NombreMigracion \
  --project Infraestructure \
  --startup-project ApiPruebaAudi
```

### Aplicar migraciones

```bash
dotnet ef database update \
  --project Infraestructure \
  --startup-project ApiPruebaAudi
```

### Eliminar la última migración

```bash
dotnet ef migrations remove \
  --project Infraestructure \
  --startup-project ApiPruebaAudi
```

---

# Requisitos

Para ejecutar el proyecto se requiere:

* .NET 8 SDK
* PostgreSQL
* Entity Framework Core CLI
* Git

El proyecto está configurado para `net8.0` y utiliza Entity Framework Core 8 junto con `Npgsql.EntityFrameworkCore.PostgreSQL`.

---

# Estructura de datos

Las principales entidades utilizadas por la aplicación son:

```text
Student
Teacher
Note
```

Las configuraciones de Entity Framework correspondientes se encuentran en:

```text
Infraestructure/Configuration
```

Actualmente existen configuraciones específicas para:

```text
StudentConfiguration
TeacherConfiguration
NoteConfiguration
```

---

# Notas de configuración

El archivo `appsettings.json` del repositorio actualmente contiene únicamente la configuración general de logging y `AllowedHosts`; por lo tanto, la cadena de conexión debe agregarse/configurarse en el ambiente local antes de ejecutar la aplicación si no se proporciona mediante otra fuente de configuración.

Se recomienda no almacenar contraseñas ni credenciales reales directamente en el repositorio.

Para desarrollo local se pueden utilizar variables de entorno o User Secrets.

---

# Autor

**Julian Rangel**

Ingeniero de Sistemas / .NET Developer

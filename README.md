# TareasAPI

API RESTful construida con ASP.NET Core 8 y Entity Framework Core utilizando SQLite como base de datos.

## Descripción

Este proyecto permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre tareas con persistencia real en una base de datos SQLite. Ideal para aprender el desarrollo de APIs modernas con C# y consumo desde clientes externos como Postman o aplicaciones frontend.

## Endpoints principales

- GET `/api/tareas` — Obtener todas las tareas
- GET `/api/tareas/{id}` — Obtener tarea por ID
- POST `/api/tareas` — Crear nueva tarea
- PUT `/api/tareas/{id}` — Actualizar tarea
- DELETE `/api/tareas/{id}` — Eliminar tarea

## Tecnologías usadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Postman para pruebas

## Cómo correr el proyecto

1. Clonar repositorio  
2. Ejecutar `dotnet restore` para instalar paquetes  
3. Ejecutar `dotnet run` para iniciar la API  
4. Usar Postman o navegador para probar los endpoints


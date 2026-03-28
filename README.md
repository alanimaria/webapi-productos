# ProductosApi

API RESTful construida con ASP.NET Core Web API para gestión de productos.

## Cómo ejecutar

1. Clonar el repositorio
2. Entrar a la carpeta del proyecto:
   cd ProductosApi
3. Correr el proyecto:
   dotnet run

La API estará disponible en: http://localhost:5283

## Endpoints

| Método | URL | Descripción |
|--------|-----|-------------|
| GET | /api/Productos | Lista todos los productos |
| GET | /api/Productos/{id} | Obtiene un producto por ID |
| POST | /api/Productos | Crea un nuevo producto |
| PUT | /api/Productos/{id} | Actualiza un producto existente |
| DELETE | /api/Productos/{id} | Elimina un producto |

## Documentación Swagger

Acceder en: http://localhost:5283/swagger

## Cliente Web

Acceder en: http://localhost:5283/index.html

## Tecnologías utilizadas

- ASP.NET Core Web API
- Entity Framework Core (In-Memory)
- Swashbuckle / Swagger
- HTML y JavaScript con fetch()

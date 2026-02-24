## 👓 Technical Test Digital Bank
Proyecto desarrollado como prueba tecnica para Periferia.

El sistema integra el backend (API .NET Core).

## 🚀 Tecnologías utilizadas
- .NET 8
- ASP.NET Core (Web API y Razor Pages)
- Entity Framework Core
- SQL Server
- Bootstrap, jQuery, HTML5, CSS3

## ⚙️ Configuración inicial

1️⃣ Crear la base de datos
- Ejecutar el script DBScript/CREATE_DB_TABLE.sql en SQL Server.
El script incluye las instrucciones para crear y usar la base de datos:

  --CREATE DATABASE BFA

  --USE BFA

2️⃣ Configurar la cadena de conexión
- Editar el archivo: (Presentation/TechnicalTestBFAApi/appsettings.json) y ajustar el parámetro connectionDb con los datos de tu servidor SQL local:
  - "connectionDb": "Server=localhost;Database=BFA;User Id=sa;Password=TuPassword123;"

3️⃣ Restaurar dependencias y compilar
- Abrir la solución TechnicalTestBFAApi.sln en Visual Studio 2022 Community (recomendado).

4️⃣ Ejecutar el proyecto
- Ejecutar el proyecto de API Backend (TechnicalTestBFAApi) desde Visual Studio.

## 🧩 Arquitectura
El proyecto sigue un enfoque basado en arquitectura limpia / onion architecture, separando las responsabilidades en capas:

- Core/Domain: Entidades puras del dominio.
- Core/Application: DTOs, reglas de negocio y servicios.
- Infrastructure/DataAccess: Contexto de datos, persistencia y configuración.
- Infrastructure/ExternalService: Configuracion de api Region Externa, Metodos de consumo.
- TechnicalTestBFAApi: Endpoints públicos (controladores REST + Swagger).

## 💻 Requisitos previos
Visual Studio 2022 Community
SQL Server (local o remoto)
.NET SDK 8.0
Git (para clonar el repositorio)

🧾 Licencia
Proyecto prueba tecnica — libre para uso educativo y demostrativo.

## 📌 Autor
Sebastián Díaz Cárdenas

# Backend-Cinemax

Clean Architecture

## Comandos

- Levantar el API : dotnet run --project .\Cinemax.Api\

- Agregar migraciones : dotnet ef migrations add "AQUI NOMBRE DE LA MIGRACION" -p .\Cinemax.Infrastructure\ -s .\Cinemax.Api\

- Actualizar la base de datos a partir de las migraciones :  dotnet ef database update -p .\Cinemax.Infrastructure\ -s .\Cinemax.Api\

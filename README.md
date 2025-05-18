# MoviesWebApp

Aplikacja Razor Pages do zarządzania filmami, zbudowana w .NET 9.

## Technologie
- .NET 9
- Entity Framework Core

## Instalacja i uruchomienie
1. **Sklonuj repozytorium:**
   ```bash
   git clone https://github.com/uzytkownik/MoviesWebApp.git
   cd MoviesWebApp
   ```
2. **Uruchom aplikację:**
   ```bash
   dotnet run
   ```

## Konfiguracja bazy danych
Aplikacja domyślnie używa SQL Server. Połączenie można skonfigurować w pliku `appsettings.json`:

```json
"ConnectionStrings": {  
  "DefaultConnection": "Server=YOUR_SERVER;Database=MoviesDb;Trusted_Connection=True;TrustServerCertificate=True"  
}
```

## Wymagania
- .NET 9 SDK
- SQL Server

## Licencja
Projekt dostępny na licencji MIT.

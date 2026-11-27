# Healthcare.API

Backend API for a telehealth and patient portal: patients, appointments and telehealth sessions.
Built with **ASP.NET Core 8**, **Entity Framework Core** and **SQL Server**, using a layered architecture,
unit tests, Docker, and a GitHub Actions pipeline with a manual approval gate before production.

## Tech stack

- **.NET 8** · ASP.NET Core Web API · C#
- **Entity Framework Core 8** · SQL Server · EF migrations
- **xUnit** unit tests
- **Swagger / OpenAPI** for API docs
- **Docker** (multi-stage build)
- **GitHub Actions** CI/CD · **GitHub Container Registry (GHCR)**

## Architecture

The solution is split into layers, so each part has one job and depends on interfaces, not implementations:

```
Healthcare.API          → Controllers, startup, dependency injection
Healthcare.Services     → Business rules (e.g. appointments can't be booked in the past)
Healthcare.Repository   → Data access with EF Core
Healthcare.Data         → DbContext and migrations
Healthcare.Interface    → Service and repository interfaces
Healthcare.model        → Domain models (Patient, Appointment, Doctor, TelehealthSession, MedicalRecord)
Healthcare.UnitTest     → xUnit tests
```

Request flow: **Controller → Service → Repository → EF Core → SQL Server**

Because services depend on repository interfaces, business logic can be unit tested with simple fakes,
without a real database.

## API endpoints

| Resource | Method | Route | Description |
|---|---|---|---|
| Patient | GET | `/api/Patient` | List patients |
| Patient | GET | `/api/Patient/{id}` | Get a patient |
| Patient | POST | `/api/Patient` | Create a patient |
| Patient | PUT | `/api/Patient` | Update a patient |
| Appointment | GET | `/api/Appointment/{id}` | Get an appointment |
| Appointment | POST | `/api/Appointment` | Book an appointment (rejects past dates) |
| Appointment | PUT | `/api/Appointment` | Update an appointment |
| TelehealthSession | GET | `/api/TelehealthSession/{id}` | Get a session |
| TelehealthSession | GET | `/api/TelehealthSession/appointment/{appointmentId}` | Get the session for an appointment |
| TelehealthSession | POST | `/api/TelehealthSession` | Create a session |
| TelehealthSession | PUT | `/api/TelehealthSession` | Update a session |

When running in Development, Swagger UI is available at `/swagger`.

## Running locally

**Prerequisites:** .NET 8 SDK, SQL Server (local or Docker)

1. Set the connection string (it is intentionally empty in `appsettings.json`, so no secrets are committed):

   ```bash
   dotnet user-secrets set "ConnectionStrings:Default" "Server=localhost;Database=HealthcareDb;Trusted_Connection=True;TrustServerCertificate=True" --project Healthcare.API
   ```

2. Apply the database migrations:

   ```bash
   dotnet ef database update --project Healthcare.Data --startup-project Healthcare.API
   ```

3. Run the API:

   ```bash
   dotnet run --project Healthcare.API
   ```

## Running the tests

```bash
dotnet test Healthcare.UnitTest/Healthcare.UnitTest.csproj
```

## Running with Docker

```bash
docker build -t healthcare-api .
docker run -p 8080:8080 -e ConnectionStrings__Default="<your-connection-string>" healthcare-api
```

## CI/CD pipeline

Defined in `.github/workflows/ci.yaml`:

1. **Build and test**: runs on every push and pull request to `main`. Restores, builds in Release mode,
   runs the unit tests, and uploads the test results.
2. **Publish image**: runs only on pushes to `main`, after tests pass. Builds the Docker image and pushes it to
   GitHub Container Registry, tagged with `latest` and the commit SHA.
3. **Approval gate**: the publish job uses the `production` environment, so a reviewer must approve it before
   the image is published.

Changes are made on feature branches and merged into `main` through pull requests.

## Design decisions

- **Layered architecture with interfaces**: keeps controllers thin and business rules testable.
- **Secrets out of source control**: the connection string comes from user secrets or environment variables.
- **Resilient database connection**: EF Core's `EnableRetryOnFailure` retries transient SQL errors.
- **Multi-stage Docker build**: the SDK image builds the app; the smaller ASP.NET runtime image runs it.
- **Approval before production**: automated build and tests, with a human check before release.

## What I'd improve next

- Authentication and authorisation (JWT / Azure AD)
- Request validation and DTOs instead of exposing models directly
- Global exception handling with ProblemDetails responses
- Integration tests with `WebApplicationFactory`
- Health check endpoint for container and load-balancer probes
- Rename `AppoinmentDate` to `AppointmentDate` (with a migration)

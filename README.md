# Modular
Modular is a core library built for .NET applications. It is built with .NET 8.0. It includes the basics objects, which **SHOULD** be in majority of projects, including:
- ApplicationUser
- ApplicationRole
- AuditEntry
- AuditLog (requires Serilog to be added into Program.cs of main project)
- Company
- Configuration
- Contact
- Country

## Modular.Core
Modular.Core is the core component of this system, as it includes the DbContexts, Entities, Helpers, Interfaces, Types and the Custom Identity. It uses the following nuget packages:
- EntityFrameworkCore.DataEncryption v5.0.0
- FluentValidation v11.8.0
- Microsoft.AspNetCore.Identity.EntityFrameworkCore v8.0.0
- Microsoft.EntityFrameworkCore v8.0.0
- Microsoft.EntityFrameworkCore.Design v8.0.0
- Microsoft.EntityFrameworkCore.Sqlite v8.0.0
- Microsoft.EntityFrameworkCore.SqlServer v8.0.0
- Newtonsoft.Json v13.0.3

## Modular.Core.Services
Modular.Core is a part of the modular system, which includes services in the repository pattern. It also includes validators (built with FluentValidation). It uses the following nuget packages:
- FluentValidation v11.8.0
- Newtonsoft.Json v13.0.3

## Modular.Core.ViewModels
Modular.Core is a part of the modular system, which includes view models that can be used in accordance with the Entities. The models are converted using AutoMapper. It uses the following nuget packages:
- AutoMapper v12.0.1

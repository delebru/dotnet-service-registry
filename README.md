# Service Registration Utils

[![Nuget](https://img.shields.io/nuget/v/ServiceRegistration.svg)](https://www.nuget.org/packages/ServiceRegistration)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/license/mit)
[![Build .NET](https://github.com/delebru/dotnet-service-registry/actions/workflows/build.yml/badge.svg)](https://github.com/delebru/dotnet-service-registry/actions/workflows/build.yml)

A .NET library that simplifies dependency injection service registration through attributes. Instead of manually registering each service in your `Program.cs`, simply decorate your classes with lifetime attributes and let the library handle the registration automatically.

## Installation

Install the package from NuGet:

```bash
dotnet add package ServiceRegistration
```

## Usage

1. **Add attributes to your services:**

```csharp
[TransientService]
public class EmailService { }

[ScopedService(typeof(IUserService))]
public class UserService : IUserService { }

[SingletonService]
public class ConfigurationService { }

[HostedService]
public class BackgroundTaskService : BackgroundService { }
```

2. **Register all attributed services:**

```csharp
using ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

// Register all attributed services in the current assembly
builder.Services.AddAppServices(System.Reflection.Assembly.GetExecutingAssembly());

var app = builder.Build();
app.Run();
```

## Available Attributes

- **`[TransientService]`** - Equivalent to `services.AddTransient<T>()`
- **`[TransientService(typeof(I))]`** - Equivalent to `services.AddTransient<I, T>()`
- **`[ScopedService]`** - Equivalent to `services.AddScoped<T>()`
- **`[ScopedService(typeof(I))]`** - Equivalent to `services.AddScoped<I, T>()`
- **`[SingletonService]`** - Equivalent to `services.AddSingleton<T>()`
- **`[SingletonService(typeof(I))]`** - Equivalent to `services.AddSingleton<I, T>()`
- **`[HostedService]`** - Equivalent to `services.AddHostedService<T>()`

Singleton, Transient, and Scoped attributes support optional interface binding:
```csharp
[TransientService(typeof(IEmailService))]
public class EmailService : IEmailService { }
```

For more information about service lifetimes, see the [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes).

## Repository

Visit the [GitHub repository](https://github.com/delebru/dotnet-service-registry) for source code and issues.

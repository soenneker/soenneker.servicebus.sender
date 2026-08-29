[![](https://img.shields.io/nuget/v/Soenneker.ServiceBus.Sender.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Sender/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.sender/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.sender/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.ServiceBus.Sender.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Sender/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.sender/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.sender/actions/workflows/codeql.yml)

# Soenneker.ServiceBus.Sender

A utility library that holds Azure Service senders Singleton IoC.

## Install

```bash
dotnet add package Soenneker.ServiceBus.Sender
```

## Quick start

```csharp
using Soenneker.ServiceBus.Sender.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddServiceBusSenderUtilAsSingleton();
```

Registers Service Bus Sender Util with a singleton lifetime.

## What you get

- `IServiceBusSenderUtil` — A utility library that holds Azure Service senders Singleton IoC.
- `ServiceBusSenderUtilRegistrar` — A utility library that holds Azure Service senders.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `ServiceBusSenderUtilRegistrar.AddServiceBusSenderUtilAsSingleton(services)` | Registers Service Bus Sender Util with a singleton lifetime. | The same service collection, so additional registrations can be chained. |
| `ServiceBusSenderUtilRegistrar.AddServiceBusSenderUtilAsScoped(services)` | Registers Service Bus Sender Util with a scoped lifetime. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.

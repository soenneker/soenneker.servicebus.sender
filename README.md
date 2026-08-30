[![](https://img.shields.io/nuget/v/Soenneker.ServiceBus.Sender.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Sender/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.sender/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.sender/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.ServiceBus.Sender.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Sender/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.sender/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.sender/actions/workflows/codeql.yml)

# Soenneker.ServiceBus.Sender

Creates and caches one Azure `ServiceBusSender` per queue while reusing the shared top-level `ServiceBusClient`.

## Installation

```bash
dotnet add package Soenneker.ServiceBus.Sender
```

## Configuration and registration

Provide `Azure:ServiceBus:ConnectionString`, then choose the sender-cache lifetime:

```csharp
using Soenneker.ServiceBus.Sender.Registrars;

services.AddServiceBusSenderUtilAsScoped();
```

The scoped registration intentionally keeps the queue, administration, and top-level client utilities singleton. Disposing a scope releases that scope's cached senders while the shared `ServiceBusClient` remains available. Use `AddServiceBusSenderUtilAsSingleton()` when sender instances should remain cached for the entire application lifetime.

Because the first `Get` for a queue calls `CreateQueueIfDoesNotExist`, the connection-string credential needs queue-management permission in addition to send permission.

## Send to a queue

```csharp
using Azure.Messaging.ServiceBus;
using Soenneker.ServiceBus.Sender.Abstract;

public sealed class OrderPublisher(IServiceBusSenderUtil senderUtil)
{
    public async Task Send(
        BinaryData body,
        CancellationToken cancellationToken)
    {
        ServiceBusSender sender =
            await senderUtil.Get("orders", cancellationToken);

        var message = new ServiceBusMessage(body)
        {
            ContentType = "application/json",
            MessageId = Guid.NewGuid().ToString("N")
        };

        message.ApplicationProperties["type"] = "order.created.v1";

        await sender.SendMessageAsync(message, cancellationToken);
    }
}
```

The first request for an exact queue-name key ensures the queue exists, gets the shared client, and creates a sender. Later requests for that key reuse the same sender. Different queue-name strings receive different cached senders.

The utility does not build message bodies, set broker properties, batch messages, schedule delivery, or retry application-level failures. Use `Soenneker.ServiceBus.Message` when its message-envelope convention fits your producer.

Do not dispose a sender returned by `Get`; the sender utility owns it. Disposing the scoped or singleton utility disposes every sender it created but does not dispose the shared top-level Service Bus client.

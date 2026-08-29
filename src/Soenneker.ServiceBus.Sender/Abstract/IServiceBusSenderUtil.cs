using Azure.Messaging.ServiceBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.ServiceBus.Sender.Abstract;

/// <summary>
/// A utility library that holds Azure Service senders <para/>
/// Singleton IoC
/// </summary>
public interface IServiceBusSenderUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured service Bus Sender used by the Service Bus Sender.
    /// </summary>
    /// <param name="queueName">Name of the queue to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested service Bus Sender.</returns>
    ValueTask<ServiceBusSender> Get(string queueName, CancellationToken cancellationToken = default);
}

using Azure.Messaging.ServiceBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.ServiceBus.Sender.Abstract;

/// <summary>
/// Provides a cached Azure Service Bus sender for each queue name.
/// </summary>
public interface IServiceBusSenderUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets or creates the sender for the queue, creating the queue with Azure defaults first when it does not exist.
    /// </summary>
    /// <param name="queueName">Name of the queue to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The cached sender. It is owned by this service and should not be disposed by the caller.</returns>
    ValueTask<ServiceBusSender> Get(string queueName, CancellationToken cancellationToken = default);
}

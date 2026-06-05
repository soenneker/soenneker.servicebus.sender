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
    /// Gets the value.
    /// </summary>
    /// <param name="queueName">The queue name.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<ServiceBusSender> Get(string queueName, CancellationToken cancellationToken = default);
}
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
    ValueTask<ServiceBusSender> Get(string queueName, CancellationToken cancellationToken = default);
}
using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Soenneker.ServiceBus.Sender.Abstract;

/// <summary>
/// A utility library that holds Azure Service senders <para/>
/// Singleton IoC
/// </summary>
public interface IServiceBusSenderUtil : IDisposable, IAsyncDisposable
{
    ValueTask<ServiceBusSender> GetSender(string queueName);
}
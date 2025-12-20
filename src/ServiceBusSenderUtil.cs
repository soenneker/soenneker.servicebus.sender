using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Soenneker.Extensions.ValueTask;
using Soenneker.ServiceBus.Client.Abstract;
using Soenneker.ServiceBus.Queue.Abstract;
using Soenneker.ServiceBus.Sender.Abstract;
using Soenneker.Utils.SingletonDictionary;

namespace Soenneker.ServiceBus.Sender;

///<inheritdoc cref="IServiceBusSenderUtil"/>
public sealed class ServiceBusSenderUtil : IServiceBusSenderUtil
{
    private readonly SingletonDictionary<ServiceBusSender> _senders;

    public ServiceBusSenderUtil(IServiceBusClientUtil serviceBusClientUtil, IServiceBusQueueUtil serviceBusQueueUtil)
    {
        _senders = new SingletonDictionary<ServiceBusSender>(async (queueName, token) =>
        {
            await serviceBusQueueUtil.CreateQueueIfDoesNotExist(queueName)
                                     .NoSync();

            ServiceBusClient client = await serviceBusClientUtil.Get(token)
                                                                .NoSync();

            return client.CreateSender(queueName);
        });
    }

    public ValueTask<ServiceBusSender> Get(string queueName, CancellationToken cancellationToken = default)
    {
        return _senders.Get(queueName, cancellationToken);
    }

    public ValueTask DisposeAsync()
    {
        return _senders.DisposeAsync();
    }

    public void Dispose()
    {
        _senders.Dispose();
    }
}
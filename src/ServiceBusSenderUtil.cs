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
    private readonly IServiceBusClientUtil _serviceBusClientUtil;
    private readonly IServiceBusQueueUtil _serviceBusQueueUtil;

    public ServiceBusSenderUtil(IServiceBusClientUtil serviceBusClientUtil, IServiceBusQueueUtil serviceBusQueueUtil)
    {
        _serviceBusClientUtil = serviceBusClientUtil;
        _serviceBusQueueUtil = serviceBusQueueUtil;
        _senders = new SingletonDictionary<ServiceBusSender>(CreateSender);
    }

    private async ValueTask<ServiceBusSender> CreateSender(string queueName, CancellationToken token)
    {
        await _serviceBusQueueUtil.CreateQueueIfDoesNotExist(queueName)
                                  .NoSync();

        ServiceBusClient client = await _serviceBusClientUtil.Get(token)
                                                            .NoSync();

        return client.CreateSender(queueName);
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
using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Soenneker.ServiceBus.Client.Abstract;
using Soenneker.ServiceBus.Queue.Abstract;
using Soenneker.ServiceBus.Sender.Abstract;
using Soenneker.Utils.SingletonDictionary;

namespace Soenneker.ServiceBus.Sender;

///<inheritdoc cref="IServiceBusSenderUtil"/>
public class ServiceBusSenderUtil : IServiceBusSenderUtil
{
    private readonly SingletonDictionary<ServiceBusSender> _senders;

    public ServiceBusSenderUtil(IServiceBusClientUtil serviceBusClientUtil, IServiceBusQueueUtil serviceBusQueueUtil)
    {
        _senders = new SingletonDictionary<ServiceBusSender>(async queue =>
        {
            var queueName = (string)queue![0];

            await serviceBusQueueUtil.CreateQueueIfDoesNotExist(queueName);

            ServiceBusSender? sender = (await serviceBusClientUtil.GetClient()).CreateSender(queueName);

            return sender;
        });
    }

    public ValueTask<ServiceBusSender> GetSender(string queueName)
    {
        return _senders.Get(queueName, queueName);
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _senders.DisposeAsync();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _senders.Dispose();
    }
}
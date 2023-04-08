using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.ServiceBus.Queue.Registrars;
using Soenneker.ServiceBus.Sender.Abstract;

namespace Soenneker.ServiceBus.Sender.Registrars;

/// <summary>
/// A utility library that holds Azure Service senders
/// </summary>
public static class ServiceBusSenderUtilRegistrar
{
    /// <summary>
    /// As Singleton
    /// </summary>
    public static void AddServiceBusSenderUtil(this IServiceCollection services)
    {
        services.AddServiceBusQueueUtil();
        services.TryAddSingleton<IServiceBusSenderUtil, ServiceBusSenderUtil>();
    }
}
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
    public static void AddServiceBusSenderUtilAsSingleton(this IServiceCollection services)
    {
        services.AddServiceBusQueueUtil();
        services.TryAddSingleton<IServiceBusSenderUtil, ServiceBusSenderUtil>();
    }

    public static void AddServiceBusSenderUtilAsScoped(this IServiceCollection services)
    {
        services.AddServiceBusQueueUtil();
        services.TryAddScoped<IServiceBusSenderUtil, ServiceBusSenderUtil>();
    }
}
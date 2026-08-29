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
    /// Registers Service Bus Sender Util with a singleton lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddServiceBusSenderUtilAsSingleton(this IServiceCollection services)
    {
        services.AddServiceBusQueueUtilAsSingleton().TryAddSingleton<IServiceBusSenderUtil, ServiceBusSenderUtil>();

        return services;
    }

    /// <summary>
    /// Registers Service Bus Sender Util with a scoped lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddServiceBusSenderUtilAsScoped(this IServiceCollection services)
    {
        services.AddServiceBusQueueUtilAsSingleton().TryAddScoped<IServiceBusSenderUtil, ServiceBusSenderUtil>();

        return services;
    }
}

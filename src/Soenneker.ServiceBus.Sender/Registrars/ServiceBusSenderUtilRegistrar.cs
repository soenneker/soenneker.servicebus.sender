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
    /// Adds service bus sender util as singleton.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
    public static IServiceCollection AddServiceBusSenderUtilAsSingleton(this IServiceCollection services)
    {
        services.AddServiceBusQueueUtilAsSingleton().TryAddSingleton<IServiceBusSenderUtil, ServiceBusSenderUtil>();

        return services;
    }

    /// <summary>
    /// Adds service bus sender util as scoped.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
    public static IServiceCollection AddServiceBusSenderUtilAsScoped(this IServiceCollection services)
    {
        services.AddServiceBusQueueUtilAsSingleton().TryAddScoped<IServiceBusSenderUtil, ServiceBusSenderUtil>();

        return services;
    }
}
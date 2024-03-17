using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace LearnSk.Samples;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKeyedServices<T>(this IServiceCollection services, Assembly assembly)
    {
        var implementations = assembly.GetTypes()
            .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var implementation in implementations)
        {
            services.AddKeyedTransient(typeof(T), implementation.Name, implementation);
        }

        return services;
    }
}

using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Logging.Serilog;
using Core.CrossCuttingConcerns.Exceptions.Logging.Serilog.Logger;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddScoped<LoggerServiceBase, FileLogger>();
            services.AddScoped<LoggerServiceBase, MsSqlLogger>();

            // This registers all classes inheriting BaseBusinessRules in the DI container,
            // allowing centralized management of application business rules.
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            return services;
        }

        // Adds all subclasses of the specified type from the given assembly to the service collection.
        // By default, registers each subclass with Scoped lifetime. Optionally, a custom registration
        // behavior can be provided through the addWithLifeCycle parameter.

        public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);
                else
                    addWithLifeCycle(services, type);
            return services;
        }
    }
}

using Application.Services.AssignmentService;
using Application.Services.MailService;
using Application.Services.OperationClaimService;
using Application.Services.UserService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using FluentValidation;
using Infrastructure.Mail;
using Infrastructure.Mail.MailKitImplementations;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
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
                config.AddOpenBehavior(typeof(CachingBehavior<,>));
                config.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
                config.AddOpenBehavior(typeof(PerformanceBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddSingleton<IMailService, MailKitMailService>();
            services.AddSingleton<FileLogger>();
            services.AddSingleton<MsSqlLogger>();

            services.AddSingleton<LoggerServiceBase>(provider =>
            {
                var fileLogger = provider.GetRequiredService<FileLogger>();
                var msSqlLogger = provider.GetRequiredService<MsSqlLogger>();

                return new LoggerServiceBase
                {
                    Logger = new LoggerConfiguration()
                        .WriteTo.Logger(fileLogger.Logger)
                        .WriteTo.Logger(msSqlLogger.Logger)
                        .CreateLogger()
                };
            });

            // This registers all classes inheriting BaseBusinessRules in the DI container,
            // allowing centralized management of application business rules.
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IOperationClaimService, OperationClaimManager>();
            services.AddScoped<IAssignmentService, AssignmentManager>();
            services.AddScoped<IEmailAuthenticatorService, EmailAuthenticatorManager>();

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

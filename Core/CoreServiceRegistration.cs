using Core.Security.EmailCodeGenerator;
using Core.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IEmailCodeGeneratorHelper, EmailCodeGeneratorHelper>();

            return services;
        }
    }
}

using console_app_sample.Configurations.Interfaces;
using console_app_sample.Services;
using console_app_sample.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace console_app_sample.Configurations
{
    public static class IoC
    {
        public static IServiceCollection AddAppIoC(this IServiceCollection services, IConfiguration configuration)
        {            
            var applicationSettings = configuration.GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>();
            services.AddSingleton<IApplicationSettings>(applicationSettings);

            services.AddScoped<IHelloWorldService, HelloWorldService>();


            return services;
        }

        public static IServiceCollection AddAppLogging(this IServiceCollection services)
        {
            var loggerFactory = LoggerFactory.Create(c =>
            {
                c.AddSerilog();
            });

            services.AddSingleton<ILoggerFactory>(loggerFactory);

            return services;
        }





        
    }
}

using console_app_sample.Configurations;
using console_app_sample.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace console_app_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            RunApplication();

            //Force batched itens to be published to azure analytics
            Log.CloseAndFlush();
        }

        private static void RunApplication()
        {
            var host = BuildHost();

            using (var serviceScope = host.Services.CreateScope())
            {
                try
                {
                    var service = serviceScope.ServiceProvider.GetService<IHelloWorldService>();
                    service.RunSample();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured");
                }
            }
        }

        private static IHost BuildHost()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)                
                .AddEnvironmentVariables();

            var configuration = configurationBuilder.Build();

            var builder = new HostBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddConfiguration(configuration);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddAppLogging();

                    services.AddAppIoC(configuration);                    
                })
                .UseLogging(configuration);

            return builder.Build();
        }
    }
}

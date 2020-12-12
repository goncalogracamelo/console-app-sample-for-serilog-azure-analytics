using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace console_app_sample.Configurations
{
    public static class Bootstrap
    {
        public static IHostBuilder UseLogging(this IHostBuilder app, IConfiguration configuration)
        {        
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Information()               
               .WriteTo.AzureAnalytics(workspaceId: "<TODO - yourworkspaceId from Azure Analytics>",
                                      authenticationId: "<TODO - your authentication Id from Log Analytics>",
                                      batchSize: 10)
               .CreateLogger();
            
            Log.Logger.Information("Application Starting!");

            return app;
        }

    }
}

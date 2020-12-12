using console_app_sample.Configurations.Interfaces;
using console_app_sample.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace console_app_sample.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        private readonly ILogger<HelloWorldService> _logger;
        private readonly IApplicationSettings _applicationSettings;
        public HelloWorldService(ILogger<HelloWorldService> logger, IApplicationSettings applicationSettings)
        {
            _logger = logger;
            _applicationSettings = applicationSettings;
        }

        public void RunSample()
        {
            _logger.LogInformation("Logging for application {appName}", _applicationSettings.AppName);
        }
    }
}
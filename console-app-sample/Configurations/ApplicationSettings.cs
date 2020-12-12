using console_app_sample.Configurations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace console_app_sample.Configurations
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string AppName { get; set; }
    }
}

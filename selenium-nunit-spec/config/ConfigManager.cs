using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_nunit_spec.config
{
    class ConfigManager
    {
        public static IConfigurationRoot GetConfig() {

            var builder = new ConfigurationBuilder()
               .AddEnvironmentVariables()
               .AddJsonFile($"appsettings.json", true, true);

           return builder.Build();

        }
    }
}

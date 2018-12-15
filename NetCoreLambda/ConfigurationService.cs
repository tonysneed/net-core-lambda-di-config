using System.IO;
using Microsoft.Extensions.Configuration;

namespace NetCoreLambda
{
    public class ConfigurationService : IConfigurationService
    {
        public IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
using Microsoft.Extensions.Configuration;

namespace NetCoreLambda
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}
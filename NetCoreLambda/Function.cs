using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace NetCoreLambda
{
    public class Function
    {
        // Configuration Service
        public IConfigurationService ConfigService { get; }

        public Function()
        {
            // Set up Dependency Injection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Get Configuration Service from DI system
            ConfigService = serviceProvider.GetService<IConfigurationService>();
        }

        // Use this ctor from unit tests that can mock IConfigurationService
        public Function(IConfigurationService configService)
        {
            ConfigService = configService;
        }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            // Get config setting using input as a key
            return ConfigService.GetConfiguration()[input] ?? "None";
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Register services with DI system
            serviceCollection.AddTransient<IEnvironmentService, EnvironmentService>();
            serviceCollection.AddTransient<IConfigurationService, ConfigurationService>();
        }
    }
}

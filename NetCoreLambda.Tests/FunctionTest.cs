using Xunit;
using Amazon.Lambda.TestUtilities;
using Microsoft.Extensions.Configuration;
using Moq;

namespace NetCoreLambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void Function_Should_Return_Config_Variable()
        {
            // Mock IConfiguration
            var expected = "val1";
            var mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(p => p[It.IsAny<string>()]).Returns(expected);

            // Mock IConfigurationService
            var mockConfigService = new Mock<IConfigurationService>();
            mockConfigService.Setup(p => p.GetConfiguration()).Returns(mockConfig.Object);

            // Invoke the lambda function and confirm config value is returned
            var function = new Function(mockConfigService.Object);
            var result = function.FunctionHandler("env1", new TestLambdaContext());
            Assert.Equal(expected, result);
        }
    }
}

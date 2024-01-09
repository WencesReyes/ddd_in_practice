using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Factories
{
    public sealed class ServiceCollectionSingleton
    {
        private static ServiceProvider? _instance;

        public static ServiceProvider GetInstance()
        {
            if (_instance is null)
            {
                
                var configuration = ConfigurationSingleton.GetInstance();

                _instance = new ServiceCollection()
                    .AddInfrastructureServices(configuration.GetConnectionString("dddConnectionString"))
                    .BuildServiceProvider();
            }

            return _instance;
        }
    }
}

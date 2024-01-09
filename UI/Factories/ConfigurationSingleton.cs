using Microsoft.Extensions.Configuration;
using System.IO;

namespace UI.Factories
{
    public sealed class ConfigurationSingleton
    {
        private static IConfiguration? _instance;

        public static IConfiguration GetInstance()
        {
            if (_instance is null)
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                string projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));

                _instance = new ConfigurationBuilder()
                    .SetBasePath(projectRoot)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
            }

            return _instance;
        }
    }
}

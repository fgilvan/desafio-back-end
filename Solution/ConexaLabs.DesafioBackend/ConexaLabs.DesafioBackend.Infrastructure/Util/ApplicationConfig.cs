using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConexaLabs.DesafioBackend.Infrastructure.Util
{
    public class ApplicationConfig
    {
        private IConfigurationRoot _configurationRoot;

        public string GetAppSettings(string key)
        {
            if(_configurationRoot == null)
                _configurationRoot = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json")
                       .Build();

            return _configurationRoot[key];
        }
    }
}

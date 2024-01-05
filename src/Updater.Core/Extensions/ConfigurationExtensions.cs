using System;
using Microsoft.Extensions.Configuration;

namespace Updater.Core.Extensions
{
	public static class ConfigurationExtensions
	{

        private static IConfiguration? _configuration;

        public static IProfileBuilderOptions EnableConfiguration(
       this IProfileBuilderOptions options,
       Action<ConfigurationBuilder> configuration)
        {
            ConfigurationBuilder builder = new();
            configuration(builder);
            _configuration = builder.Build();
            
            return options;
        }

        internal static IConfiguration Configuration(
            this IProfileServices services) => _configuration ??
            throw new InvalidOperationException(
                "Configuration services are not available");
    }
}


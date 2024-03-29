﻿namespace Command.API.Configurations;

internal static class ConfigurationRegister
{
    internal static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder host)
    {
        host.ConfigureAppConfiguration((context, config) =>
        {
            const string configurationsDirectory = "Configurations";
            var env = context.HostingEnvironment;
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"{configurationsDirectory}/logger.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"{configurationsDirectory}/logger.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"{configurationsDirectory}/cache.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"{configurationsDirectory}/cache.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"{configurationsDirectory}/database.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"{configurationsDirectory}/database.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        });
        return host;
    }
}

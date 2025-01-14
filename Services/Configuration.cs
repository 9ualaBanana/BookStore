using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BookStore.Services;

internal class Configuration
{
    internal readonly static IConfiguration Instance = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{EnvironmentName.Development}.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();
}

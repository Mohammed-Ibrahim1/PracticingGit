using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Build configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Setup dependency injection
var services = new ServiceCollection();
services.AddLogging(config =>
{
    config.AddConsole();
    config.AddConfiguration(configuration.GetSection("Logging"));
});
services.AddSingleton<IConfiguration>(configuration);

var serviceProvider = services.BuildServiceProvider();
var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Application started");
logger.LogInformation("Configuration loaded from appsettings.json");

// Use configuration example
var allowedHosts = configuration["AllowedHosts"];
logger.LogInformation("AllowedHosts: {AllowedHosts}", allowedHosts);

// Cleanup
await serviceProvider.DisposeAsync();

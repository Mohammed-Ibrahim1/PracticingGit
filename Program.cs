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


// Use configuration example
var allowedHosts = configuration["AllowedHosts"];

// Cleanup
await serviceProvider.DisposeAsync();

var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
Console.WriteLine($"Environment Name: {appSettings.EnvironmentName}");
Console.WriteLine($"Greeting: {appSettings.Greeting}");
Console.WriteLine($"Password: {appSettings.Pasword}");

var  p  = new Person();
p.Age = 30;
p.ID  =100;

Console.WriteLine(p.Age);
public sealed class AppSettings
{
    public string EnvironmentName { get; set; } = string.Empty;
    public string Greeting { get; set; } = string.Empty;
    public string Pasword { get; set; } = string.Empty;
}
// See https://aka.ms/new-console-template for more information

using Business.Commands;
using Business.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.CommandLine;

var services = new ServiceCollection();
ConfigureServices(services);

using var serviceProvider = services.BuildServiceProvider();
var task = serviceProvider?.GetService<ReadCommand>() ?? throw new ArgumentNullException(nameof(serviceProvider));
await task.InvokeAsync(args);

static void ConfigureServices(IServiceCollection services)
{
    services.AddLogging(builder =>
    {
        builder.AddConsole();
        builder.AddDebug();
    });

    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .AddEnvironmentVariables()
        .Build();

    services.Configure<CVSettings>(configuration.GetSection(CVSettings.SettingsName));
    services.AddTransient<ReadCommand>();
}
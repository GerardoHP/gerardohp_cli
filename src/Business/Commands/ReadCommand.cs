using Business.Dto;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.CommandLine;

namespace Business.Commands;

public class ReadCommand : RootCommand
{
    private readonly ILogger<ReadCommand> _logger;
    private readonly CVSettings _settings;

    public ReadCommand(IOptions<CVSettings> settings, ILogger<ReadCommand> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));

        var commonOptions = CommonOptions.GetInstance();
        var readCommand = new Command("read", "Read the info")
        {
            commonOptions.PersonalData,
            commonOptions.Education,
            commonOptions.Jobs,
            commonOptions.Contacts,
            commonOptions.ShowHidden,
        };
        
        AddCommand(readCommand);
        readCommand.SetHandler(async (personalData) =>
        {
            await ReadFromFile(personalData);
        }, commonOptions.PersonalData);
    }

    private async Task ReadFromFile(bool personalData)
    {
        if (personalData)
        {
            _logger.LogInformation("si habia personal data");
            Console.WriteLine(_settings.Person);
        }
       
        await Task.CompletedTask;
    }
}
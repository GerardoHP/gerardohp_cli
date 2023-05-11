using Business.Dto;
using business.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.CommandLine;
using System.Text;

namespace Business.Commands;

public sealed class ReadCommand : RootCommand
{
    private readonly ILogger<ReadCommand> _logger;
    private readonly CVSettings _settings;
    private const string _logoPath = "logo";

    public ReadCommand(IOptions<CVSettings> settings, ILogger<ReadCommand> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));

        var description =
            new StringBuilder(
                "Welcome to the curriculum vitae for Gerardo Hernandez. Visit gerardohp.dev for more info");
        description.AppendLine();
        var logoLines = FileUtils.ReadFile(_logoPath);
        foreach (var line in logoLines)
        {
            description.AppendLine(line);
        }

        Description = description.ToString();
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
        readCommand.SetHandler(async (personalData, education) => { await ReadFromFile(personalData, education); },
            commonOptions.PersonalData,
            commonOptions.Education);
    }

    private async Task ReadFromFile(bool personalData, bool education)
    {
        if (personalData)
        {
            _logger.LogInformation("si habia personal data");
            Console.WriteLine(_settings.Person);
        }
        
        if (!education)
        {
            _logger.LogInformation("no hay educacion");
        }

        await Task.CompletedTask;
    }
}
using Microsoft.Extensions.Options;
using System.CommandLine;

namespace Business.Commands;

public class CommonOptions
{
    public readonly Option<bool> PersonalData;
    public readonly Option<bool> Education;
    public readonly Option<bool> Jobs;
    public readonly Option<bool> Contacts;
    public readonly Option<bool> ShowHidden;

    private CommonOptions()
    {
        PersonalData = new Option<bool>(new[]
            {
                "--personal-data",
                "-p",
            },
            "Display the information data"
        );

        Education = new Option<bool>(new[]
            {
                "--education",
                "-e",
            },
            "Display the education"
        );

        Jobs = new Option<bool>(new[]
            {
                "--jobs",
                "-j",
            },
            "Display the jobs"
        );

        Contacts = new Option<bool>(new[]
            {
                "--contact",
                "-c"
            },
            "Display the contact info"
        );

        ShowHidden = new Option<bool>(new[]
            {
                "--show-hidden",
                "-s",
            },
            "Show the hidden values");
    }

    private static CommonOptions _instance;

    public static CommonOptions GetInstance()
    {
        _instance = _instance ?? new CommonOptions();
        return _instance;
    }
}
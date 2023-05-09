namespace Business.Dto;

public class CVSettings
{
    public const string SettingsName = nameof(CVSettings);
    
    public Person Person { get; set; }
    public List<School> Education { get; set; } 
    public List<Work> Jobs { get; set; }
    public List<Contact> Contacts { get; set; }
}
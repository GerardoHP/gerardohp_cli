namespace Business.Dto;

public class Work
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string RelevantJob { get; set; } = string.Empty;
    public List<string> Achievements { get; set; } = new List<string>();
    public bool Hidden { get; set; } 
}
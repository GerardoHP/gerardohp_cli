namespace Business.Dto;

public class School 
{
    public string SchoolName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartingDate { get; set; } 
    public DateTime EndingDate { get; set; }
    public bool Hidden { get; set; }
}
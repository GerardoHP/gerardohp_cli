namespace Business.Dto;

public class Skill
{
    public string Name { get; set; } = string.Empty;
    public int Duration { get; set; } 
    public Category Category { get; set; }
    public bool Relevant { get; set; }
}
namespace feedback.Models;

public class DefaultForm
{
    public int Id { get; set; }
    public int FormID { get; set; }
    public Form? Form { get; set; }
    
    public string? Category { get; set; }
    
}
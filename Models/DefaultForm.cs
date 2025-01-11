using System.ComponentModel.DataAnnotations;

namespace feedback.Models;

public class DefaultForm
{
    public int Id { get; set; }
    public int FormID { get; set; }
    public Form? Form { get; set; }
    
    [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
    public string? Category { get; set; }
    
}
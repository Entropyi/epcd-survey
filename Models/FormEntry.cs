using System.ComponentModel.DataAnnotations;

namespace feedback.Models;

public class FormEntry
{
    public int Id { get; init; }
    
    /*
    public int FormId { get; init; }
    public Form Form { get; init; }
    */
    
    [Required(ErrorMessage = "Required")]
    public string? AgeGroup { get; init; }
    
    [Required(ErrorMessage = "Required")]
    public string? Education { get; init; }
    
    [Required(ErrorMessage = "Required")]
    public string? Sex { get; init; }
    
    [Required(ErrorMessage = "Required")]
    public string? Scale1 { get; init; }

    [Required(ErrorMessage = "Required")]
    public string? Scale2 { get; init; }
    
    [Required(ErrorMessage = "Required")]
    public string? Scale3 { get; init; }

    [Required(ErrorMessage = "Required")]
    public string? Scale4 { get; init; }

    [Required(ErrorMessage = "Required")]
    public string? Scale5 { get; init; }
    
    [Required(ErrorMessage = "Required")]
    public string? Scale6 { get; init; }

    [Required(ErrorMessage = "Required")]
    public string? Scale7 { get; init; }
    
    [Required(ErrorMessage = "Required")]
    public string? Scale8 { get; init; }

    [Required(ErrorMessage = "Required")]
    public string? Scale9 { get; init; }

    [Required(ErrorMessage = "Required")]
    public string? Scale10 { get; init; }
    

    public string? OpenQuestion { get; init; } = string.Empty;


    public enum Language { en = 1, ar = 0 }
    public Language Locale { get; init; }
    
    public string CreationDate { get; init; } = DateTime.Now.ToString("MM/dd/yyyy-hh:mm:ss");

}

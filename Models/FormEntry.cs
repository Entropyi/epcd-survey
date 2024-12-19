using System.ComponentModel.DataAnnotations;

namespace feedback.Models;

public class FormEntry
{
    public int Id { get; init; }


    public int FormId { get; init; }
    public Form? Form { get; init; }


    [Required(ErrorMessage = "Required")] public int? AgeGroup { get; init; }

    [Required(ErrorMessage = "Required")] public int? Education { get; init; }

    public enum Sexes
    {
        Male,
        Female
    }

    [Required(ErrorMessage = "Required")] public Sexes Sex { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale1 { get; set; }

    [Required(ErrorMessage = "Required")] public int? Scale2 { get; set; }

    [Required(ErrorMessage = "Required")] public int? Scale3 { get; set; }

    [Required(ErrorMessage = "Required")] public int? Scale4 { get; set; }

    [Required(ErrorMessage = "Required")] public int? Scale5 { get; set; }

    [Required(ErrorMessage = "Required")] public int? Scale6 { get; set; }

    [Required(ErrorMessage = "Required")] public int? Scale7 { get; set; }

    [Required(ErrorMessage = "Required")] public int? Scale8 { get; set; }

    [Required(ErrorMessage = "Required")] public int? Scale9 { get; set; }

    [Required(ErrorMessage = "Required")] public int? Scale10 { get; set; }


    public string? OpenQuestion { get; init; } = string.Empty;


    public enum Languages
    {
        en,
        ar
    }

 public Languages? Language { get; init; }

    public enum Categories
    {
        Community,
        Indestry
    }

public Categories? Category { get; init; }

public DateTime? CreationDate { get; init; } = DateTime.Now;
}
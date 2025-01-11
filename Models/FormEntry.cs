using System.ComponentModel.DataAnnotations;

namespace feedback.Models;

public class FormEntry
{
    public int Id { get; init; }


    public int FormId { get; init; }
    public Form? Form { get; init; }


    [Required(ErrorMessage = "Required")]
    [Range(1, 4)]
    public int? AgeGroup { get; init; }

    [Required(ErrorMessage = "Required")]
    [Range(1, 5)]
    public int? Education { get; init; }

    public enum Sexes
    {
        Male,
        Female
    }

    [Required(ErrorMessage = "Required")] public Sexes Sex { get; init; }

    [Required(ErrorMessage = "Required")]
    [Range(1, 5)]
    public int? Scale1 { get; set; }

    [Required(ErrorMessage = "Required")]
    [Range(1, 5)]
    public int? Scale2 { get; set; }

    [Required(ErrorMessage = "Required")]
    [Range(1, 5)]
    public int? Scale3 { get; set; }

    [Required(ErrorMessage = "Required")]
    [Range(1, 5)]
    public int? Scale4 { get; set; }

    [Required(ErrorMessage = "Required")]
    [Range(1, 5)]
    public int? Scale5 { get; set; }

    [Required(ErrorMessage = "Required")]
    [Range(1, 5)]
    public int? Scale6 { get; set; }

    [Required(ErrorMessage = "Required")]
    [Range(1, 5)]
    public int? Scale7 { get; set; }

    [Range(1, 5)] public int? Scale8 { get; set; }
    [Range(1, 5)] public int? Scale9 { get; set; }
    [Range(1, 5)] public int? Scale10 { get; set; }

    [MaxLength(1500)] public string? OpenQuestion { get; init; } = string.Empty;


    public enum Languages
    {
        en,
        ar
    }

    public Languages? Language { get; init; }

    [MaxLength(60)] public string? Category { get; init; }

    public DateTime? CreationDate { get; init; } = DateTime.Now;
}
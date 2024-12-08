using System.ComponentModel.DataAnnotations;

namespace feedback.Models;

public class Form
{
    public int id { get; set; }

    public enum FormCategory
    {
        Community,
        industry,
    }

    [Required(ErrorMessage = "Required")] public FormCategory? Category { get; set; }

    [Required(ErrorMessage = "Required")] public string? FromTitleAr { get; set; }
    [Required(ErrorMessage = "Required")] public string? FromTitleEn { get; set; }

    [Required(ErrorMessage = "Required")] public string? FromSectionOneLabelAr { get; set; }
    [Required(ErrorMessage = "Required")] public string? FromSectionOneLabelEn { get; set; }
    [Required(ErrorMessage = "Required")] public string? FromSectionTwoLabelAr { get; set; }
    [Required(ErrorMessage = "Required")] public string? FromSectionTwoLabelEn { get; set; }
    [Required(ErrorMessage = "Required")] public string? FromSectionThreeLabelAr { get; set; }
    [Required(ErrorMessage = "Required")] public string? FromSectionThreeLabelEn { get; set; }

    [Required(ErrorMessage = "Required")] public string? Question1 { get; set; }

    [Required(ErrorMessage = "Required")] public string? Questions2 { get; set; }

    [Required(ErrorMessage = "Required")] public string? Questions3 { get; set; }

    [Required(ErrorMessage = "Required")] public string? Questions4 { get; set; }

    [Required(ErrorMessage = "Required")] public string? Questions5 { get; set; }

    [Required(ErrorMessage = "Required")] public string? Questions6 { get; set; }

    [Required(ErrorMessage = "Required")] public string? Questions7 { get; set; }

    [Required(ErrorMessage = "Required")] public string? Questions8 { get; set; }

    [Required(ErrorMessage = "Required")] public string? Questions9 { get; set; }

    [Required(ErrorMessage = "Required")] public string? Questions10 { get; set; }


    [Required(ErrorMessage = "Required")] public string? Questions11 { get; set; }


    [Required(ErrorMessage = "Required")] public string? Questions12 { get; set; }

    [Required(ErrorMessage = "Required")] public string? Questions13 { get; set; }


    [Required(ErrorMessage = "Required")] public string? Question1EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions2EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions3EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions4EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions5EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions6EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions7EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions8EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions9EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions10EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions11EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions12EN { get; set; }
    [Required(ErrorMessage = "Required")] public string? Questions13EN { get; set; }


    [Required(ErrorMessage = "Required")] public string? OpenQuestionAr { get; set; }
    [Required(ErrorMessage = "Required")] public string? OpenQuestionEn { get; set; }


    public ICollection<FormEntry> FormEntries { get; set; } = new List<FormEntry>();

    [Required(ErrorMessage = "Required")] public DateTime CreationDate { get; init; } = DateTime.Now;
}
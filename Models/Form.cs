using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace feedback.Models;

public class Form
{
    public int id { get; set; }


    [Required(ErrorMessage = "required")] public string? FormTitleAr { get; set; }
    [Required(ErrorMessage = "required")] public string? FormTitleEn { get; set; }

    [Required(ErrorMessage = "required")] public string? FormSectionOneLabelAr { get; set; }
    [Required(ErrorMessage = "required")] public string? FormSectionOneLabelEn { get; set; }
    [Required(ErrorMessage = "required")] public string? FormSectionTwoLabelAr { get; set; }
    [Required(ErrorMessage = "required")] public string? FormSectionTwoLabelEn { get; set; }
    [Required(ErrorMessage = "required")] public string? FormSectionThreeLabelAr { get; set; }
    [Required(ErrorMessage = "required")] public string? FormSectionThreeLabelEn { get; set; }

    [Required(ErrorMessage = "required")] public string? Question1 { get; set; }

    [Required(ErrorMessage = "required")] public string? Question2 { get; set; }

    [Required(ErrorMessage = "required")] public string? Question3 { get; set; }

    [Required(ErrorMessage = "required")] public string? Question4 { get; set; }

    [Required(ErrorMessage = "required")] public string? Question5 { get; set; }

    [Required(ErrorMessage = "required")] public string? Question6 { get; set; }

    [Required(ErrorMessage = "required")] public string? Question7 { get; set; }

    [Required(ErrorMessage = "required")] public string? Question8 { get; set; }

    [Required(ErrorMessage = "required")] public string? Question9 { get; set; }

    [Required(ErrorMessage = "required")] public string? Question10 { get; set; }

    public string? Question11 { get; set; }
    public string? Question12 { get; set; }
    public string? Question13 { get; set; }


    [Required(ErrorMessage = "required")] public string? Question1EN { get; set; }
    [Required(ErrorMessage = "required")] public string? Question2EN { get; set; }
    [Required(ErrorMessage = "required")] public string? Question3EN { get; set; }
    [Required(ErrorMessage = "required")] public string? Question4EN { get; set; }
    [Required(ErrorMessage = "required")] public string? Question5EN { get; set; }
    [Required(ErrorMessage = "required")] public string? Question6EN { get; set; }
    [Required(ErrorMessage = "required")] public string? Question7EN { get; set; }
    [Required(ErrorMessage = "required")] public string? Question8EN { get; set; }
    [Required(ErrorMessage = "required")] public string? Question9EN { get; set; }
    [Required(ErrorMessage = "required")] public string? Question10EN { get; set; }
    
    public string? Question11EN { get; set; }
    public string? Question12EN { get; set; }
    public string? Question13EN { get; set; }

    [Required(ErrorMessage = "required")] public string? OpenQuestionAr { get; set; }
    [Required(ErrorMessage = "required")] public string? OpenQuestionEn { get; set; }


    public ICollection<FormEntry> FormEntries { get; set; } = new List<FormEntry>();

    [Required(ErrorMessage = "required")] public DateTime? CreationDate { get; init; } = DateTime.Now;
    
    [Required(ErrorMessage = "required")] public DateTime? StartDate { get; init; } = DateTime.Now;
    [Required(ErrorMessage = "required")] public DateTime? EndDate { get; init; } = DateTime.Now;
    
    public DateTime? UpdateDate { get; init; } = DateTime.Now;
}
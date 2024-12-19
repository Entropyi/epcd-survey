using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace feedback.Models;

public class Form
{
    public int id { get; set; }


    [Required] public string? FormTitleAr { get; set; }
    [Required] public string? FormTitleEn { get; set; }

    [Required] public string? FormSectionOneLabelAr { get; set; }
    [Required] public string? FormSectionOneLabelEn { get; set; }
    [Required] public string? FormSectionTwoLabelAr { get; set; }
    [Required] public string? FormSectionTwoLabelEn { get; set; }
    [Required] public string? FormSectionThreeLabelAr { get; set; }
    [Required] public string? FormSectionThreeLabelEn { get; set; }

    [Required] public string? Question1 { get; set; }

    [Required] public string? Question2 { get; set; }

    [Required] public string? Question3 { get; set; }

    [Required] public string? Question4 { get; set; }

    [Required] public string? Question5 { get; set; }

    [Required] public string? Question6 { get; set; }

    [Required] public string? Question7 { get; set; }

    [Required] public string? Question8 { get; set; }

    [Required] public string? Question9 { get; set; }

    [Required] public string? Question10 { get; set; }

    public string? Question11 { get; set; }
    public string? Question12 { get; set; }
    public string? Question13 { get; set; }


    [Required] public string? Question1EN { get; set; }
    [Required] public string? Question2EN { get; set; }
    [Required] public string? Question3EN { get; set; }
    [Required] public string? Question4EN { get; set; }
    [Required] public string? Question5EN { get; set; }
    [Required] public string? Question6EN { get; set; }
    [Required] public string? Question7EN { get; set; }
    [Required] public string? Question8EN { get; set; }
    [Required] public string? Question9EN { get; set; }
    [Required] public string? Question10EN { get; set; }
    
    public string? Question11EN { get; set; }
    public string? Question12EN { get; set; }
    public string? Question13EN { get; set; }

    [Required] public string? OpenQuestionAr { get; set; }
    [Required] public string? OpenQuestionEn { get; set; }


    public ICollection<FormEntry> FormEntries { get; set; } = new List<FormEntry>();

    [Required] public DateTime? CreationDate { get; init; } = DateTime.Now;
    
    public DateTime? UpdateDate { get; init; } = DateTime.Now;
}
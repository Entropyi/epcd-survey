using System.ComponentModel.DataAnnotations;

namespace feedback.Models;

public class Form
{
    public int id { get; set; }
    
    [Required(ErrorMessage = "Required")]
    public string? name { get; set; }
    
    public enum FormCategory
    {
        Community,
        industry,
    }
    
    [Required(ErrorMessage = "Required")]
    public FormCategory? Category { get; set; }
    
    
    public string? Question1 { get; set; }
    public string? Questions2 { get; set; }
    public string? Questions3 { get; set; }
    public string? Questions4 { get; set; }
    public string? Questions5 { get; set; }
    public string? Questions6 { get; set; }
    public string? Questions7 { get; set; }
    public string? Questions8 { get; set; }
    public string? Questions9 { get; set; }
    public string? Questions10 { get; set; }
    public string? Questions11 { get; set; }
    public string? Questions12 { get; set; }
    public string? Questions13 { get; set; }

    
    public string? Question1EN { get; set; }
    public string? Questions2EN { get; set; }
    public string? Questions3EN { get; set; }
    public string? Questions4EN { get; set; }
    public string? Questions5EN { get; set; }
    public string? Questions6EN { get; set; }
    public string? Questions7EN { get; set; }
    public string? Questions8EN { get; set; }
    public string? Questions9EN { get; set; }
    public string? Questions10EN { get; set; }
    public string? Questions11EN { get; set; }
    public string? Questions12EN { get; set; }
    public string? Questions13EN { get; set; }

    

    /*
    public ICollection<FormEntry> FormEntrys { get; init; }
*/
    public string CreationDate { get; init; } = DateTime.Now.ToString("MM/dd/yyyy-hh:mm:ss");

}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace feedback.Models;

public class Request
{
    public enum AgeGroups
    {
        Lessthan25,
        أقلمن25
    }

    [Required(ErrorMessage = "Required")] public AgeGroups AgeGroup { get; set; }


    public int Id { get; set; }

    [Required(ErrorMessage = "Required")]
    [MinLength(10, ErrorMessage = "InvalidNameLengthMin")]
    [MaxLength(29, ErrorMessage = "InvalidNameLengthMax")]
    public string FullNameInArabic { get; set; }

    [Required(ErrorMessage = "Required")]
    [MinLength(10, ErrorMessage = "InvalidNameLengthMin")]
    [MaxLength(29, ErrorMessage = "InvalidNameLengthMax")]
    public string FullNameInEnglish { get; set; }

    [Required(ErrorMessage = "Required")]
    [RegularExpression(@"^05[0-9]{8}$", ErrorMessage = "InvalidPhoneNumber")]
    [MinLength(10, ErrorMessage = "PhoneNumberLength")]
    [MaxLength(10, ErrorMessage = "PhoneNumberLength")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Required")]
    [EmailAddress(ErrorMessage = "InvalidEmail")]

    public string Email { get; set; }

    [Required(ErrorMessage = "Required")] public string Nationality { get; set; }


    [Required(ErrorMessage = "Required")] public DateOnly? DateOfBirth { get; set; }

    [Required(ErrorMessage = "Required")]
    [MinLength(5, ErrorMessage = "InvalidIdeaNameLengthMin")]
    [MaxLength(15, ErrorMessage = "InvalidIdeaNameLengthMax")]
    public string? IdeaName { get; set; }

    [Required(ErrorMessage = "Required")]
    [MinLength(5, ErrorMessage = "InvalidIdeaDescriptionLenghtMin")]
    public string? IdeaDescription { get; set; }

    [Required(ErrorMessage = "Required")]
    [MinLength(5, ErrorMessage = "InvalidPhoneNumberLengthMin")]
    [MaxLength(25, ErrorMessage = "InvalidPhoneNumberLengthMax")]
    public string? TeamName { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.Now;

    [BindProperty] public string? Ge { get; init; } // Removed the semicolon here

// Property to return an array of validation error codes
    public string[] Ges => new[]
    {
        "Required", "InvalidPhoneNumberLengthMax", "InvalidIdeaNameLengthMin"
    };
}
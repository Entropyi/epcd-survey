﻿using System.ComponentModel.DataAnnotations;

namespace feedback.Models;

public class FormEntry
{
    public int Id { get; init; }


    public int FormId { get; init; }
    public Form Form { get; init; }


    [Required(ErrorMessage = "Required")] public int? AgeGroup { get; init; }

    [Required(ErrorMessage = "Required")] public int? Education { get; init; }

    public enum Sexes
    {
        Male,
        Female
    }

    [Required(ErrorMessage = "Required")] public Sexes Sex { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale1 { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale2 { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale3 { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale4 { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale5 { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale6 { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale7 { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale8 { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale9 { get; init; }

    [Required(ErrorMessage = "Required")] public int? Scale10 { get; init; }


    public string? OpenQuestion { get; init; } = string.Empty;


    public enum Languages
    {
        en,
        ar
    }

    [Required(ErrorMessage = "Required")] public Languages Language { get; init; }

    public enum Categories
    {
        Community,
        Indestry
    }

    [Required(ErrorMessage = "Required")] public Categories Category { get; init; }

    [Required(ErrorMessage = "Required")] public DateTime CreationDate { get; init; } = DateTime.Now;
}
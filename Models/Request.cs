using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace feedback.Models;

public class Request
{
    public enum Selection
    {
        One,
        Two,
        Three,
        Four,
    }

    [Required(ErrorMessage = "Required")] 
    public Selection AgeGroup { get; set; }


    public int Id { get; set; }
    
}
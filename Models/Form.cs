﻿using System.ComponentModel.DataAnnotations;

namespace feedback.Models
{
    public class Form
    {
        public int id { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? FormTitleAr { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? FormTitleEn { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? FormSectionOneLabelAr { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? FormSectionOneLabelEn { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? FormSectionTwoLabelAr { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? FormSectionTwoLabelEn { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? FormSectionThreeLabelAr { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? FormSectionThreeLabelEn { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question1 { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question2 { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question3 { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question4 { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question5 { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question6 { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question7 { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question8 { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question9 { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question10 { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question11 { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question12 { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question13 { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question1EN { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question2EN { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question3EN { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question4EN { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question5EN { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question6EN { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question7EN { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question8EN { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question9EN { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question10EN { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question11EN { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question12EN { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? Question13EN { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? OpenQuestionAr { get; set; }

        [Required(ErrorMessage = "required")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500 characters.")]
        public string? OpenQuestionEn { get; set; }

        public ICollection<FormEntry> FormEntries { get; set; } = new List<FormEntry>();

        [Required(ErrorMessage = "required")]
        public DateTime? CreationDate { get; init; } = DateTime.Now;

        [Required(ErrorMessage = "required")]
        public DateTime? StartDate { get; init; } = DateTime.Now;

        [Required(ErrorMessage = "required")]
        public DateTime? EndDate { get; init; } = DateTime.Now;

        public DateTime? UpdateDate { get; init; } = DateTime.Now;
    }
}

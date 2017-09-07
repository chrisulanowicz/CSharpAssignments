using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{

    public class Review : BaseEntity
    {

        public int Id { get; set; } // automatically set and incremented by MySql

        [Required(ErrorMessage="Your name is required")]
        [Display(Name="Your name")]
        public string Reviewer { get; set; }

        [Required(ErrorMessage="Name of Restaurant is required")]
        public string Restaurant { get; set; }

        [Required(ErrorMessage="I thought you were adding a review?")]
        [MinLength(10, ErrorMessage="Review must be at least 10 characters long")]
        [Display(Name="Review")]
        public string ReviewBody { get; set; }

        [Required(ErrorMessage="Please rate the restaurant")]
        [Display(Name="Star Rating")]
        public int Rating { get; set; }

        [Required(ErrorMessage="Let us know when you visited")]
        [DateInPast]
        [DisplayFormat(ApplyFormatInEditMode=true ,DataFormatString="{0:MM/dd/yyyy}")]
        [Display(Name="Date of Visit")]
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        public int Helpful { get; set; }
        public int UnHelpful { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }

}
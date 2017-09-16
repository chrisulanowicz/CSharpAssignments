using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WeddingPlanner.Models
{

    public class RegisterViewModel : BaseEntity
    {

        [Required(ErrorMessage="First name is required")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last name is required")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Username is required")]
        [MaxLength(45, ErrorMessage="UserName can't be longer than 45 characters")]
        // [IsUniqueUserName] working on this model side validation
        [Display(Name="UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Date of Birth is Required")]
        [MinAge(18, ErrorMessage="If you're not 18, better have your parent/guardian register")]
        [Display(Name="Date of Birth")]
        [DataType(DataType.Date, ErrorMessage="Please enter a valid date!")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage="Email is required")]
        [EmailAddress(ErrorMessage="Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage="Password is required")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="Confirm Password")]
        [Compare("Password", ErrorMessage="Passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }

}
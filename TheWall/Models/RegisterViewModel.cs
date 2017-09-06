using System;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
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
        [Display(Name="Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Date of Birth is Required")]
        [Display(Name="Date of Birth")]
        [DataType(DataType.Date, ErrorMessage="Please enter a valid date!")]
        public DateTime DateOfBirth { get; set; }

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
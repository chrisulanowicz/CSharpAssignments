using System;
using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models
{

    public class RegisterViewModel : BaseEntity
    {

        [Required(ErrorMessage="First name is required")]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage="First Name can only contain letters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last name is required")]
        [MinLength(2, ErrorMessage="Last name must be at least 2 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Username is required")]
        [StringLength(45,MinimumLength=3, ErrorMessage="Username must be between 3 and 45 characters long")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Date of Birth is required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage="Please enter a valid date!")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage="Email is required")]
        [EmailAddress(ErrorMessage="Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage="Password is required")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage="Passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }

}
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{

    public class User : BaseEntity
    {
        [Required (ErrorMessage="{0} is required")]
        [MinLength(4)]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        public string FirstName { get;set; }

        [Required (ErrorMessage="{0} is required!")]
        [StringLength(255,MinimumLength=4,ErrorMessage="{0} must be at least 4 characters but less than 255")]
        public string LastName { get;set; }

        [Required]
        [Range(18, 100)]
        public int Age { get;set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get;set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get;set; }
    }

}
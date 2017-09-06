using System;
using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models
{

    public class LoginViewModel : BaseEntity
    {
        [Required(ErrorMessage="Can't login without an email!")]
        [EmailAddress(ErrorMessage="Please use a valid email address")]
        public string Email { get;set; }

        [Required(ErrorMessage="Can't login without a password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
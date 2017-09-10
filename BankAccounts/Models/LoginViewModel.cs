using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{

    public class LoginViewModel : BaseEntity
    {

        [Required(ErrorMessage="Can't login without a Username!")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Can't login without a password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

}
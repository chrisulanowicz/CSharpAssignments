using System;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{

    public class LoginViewModel : BaseEntity
    {

        [Required(ErrorMessage="Can't login without a User name!")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Can't login without a password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

}
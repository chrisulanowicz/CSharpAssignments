using System;
using System.Collections.Generic;

namespace BankAccounts.Models
{

    public class User : BaseEntity
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Account> Accounts { get; set; }

        public User()
        {
            Accounts = new List<Account>();
        }

    }

}
using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{

    public enum AccountTypes
    {
        Checking=1,
        Savings,
        Retirement
    }

    public class AccountViewModel : BaseEntity
    {

        [Required(ErrorMessage="Please choose what type of account you'd like to open")]
        public AccountTypes AccountType { get; set; }

        [Range(25.00, Double.MaxValue, ErrorMessage="Initial Deposit of at least $25.00 is required")]
        [Display(Name="Initial Deposit")]
        public decimal Balance { get; set; }

    }

}
using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{

    public enum TransactionTypes
    {
        Deposit,
        Withdraw
    }
    public class TransactionViewModel : BaseEntity
    {

        [Required(ErrorMessage="Please choose the type of transaction")]
        public TransactionTypes TransactionType { get; set; }

        [Required(ErrorMessage="Please choose an amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

    }

}
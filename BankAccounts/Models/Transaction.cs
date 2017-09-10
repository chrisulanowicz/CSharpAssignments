using System;

namespace BankAccounts.Models
{

    public class Transaction : BaseEntity
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }

}
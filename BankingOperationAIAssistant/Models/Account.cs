using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperationAIAssistant.Models
{
    internal class Account
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        public Account(int id,int customerId,decimal balance)
        {
            Id = id;
            CustomerId = customerId;
            Balance = balance;
        }
    }
}

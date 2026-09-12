using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperationAIAssistant.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}

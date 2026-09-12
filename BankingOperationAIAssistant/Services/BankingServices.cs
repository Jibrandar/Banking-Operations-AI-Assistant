using BankingOperationAIAssistant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperationAIAssistant.Services
{
    internal class BankingServices
    {
        // In-memory sample data used by the AI function tools.
        List<Customer> Customers = new List<Customer>()
        {
            new(101,"Jibran"),
            new(102,"Khawar"),
            new(103,"Anees"),
            new(104,"Shaib"),
            new(105,"Amaan")
        };

        List<Account> Accounts = new List<Account>()
        {
            new(01,101,20000m),
            new(02,102,40000m),
            new(03,103,50000m),
            new(04,104,90000m),
            new(05,105,120000m)
        };

        /// <summary>Returns the customer for the supplied identifier, if one exists.</summary>
        public Customer? GetCustomerById(int id)
        {
            foreach (var customer in Customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        /// <summary>Returns an account balance; null indicates that the account was not found.</summary>
        public decimal? GetAccountBalance(int accountid)
        {
            foreach (var account in Accounts)
            {
                if (account.Id == accountid)
                {
                    return account.Balance;
                }
            }

            return null;
        }

        /// <summary>Returns the combined balance only when both accounts exist.</summary>
        public decimal? GetTotalBalance(int accountId1,int accountId2)
        {
            Account account1 = null;
            Account account2 = null;
            foreach (var item in Accounts)
            {
                if (item.Id == accountId1 )
                {
                    account1 = item;
                }
               
                if (item.Id == accountId2)
                {
                    account2 = item;
                }
            }

            if(account1 is null || account2 is null)
            {
                return null;
            }
            

            decimal TotalBalance = account1.Balance + account2.Balance;
            return TotalBalance;

        }

        /// <summary>Finds the customer associated with an account, if the account exists.</summary>
        public Customer? FindAccountOwner(int accountId)
        {
            Customer customer = null;
            foreach(var account in Accounts)
            {
                if (account.Id == accountId)
                {
                    customer = GetCustomerById(account.CustomerId);
                    return customer;
                    
                }


            }
            return null;

        }

        

    }
}

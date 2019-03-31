using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.ViewModels
{
    public class AccountCustomerViewModel
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public Customer Customer { get; set; }
        public List<Account> Accounts { get; set; }
    }
}

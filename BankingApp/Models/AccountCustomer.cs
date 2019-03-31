using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class AccountCustomer
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public Customer Customer { get; set; }
        public Account Account { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class CC_Transactions
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string MerchantDetails { get; set; }
    }
}

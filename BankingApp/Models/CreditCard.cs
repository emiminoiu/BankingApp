using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        [Range(0, 100000)]
        public decimal Maximum_Limit { get; set; }
        public DateTime Expire_Date { get; set; }
        public virtual List<CC_Transactions> CC_Transactions { get; set; }
        public CreditCard()
        {
            this.CC_Transactions = CC_Transactions;
        }

    }
}

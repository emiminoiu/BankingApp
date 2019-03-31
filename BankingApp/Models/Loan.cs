using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int Duration_in_Months { get; set; }
        public DateTime Loan_Start_Date { get; set; }
        public decimal AmountTaken { get; set; }
        public decimal AmountRepaid { get; set; }

    }
}

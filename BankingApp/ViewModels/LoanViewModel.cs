using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.ViewModels
{
    public class LoanViewModel
    {
        [Display(Name = "Receiver First Name")]
        public string ReceiverFirstName { get; set; }
        [Display(Name = "Receiver Last Name")]
        public string ReceiverLastName { get; set; }
        [Display(Name = "Id Account")]
        public int AccountId { get; set; }
        public int Duration_in_Months { get; set; }
        public DateTime Loan_Start_Date { get; set; }
        public decimal AmountTaken { get; set; }
     
    }
}

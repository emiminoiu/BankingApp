using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.ViewModels
{
    public class DepositViewModel
    {
        [Display(Name = "Client First Name")]
        public string ClientFirstName { get; set; }
        [Display(Name = "Client Last Name")]
        public string ClientLastName { get; set; }
        [Display(Name = "Id Account")]
        public int AccountId { get; set; }
        [Display(Name = "Amount Deposited")]
        public decimal Amount { get; set; }
    }
}


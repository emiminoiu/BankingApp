using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.ViewModels
{
    public class TransferViewModel
    {
        [Display(Name = "From Account Id")]
        public int SenderIdAccount { get; set; }
        [Display(Name = "To Account Id")]
        public int ReceiverIdAccount { get; set; }
        [Display(Name = "Sender First Name")]
        public string SenderFirstName { get; set; }
        [Display(Name = "Sender Last Name")]
        public string SenderLastName { get; set; }     
        public decimal Amount { get; set; }
    }
}

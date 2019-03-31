using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public enum Account_Types
    {
        Normal,
        Silver,
        Gold,
        Master
    }
    public class Account
    {
        public int Id { get; set; }
        [Display(Name = "Account Balance")]
        [Range(0, 1000000)]
        public Decimal Account_Balance { get; set; }
        [Display(Name = "Date Opened")]
        public DateTime DateOpened { get; set; }
        [Display(Name = "Account Type")]
        public Account_Types Account_Type { get; set; }
        [Display(Name = "Owner First Name")]
        public string OwnerFirstName { get; set; }
        [Display(Name = "Owner Last Name")]
        public string OwnerLastName { get; set; }
        //public virtual List<Customer> Customers { get; set; }
        //public Account()
        //{
        //    this.Customers = Customers;
        //}

    }
}

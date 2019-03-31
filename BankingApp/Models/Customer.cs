using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        [StringLength(20)]
        public string Sex { get; set; }
        public virtual List<Loan> Loans { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
        public virtual List<CreditCard> CreditCards { get; set; }
        public virtual List<Account> Accounts { get; set; }
        public Customer()
        {
            this.Loans = Loans;
            this.Transactions = Transactions;
            this.CreditCards = CreditCards;
            this.Accounts = Accounts;
        }
    }
}

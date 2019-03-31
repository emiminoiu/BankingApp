using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public enum TransactionType
    {
        Transfer,
        Deposit,
        Loan
    }
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Transaction_Date { get; set; }
    }
}

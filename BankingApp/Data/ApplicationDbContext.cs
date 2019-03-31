using System;
using System.Collections.Generic;
using System.Text;
using BankingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<CC_Transactions> cc_Transactions { get; set; }
        public DbSet<CreditCard> creditCards { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Loan> loans { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        
    }
}

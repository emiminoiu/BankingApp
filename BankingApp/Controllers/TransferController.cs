using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApp.Data;
using BankingApp.Models;
using BankingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Controllers
{
    public class TransferController : Controller
    {
        // private UserManager<Customer> _userManager;
        private readonly ApplicationDbContext _context;
        List<string> transactions = new List<string>();
        public TransferController(ApplicationDbContext context)
        {
            _context = context;
            //_userManager = userManager;

        }
        [Authorize]
        public IActionResult SelectTransactionType()
        {
            transactions.Add("Transfer");
            transactions.Add("Deposit");
            transactions.Add("Loan");
            transactions.Add("Withdrawal");
            TransactionTypes model = new TransactionTypes()
            {
                TransTypes = transactions
            };
            return View(model);
        }
        [Authorize]
        public IActionResult GoToTransferPage(string selection)
        {
            TransferViewModel model = new TransferViewModel();
            // var user = await _userManager.GetUserAsync(User);
            if (selection == "Transfer")
                return View("Transfer", model);
            if (selection == "Loan")
                return View("Loan");
            if (selection == "Deposit")
                return View("Deposit");
            if (selection == "Withdrawal")
                return View("Withdrawal");
            return null;
        }
        [Authorize]
        public async Task<IActionResult> MakeALoan(LoanViewModel loan)
        {
            Customer customer = new Customer();
            customer = await _context.customers.FirstOrDefaultAsync(c => c.FirstName == loan.ReceiverFirstName && c.LastName == loan.ReceiverLastName);
            if (customer == null)
                return NotFound();
            var accounts = await _context.accounts.ToListAsync();
            bool transaction_success = false;
            foreach (var receiver_account in accounts)
            {
                if (receiver_account.Id.Equals(loan.AccountId))
                {
                    transaction_success = true;
                    receiver_account.Account_Balance += loan.AmountTaken;
                    break;                   
                }
            }
            if (transaction_success)
            {
                await _context.SaveChangesAsync();
                return View("Success");
            }
            return View("Failed");

        }
        [Authorize]
        public async Task<IActionResult> MakeAWithdrawal(WithdrawalViewModel withdrawal)
        {
            Customer customer = new Customer();
            customer = await _context.customers.FirstOrDefaultAsync(c => c.FirstName == withdrawal.ClientFirstName && c.LastName == withdrawal.ClientLastName);
            if (customer == null)
                return NotFound();
            var accounts = await _context.accounts.ToListAsync();
            bool transaction_success = false;
            foreach (var client_account in accounts)
            {
                if (client_account.Id.Equals(withdrawal.AccountId))
                {
                    if (client_account.Account_Balance >= withdrawal.Amount)
                    {
                        transaction_success = true;
                        client_account.Account_Balance -= withdrawal.Amount;
                        break;
                    }
                }
            }
            if (transaction_success)
            {
                await _context.SaveChangesAsync();
                return View("Success");
            }
            return View("Failed");

        }
        [Authorize]
        public async Task<IActionResult> MakeADeposit(DepositViewModel deposit)
        {
            Customer customer = new Customer();
            customer = await _context.customers.FirstOrDefaultAsync(c => c.FirstName == deposit.ClientFirstName && c.LastName == deposit.ClientLastName);
            if (customer == null)
                return NotFound();
            var accounts = await _context.accounts.ToListAsync();
            bool transaction_success = false;
            foreach (var client_account in accounts)
            {
                if (client_account.Id.Equals(deposit.AccountId))
                {
                   
                        transaction_success = true;
                        client_account.Account_Balance += deposit.Amount;
                        break;
                    
                }
            }
            if (transaction_success)
            {
                await _context.SaveChangesAsync();
                return View("Success");
            }
            return View("Failed");

        }
        [Authorize]
        public async Task<IActionResult> MakeATransfer(TransferViewModel transfer)
        {
            Customer customer = new Customer();
            customer = await _context.customers.FirstOrDefaultAsync(c => c.FirstName == transfer.SenderFirstName && c.LastName == transfer.SenderLastName);
            if (customer == null)
                return NotFound();
            var accounts = await _context.accounts.ToListAsync();
            bool transaction_success = false;
            foreach (var sender_account in customer.Accounts)
            {
                if (sender_account.Id.Equals(transfer.SenderIdAccount))
                {
                    if (sender_account.Account_Balance >= transfer.Amount)
                    {
                      
                        foreach (var receiver_account in accounts)
                        {
                            if (receiver_account.Id.Equals(transfer.ReceiverIdAccount))
                            {
                                receiver_account.Account_Balance += transfer.Amount;                                
                                transaction_success = true;
                                break;
                            }
                        }
                        if(transaction_success)
                        {
                            sender_account.Account_Balance -= transfer.Amount;                        
                        }
                    }
                }
            }
            if (transaction_success)
            {
                await _context.SaveChangesAsync();
                return View("Success");               
            }
            return View("Failed");

        }

    }
}
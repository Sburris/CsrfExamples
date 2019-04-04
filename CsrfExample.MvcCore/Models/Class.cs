using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsrfExamples.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CsrfExample.MvcCore.Models
{
    public class IndexViewModel
    {
        public List<SelectListItem> ddlAccounts { get; set; }
        public List<AccountViewModel> Accounts { get; set; }
        public List<TransactionViewModel> Transactions { get; set; }

        public IndexViewModel(DataStore dataStore)
        {
            Accounts = new List<AccountViewModel>();
            Transactions = new List<TransactionViewModel>();
            ddlAccounts = new List<SelectListItem> { new SelectListItem() { Selected = true, Text = "-- Select Account --", Value = "-1" } };
            ddlAccounts.AddRange(new SelectList(dataStore.BankAccounts, "Id", "Name"));

            dataStore.BankAccounts.ForEach(b => Accounts.Add(new AccountViewModel(b)));
            dataStore.Transactions.ForEach(t => Transactions.Add(new TransactionViewModel(t)));

            if (Transactions.Count == 0)
            {
                Transactions.Add(new TransactionViewModel() { DateTime = "", Description = "No Transactions at this time." });
            }
        }
    }

    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Balance { get; set; }

        public AccountViewModel(BankAccount account)
        {
            Id = account.Id;
            Name = account.Name;
            Balance = account.Balance.ToString("C");
        }
    }

    public class TransactionViewModel
    {
        public TransactionViewModel(Transaction transaction)
        {
            DateTime = transaction.DateTime.ToString("HH");
            Description = transaction.Description;
        }

        public TransactionViewModel()
        {

        }

        public string DateTime { get; set; }
        public string Description { get; set; }
    }

    public class ProcessTransferViewModel
    {
        [Required]
        public int ToAccount { get; set; }

        [Required]
        public int FromAccount { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}

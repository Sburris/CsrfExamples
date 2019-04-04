using System;
using System.Collections.Generic;
using System.Linq;

namespace CsrfExamples.Data
{
    public class DataStore
    {
        private DataStore()
        {
            BankAccounts.Add(new BankAccount{Id = 1001, Name = "Alice", Balance = 1000m});
            BankAccounts.Add(new BankAccount{Id = 1002, Name = "Bob", Balance = 1000m});
            BankAccounts.Add(new BankAccount{Id = 1003, Name = "Eve", Balance = 1000m});
        }

        private static DataStore _instance;

        public static DataStore Instance => _instance ?? (_instance = new DataStore());

        public List<BankAccount> BankAccounts = new List<BankAccount>();

        public List<Transaction> Transactions = new List<Transaction>();

        public decimal GetBalance(int id)
        {
            Transactions.Add(new Transaction($"Retrieved balance for {id} [{BankAccounts[id].Name}]"));
            return BankAccounts[id].Balance;
        }

        public void TransferFunds(int fromId, int toId, decimal amount)
        {
            var toAccount = BankAccounts.Single(b => b.Id == toId);
            var fromAccount = BankAccounts.Single(b => b.Id == fromId);

            toAccount.Balance += amount;
            fromAccount.Balance -= amount;

            Transactions.Add(new Transaction($"Transfered ${amount} from {fromId} [{fromAccount.Name}] to {toId} [{toAccount.Name}]."));
        }
    }

    public class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }

    public class Transaction
    {
        public DateTime DateTime { get; set; }
        public string Description { get; set; }

        public Transaction(string description)
        {
            DateTime = DateTime.UtcNow;
            Description = description;
        }
    }
}
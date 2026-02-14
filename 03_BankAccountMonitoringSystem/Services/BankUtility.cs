using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class BankUtility
    {
        public static SortedDictionary<decimal, List<Bank>> BankEntities = new SortedDictionary<decimal, List<Bank>>();

        public void AddEntity(Bank entity)
        {
            // TODO: Validate entity
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
            if(entity.Balance < 0)
            {
                throw new NegativeBalanceException("Balance cannot be negative.");
            }
            decimal key = entity.Balance;
            if (!BankEntities.ContainsKey(key))
            {
                BankEntities[key] = new List<Bank>();
            }
            BankEntities[key].Add(entity);
        }

        public void Deposit(decimal amount,string accountNumber)
        {
            // TODO: Update entity logic
            if(amount<0) throw new NegativeBalanceException("amount must be positive");
            var check = BankEntities.SelectMany(i=>i.Value).FirstOrDefault(g=>g.AccountNumber==accountNumber);
            if (check == null)
            {
                throw new AccountNotFoundException("Not account Found");
            }
            BankEntities[check.Balance].Remove(check);
            if (!BankEntities.ContainsKey(amount))
            {
                BankEntities[amount]= new List<Bank>();
            }
            BankEntities[amount].Add(new Bank(check.AccountNumber, check.HolderName, amount));
        }
        public void GetAll()
        {
            // TODO: Return sorted entities
            foreach (var entry in BankEntities)
            {
                foreach (var bank in entry.Value)
                {
                    System.Console.WriteLine($"Bank Name: {bank.HolderName}, Balance: {bank.Balance}");
                }
            }
        }
    }
}

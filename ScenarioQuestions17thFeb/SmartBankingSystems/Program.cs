using System;
using System.Collections.Generic;
using System.Linq;

class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message) { }
}

class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string message) : base(message) { }
}

abstract class BankAccount
{
    public int AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public double Balance { get; set; }

    public List<string> TransactionHistory = new List<string>();

    public BankAccount(int accNo, string name, double balance)
    {
        AccountNumber = accNo;
        CustomerName = name;
        Balance = balance;
    }

    public virtual void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            TransactionHistory.Add($"Deposited: {amount}");
        }
    }

    public virtual void Withdraw(double amount)
    {
        if (amount > Balance)
            throw new InsufficientBalanceException("Insufficient balance");

        Balance -= amount;
        TransactionHistory.Add($"Withdrawn: {amount}");
    }

    public abstract double CalculateInterest();

    public void ShowDetails()
    {
        Console.WriteLine($"{AccountNumber} | {CustomerName} | {Balance}");
    }
}

class SavingsAccount : BankAccount
{
    public double MinimumBalance { get; set; }

    public SavingsAccount(int accNo, string name, double balance, double minBal)
        : base(accNo, name, balance)
    {
        MinimumBalance = minBal;
    }

    public override void Withdraw(double amount)
    {
        if (Balance - amount < MinimumBalance)
            throw new MinimumBalanceException("Minimum balance violation");

        base.Withdraw(amount);
    }

    public override double CalculateInterest()
    {
        // TODO: Savings interest logic

        return Balance*0.04;
    }
}

class CurrentAccount : BankAccount
{
    public double OverdraftLimit { get; set; }

    public CurrentAccount(int accNo, string name, double balance, double limit)
        : base(accNo, name, balance)
    {
        OverdraftLimit = limit;
    }

    public override void Withdraw(double amount)
    {
        if (Balance + OverdraftLimit < amount)
            throw new InsufficientBalanceException("Overdraft limit exceeded");

        Balance -= amount;
        TransactionHistory.Add($"Withdrawn: {amount}");
    }

    public override double CalculateInterest()
    {
        // TODO: Current account interest logic
        return Balance*0.01;
    }
}

class LoanAccount : BankAccount
{
    public LoanAccount(int accNo, string name, double balance)
        : base(accNo, name, balance) { }

    public override void Deposit(double amount)
    {
        throw new InvalidTransactionException("Cannot deposit into loan account");
    }

    public override double CalculateInterest()
    {
        // TODO: Loan interest logic
        return Balance*0.12;
    }
}

class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();

    static void TransferFunds(BankAccount from, BankAccount to, double amount)
    {
        from.Withdraw(amount);
        to.Deposit(amount);

        from.TransactionHistory.Add($"Transferred {amount} to {to.AccountNumber}");
        to.TransactionHistory.Add($"Received {amount} from {from.AccountNumber}");
    }


    static void RunLINQQueries()
    {
        // 1. Accounts with balance > 50000
        var highBalance = accounts.Where(a => a.Balance > 50000);
        foreach (var acc in highBalance)
            acc.ShowDetails();

        // 2. Total bank balance
        double total = accounts.Sum(a => a.Balance);
        Console.WriteLine($"Total Bank Balance: {total}");

        // 3. Top 3 accounts
        var top3 = accounts
            .OrderByDescending(a => a.Balance)
            .Take(3);

        foreach (var acc in top3)
            acc.ShowDetails();

        // 4. Group by account type
        var groups = accounts.GroupBy(a => a.GetType().Name);
        foreach (var g in groups)
            Console.WriteLine($"{g.Key}: {g.Count()} accounts");

        // 5. Customers starting with 'R'
        var customersR = accounts
            .Where(a => a.CustomerName.StartsWith("R"));

        foreach (var acc in customersR)
            Console.WriteLine(acc.CustomerName);
    }

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Add Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer Funds");
            Console.WriteLine("5. Run LINQ Reports");
            Console.WriteLine("6. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                    Console.WriteLine("Select Account Type:");
                    Console.WriteLine("1. Savings");
                    Console.WriteLine("2. Current");
                    Console.WriteLine("3. Loan");

                    int type = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Account Number: ");
                    int accNo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Customer Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Initial Balance: ");
                    double balance = Convert.ToDouble(Console.ReadLine());

                    if (type == 1)
                    {
                        Console.Write("Minimum Balance: ");
                        double minBal = Convert.ToDouble(Console.ReadLine());

                        accounts.Add(new SavingsAccount(accNo, name, balance, minBal));
                    }
                    else if (type == 2)
                    {
                        Console.Write("Overdraft Limit: ");
                        double limit = Convert.ToDouble(Console.ReadLine());

                        accounts.Add(new CurrentAccount(accNo, name, balance, limit));
                    }
                    else if (type == 3)
                    {
                        accounts.Add(new LoanAccount(accNo, name, balance));
                    }

                    Console.WriteLine("Account created successfully.");
                    break;
                    case 2:
                        Console.Write("Enter Account Number: ");
                        int depAcc = Convert.ToInt32(Console.ReadLine());

                        var accountToDeposit = accounts
                            .FirstOrDefault(a => a.AccountNumber == depAcc);

                        if (accountToDeposit == null)
                        {
                            Console.WriteLine("Account not found.");
                            break;
                        }

                        Console.Write("Enter amount to deposit: ");
                        double depAmount = Convert.ToDouble(Console.ReadLine());

                        accountToDeposit.Deposit(depAmount);
                        Console.WriteLine("Deposit successful.");
                        break;
                    case 3:
                        Console.Write("Enter Account Number: ");
                        int witAcc = Convert.ToInt32(Console.ReadLine());

                        var accountToWithdraw = accounts
                            .FirstOrDefault(a => a.AccountNumber == witAcc);

                        if (accountToWithdraw == null)
                        {
                            Console.WriteLine("Account not found.");
                            break;
                        }

                        Console.Write("Enter amount to withdraw: ");
                        double witAmount = Convert.ToDouble(Console.ReadLine());

                        accountToWithdraw.Withdraw(witAmount);
                        Console.WriteLine("Withdrawal successful.");
                        break;
                    case 4:
                        Console.Write("From Account Number: ");
                        int fromAccNo = Convert.ToInt32(Console.ReadLine());

                        Console.Write("To Account Number: ");
                        int toAccNo = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Amount to transfer: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        var fromAccount = accounts
                            .FirstOrDefault(a => a.AccountNumber == fromAccNo);

                        var toAccount = accounts
                            .FirstOrDefault(a => a.AccountNumber == toAccNo);

                        if (fromAccount == null || toAccount == null)
                        {
                            Console.WriteLine("Invalid account number.");
                            break;
                        }

                        TransferFunds(fromAccount, toAccount, amount);
                        Console.WriteLine("Transfer successful.");
                        break;
                    case 5:
                        RunLINQQueries();
                        break;

                    case 6:
                        running = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

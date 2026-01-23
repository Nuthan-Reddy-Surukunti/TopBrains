class Account
{
   public string AccountNumber { get; set; }
   public decimal Balance { get; set; }
   public Account(string accountNumber, decimal initialBalance)
   {
      AccountNumber = accountNumber;
      Balance = initialBalance;
   }
   public decimal Deposit(decimal amount)
   {
      try
      {
         if (amount <= 0)
         {
            throw new ArgumentException("Deposit amount must be positive.");
         }
         Balance += amount;
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.Message);
      }
      return Balance;
   }
   public decimal Withdraw(decimal amount)
   {
      try
      {
         if (amount <= 0)
         {
            throw new ArgumentException("Withdrawal amount must be positive.");
         }
         if (amount > Balance)
         {
            throw new InvalidOperationException("Insufficient funds.");
         }
         Balance -= amount;
      }
      catch (ArgumentException ex)
      {
         Console.WriteLine(ex.Message);
      }
      catch (InvalidOperationException ex)
      {
         Console.WriteLine(ex.Message);
      }
      return Balance;
   }
}
class Program
{
   public static void Main()
   {
      Console.WriteLine("1. Deposit");
      Console.WriteLine("2. Withdraw");
      Console.Write("Enter your choice: ");
      string choice = Console.ReadLine();
      Console.Write("Enter account number: ");
      string accountNumber = Console.ReadLine();
      Console.Write("Enter initial balance: ");
      decimal initialBalance = decimal.Parse(Console.ReadLine() ?? "0");
      Account account = new Account(accountNumber, initialBalance);
      Console.Write("Enter transaction amount: ");
      decimal amount = decimal.Parse(Console.ReadLine() ?? "0");
      decimal finalBalance;
      if (choice == "1")
      {
         finalBalance = account.Deposit(amount);
      }
      else if (choice == "2")
      {
         finalBalance = account.Withdraw(amount);
      }
      else
      {
         Console.WriteLine("Invalid choice.");
         return;
      }
      Console.WriteLine($"Final balance: {finalBalance}");
   }
}

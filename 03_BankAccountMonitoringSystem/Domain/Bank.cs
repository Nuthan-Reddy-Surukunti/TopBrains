namespace Domain
{
    public class Bank
    {
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }
        public Bank(string accountNumber, string holderName, decimal balance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = balance;
        }
    }
}

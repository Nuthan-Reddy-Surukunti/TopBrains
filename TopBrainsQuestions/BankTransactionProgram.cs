// public class BankAccount
// {
//     public int Balance { get; set; }
//     public int transaction(int[] arr)
//     {
//         foreach(int i in arr)
//         {
//             if (i > 0)
//             {
//                 Balance+=i;
//             }
//             else
//             {
//                 if (Balance >= -i)
//                 {
//                     Balance+=i;
//                 }
//             }
//         }
//         return Balance;
//     }
//     public static void Main()
//     {
//         Console.WriteLine("Enter initial balance: ");
//         int initialBalance = Convert.ToInt32(Console.ReadLine());
//         BankAccount bankAccount1 = new BankAccount(){Balance = initialBalance};
//         Console.WriteLine("Enter total number of transactions:");
//         int total = Convert.ToInt32(Console.ReadLine());
//         int[] transactions = new int[total];
//         Console.WriteLine("postive for deposite and negative for withdraw!");
//         for(int i = 0; i < total; i++)
//         {
//             Console.WriteLine($"Enter Transaction {i+1}:");
//             transactions[i]=Convert.ToInt32(Console.ReadLine());
//         }
//         int finalBalance =bankAccount1.transaction(transactions);
//         Console.WriteLine($"Your Final Balance: {finalBalance}");

//     }
// }
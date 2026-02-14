// public class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine("Enter the number for multiplication:");
//         int n = Convert.ToInt32(Console.ReadLine());
//         Console.WriteLine("Enter upto: ");
//         int m = Convert.ToInt32(Console.ReadLine());
//         int[] numbers = new int[m];
//         for(int i = 1; i <= m; i++)
//         {
//             numbers[i-1] = n*i;
//         }
//         string output = string.Join(",",numbers);
//         Console.WriteLine($"[{output}]");
//     }
// }
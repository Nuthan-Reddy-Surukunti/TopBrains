
// class Question2
// {
//     public static void Main()
//     {
//         string input = Console.ReadLine();
//         string[] inpArr = input.Split(" ");
//         int m = Convert.ToInt32(inpArr[0]);
//         int n = Convert.ToInt32(inpArr[1]);
//         int count =0;
//         for(int i =m;i<=n;i++)
//         {
//             int s=SumofInput(i);
//             if (!isPrime(i))
//             {
//                 if (SumofInput(i*i) ==s*s )
//                 {
//                     count++;
//                 }
//             }
//         }
//         Console.WriteLine(count);
//     }
//     public static int SumofInput(int num)
//     {
//         string integer = num.ToString();
//         int sum=0;
//         for(int k = 0; k < integer.Length; k++)
//         {
//             sum += integer[k]-'0';
//         }
//         return sum;
//     }
//     public static bool isPrime(int num)
//     {
//         if (num < 2)
//         {
//             return false;
//         }
//         for(int i = 2; i <= Math.Sqrt(num); i++)
//         {
//             if (num % 2 == 0)
//             {
//                 return false;
//             }
//         }
//         return true;
//     }
        
    
// }
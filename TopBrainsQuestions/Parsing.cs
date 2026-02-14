// class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine("Enter upto:");
//         int total = Convert.ToInt32(Console.ReadLine());
//         Console.WriteLine("Enter the numbers to be summation:");
//         string[] tokens = new string[total];
//         for(int i = 0; i < total; i++)
//         {
//             Console.WriteLine($"Enter Number {i+1}");
//             tokens[i]=Console.ReadLine();
//         }
//         int sum=0;
//         foreach(string i in tokens)
//         {
//             if(int.TryParse(i,out int number))
//             {
//                 sum+=number;
//             }
//         }
//         Console.WriteLine("Total Sum is: "+sum);
        
//     }
// }
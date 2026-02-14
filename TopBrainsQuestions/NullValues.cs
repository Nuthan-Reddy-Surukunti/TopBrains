// class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine("Input values with space seperated.");
//         string input = Console.ReadLine();
//         string[] formatedInput = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
//         double?[] doubles = new double?[formatedInput.Count()];
//         int j=0;
//         foreach(string i in formatedInput)
//         {
//             if (i.ToLower() == "null")
//             {
//                 doubles[j]=null;
//                 j++;
//             }
//             else
//             {
//                 doubles[j]=double.Parse(i);
//                 j++;
//             }
//         }
//         double? computeAvg = CalAvg(doubles);
//         Console.WriteLine(computeAvg.HasValue?$"Average: {computeAvg}":"Average:null ");
//     }
//     public static double? CalAvg(double?[] arr)
//     {
//         double sum=0;
//         int count=0;
//         foreach(double? i in arr)
//         {
//             if (i.HasValue)
//             {
//                 sum+=i.Value;
//                 count++;
//             }
//         }
//         if(count==0) return null;
//         return Math.Round(sum/count,2,MidpointRounding.AwayFromZero);
//     }
// }
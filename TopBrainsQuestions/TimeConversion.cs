// public class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine("Enter seconds: ");
//         int sec = Convert.ToInt32(Console.ReadLine());
//         Console.WriteLine(ToMinfromSec(sec));

      
//     }
//     public static string ToMinfromSec(int sec)
//     {
//         int minute = sec/60;
//         string formatstring;
//         int minReminder = sec%60;
//         if (minReminder < 10)
//         {
//             formatstring = "0"+minReminder.ToString();
//         }
//         else
//         {
//             formatstring = minReminder.ToString();
//         }
//         string output = minute.ToString()+":"+formatstring;
//         return output;
//     }
// }
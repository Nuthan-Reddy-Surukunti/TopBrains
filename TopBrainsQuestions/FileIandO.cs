// using System.Text;
// using System.Text.RegularExpressions;
// class FileIandO
// {
//     public static void Main(string[] args)
//     {

//         string path = "log.txt";
//         string createPath = "error.txt";
//         using(StreamReader sr = new StreamReader(path))
//         using(StreamWriter sw = new StreamWriter(createPath, false, Encoding.UTF8))
//         {
//             string file;
//             while ((file = sr.ReadLine()) != null)
//             {
//                 MatchCollection match = Regex.Matches(file,@"^\[ERROR\].*");
//                 foreach(Match i in match)
//                 {
//                     sw.WriteLine(i);
//                 }
//             }
            
//         }
//     }
// }

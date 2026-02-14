// using System.Text.Json;
// class Students
// {
//     public string Name { get; set; }
//     public int Marks { get; set; }
// }
// class Program
// {
//     public static void Main()
//     {
//         string[] strings = { "John:85", "Alice:92", "Bob:85", "David:70" };
//         int minScore =80;
//         List<Students> students = ToList(strings,minScore);
//         string json = JsonSerializer.Serialize(students);
//         Console.WriteLine(json);
//     }
//     public static List<Students> ToList(string[] input,int score)
//     {
//         List<Students> result = new List<Students>();
//         foreach(string i in input)
//         {
//             string[] parts = i.Split(":");
//             result.Add(new Students{Name=parts[0],Marks=Convert.ToInt32(parts[1])});
//         }
//         return result.Where(i=>i.Marks>=score).OrderByDescending(i=>i.Marks).ThenBy(i=>i.Name).ToList();
//     }
    
// }
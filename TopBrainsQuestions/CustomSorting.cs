// using System.Collections;

// class CustomSorting
// {
//     public static void Main()
//     {
//         List<Student> liststudents = new List<Student>
//         {
//           new Student {Name = "Nuthan",Age =21,Marks = 75},
//           new Student {Name = "Amruth",Age = 20,Marks = 85},
//           new Student {Name = "Mustafiz",Age = 22,Marks = 95},
//           new Student {Name = "Ram",Age = 21,Marks = 95}
//         };
//         liststudents.Sort(new StudentComparer());
//         foreach(Student item in liststudents)
//         {
//             Console.WriteLine($"{item.Name} {item.Age} {item.Marks}");
//         }
        
//     }
// }
// public class Student
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
//     public int Marks { get; set; }
// }
// public class StudentComparer : IComparer<Student>
// {
//     public int Compare(Student x,Student y)
//     {
//         if (x.Marks != y.Marks)
//         {
//             return y.Marks.CompareTo(x.Marks);
//         }
//         return x.Age.CompareTo(y.Age);
//     }
// }
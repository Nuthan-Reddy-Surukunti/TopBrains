// class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine("Enter details to get total Area: ");
//         string intput = Console.ReadLine();
//         string[] forArea = intput.Split(",");
//         Console.WriteLine($"Total Area : {CalculateShapes(forArea)}");
//     }
//     public static double CalculateShapes(string[] strings)
//     {
//         List<Shape> shapes = new List<Shape>();
//         foreach(string i in strings)
//         {
//             string[] input = i.Split(" ");
//             string shape = input[0];
//             switch (shape)
//             {
//                 case "C":
//                     double radius = double.Parse(input[1]);
//                     shapes.Add(new Circle(radius));
//                     break;
//                 case "R":
//                     double height = double.Parse(input[2]);
//                     double width = double.Parse(input[1]);
//                     shapes.Add(new Rectangle(width,height));
//                     break;
//                 case "T":
//                     double base1 = double.Parse(input[1]);
//                     height = double.Parse(input[2]);
//                     shapes.Add(new Triangle(base1,height));
//                     break;
//             }
//         }
//         double total = Math.Round(shapes.Sum(s=>s.Area()),2,MidpointRounding.AwayFromZero);
//         return total;
//     }
// }
// interface IArea
// {
//     public abstract double Area();
// }
// public abstract class Shape:IArea
// {
//     public abstract double Area();
// }
// public class Circle : Shape
// {
//     public double Radius { get; set; }
//     public Circle(double Radius)
//     {
//         this.Radius = Radius;
//     }
//     public override double Area()
//     {
//         return Math.PI*Radius*Radius;
//     }
// }
// public class Rectangle : Shape
// {
//     public double Width { get; set; }
//     public double Height { get; set; }
//     public Rectangle(double Width,double Height)
//     {
//         this.Width = Width;
//         this.Height=Height;
//     }
//     public override double Area()
//     {
//         return Width*Height;
//     }
// }
// public class Triangle : Shape
// {
//     public double Base { get; set; }
//     public double Height { get; set; }
//     public Triangle(double b,double height)
//     {
//         Base=b;
//         Height=height;
//     }
//     public override double Area()
//     {
//         return 0.5*Base*Height;
//     }
// }

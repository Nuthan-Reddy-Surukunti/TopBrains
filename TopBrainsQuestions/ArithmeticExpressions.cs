// using System;

// class Program
// {
//     static void Main()
//     {
//         string expression = "10 + 5";

//         string result = EvaluateExpression(expression);

//         Console.WriteLine(result);
//     }

//     public static string EvaluateExpression(string s)
//     {
//         if (string.IsNullOrWhiteSpace(s))
//             return "Error:InvalidExpression";

//         string[] parts = s.Split(' ');

//         if (parts.Length != 3)
//             return "Error:InvalidExpression";

//         string left = parts[0];
//         string op = parts[1];
//         string right = parts[2];

//         if (!int.TryParse(left, out int a) || !int.TryParse(right, out int b))
//             return "Error:InvalidNumber";

//         int result;

//         switch (op)
//         {
//             case "+":
//                 result = a + b;
//                 break;

//             case "-":
//                 result = a - b;
//                 break;

//             case "*":
//                 result = a * b;
//                 break;

//             case "/":
//                 if (b == 0)
//                     return "Error:DivideByZero";

//                 result = a / b;
//                 break;

//             default:
//                 return "Error:UnknownOperator";
//         }

//         return result.ToString();
//     }
// }

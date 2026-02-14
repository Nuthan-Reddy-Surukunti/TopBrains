// public class Program
// {
    
//     public static void Main()
//     {
//         Console.WriteLine("Enter employee details: ");
//         string input = Console.ReadLine();
//         string[] inpArr = input.Split(",");
//         List<Employee> employees = new List<Employee>();
//         foreach(string i in inpArr)
//         {
//             string[] parts = i.Split(" ");
//             string type = parts[0];
//             switch (type)
//             {
//                 case "H":
//                     decimal rate = decimal.Parse(parts[1]);
//                     int hours = int.Parse(parts[2]);
//                     employees.Add(new HourlyEmployee(rate,hours));
//                     break;
//                 case "S":
//                     decimal MonthlySalary = decimal.Parse(parts[1]);
//                     employees.Add(new MonthlyEmployee(MonthlySalary));
//                     break;
//                 case "C":
//                     decimal baseSalary = decimal.Parse(parts[1]);
//                     decimal Commission = decimal.Parse(parts[2]);
//                     employees.Add(new CommissionEmployee(baseSalary,Commission));
//                     break;
//             }
//         }
//         decimal total = Math.Round(employees.Sum(s=>s.TotalPay()),2);
//         Console.WriteLine($"Total: {total}");
//     }

// }
// public abstract class Employee
// {
//     public abstract decimal TotalPay();

// }
// public class HourlyEmployee: Employee
// {
//     public decimal rate { get; set; }
//     public int hours { get; set; }
//     public HourlyEmployee(decimal rate,int hours)
//     {
//         this.rate=rate;
//         this.hours=hours;
//     }
//     public override decimal TotalPay()
//     {
//         return rate*hours;
//     }
// }
// class MonthlyEmployee : Employee
// {
//     public decimal MonthlySalary { get; set; }
//     public MonthlyEmployee(decimal monthlySalary)
//     {
//         MonthlySalary=monthlySalary;
//     }
//     public override decimal TotalPay()
//     {
//         return MonthlySalary;
//     }
// }
// class CommissionEmployee : Employee
// {
//     public decimal BaseSalary { get; set; }
//     public decimal Commission { get; set; }
//     public CommissionEmployee(decimal baseSalary,decimal Commission)
//     {
//         BaseSalary=baseSalary;
//         this.Commission=Commission;
//     }
//     public override decimal TotalPay()
//     {
//         return BaseSalary+Commission;
//     }
// }

// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace OppsApp
// {
//     class Bike
//     {
//         public string Model { get; set; }
//         public int PricePerDay { get; set; }
//         public string Brand { get; set; }
//     }
//     class BikeUtility
//     {
        
//         public void AddBikeDetails(string model,string brand,int pricePerDay)
//         {
//             Bike bike = new Bike()
//             {
//                 Model = model,
//                 PricePerDay = pricePerDay,
//                 Brand = brand
//             };
//             int Lastkey = 0;
//             if (Program.bikeDetails.Count > 0)
//             {
//                 Lastkey = Program.bikeDetails.Keys.Last();
//             }
//             Program.bikeDetails.Add(Lastkey + 1, bike);
//         }
//         public SortedDictionary<string,List<Bike>> GroupBikesByBrand()
//         {
//             var grouped = new SortedDictionary<string, List<Bike>>();
//             foreach(var i in Program.bikeDetails.Values)
//             {
//                 if (!grouped.ContainsKey(i.Brand))
//                 {
//                     grouped[i.Brand] = new List<Bike>();
//                 }
//                 grouped[i.Brand].Add(i);
//             }
//             var grou = Program.bikeDetails.GroupBy(b => b.Value.Brand)
//                 .ToDictionary(g => g.Key, g => g.Select(i => i.Value).ToList());
//             return new SortedDictionary<string, List<Bike>>(grou);

//         }
//     }
//     class Program
//     {
//         public static SortedDictionary<int,Bike> bikeDetails = new SortedDictionary<int,Bike>();
//         public static void Main(string[] args)
//         {
//             while (true)
//             {
                
//                 Bike bike = new Bike();
//                 BikeUtility bikeUtility = new BikeUtility();
//                 Console.WriteLine("1.Add Bike Details");
//                 Console.WriteLine("2.Group Bikes By Brand");
//                 Console.WriteLine("3.Exit");
//                 Console.Write("Enter your choice: ");
//                 int choice = Convert.ToInt32(Console.ReadLine());
//                 if (choice == 3) break;
//                 switch (choice)
//                 {
//                     case 1:
//                         Console.WriteLine($"Enter the model: ");
//                         string Model = Console.ReadLine();
//                         Console.WriteLine("Enter the brand: ");
//                         string Brand = Console.ReadLine();
//                         Console.WriteLine("Enter the price per day:");
//                         int PricePerDay = Convert.ToInt32(Console.ReadLine());
//                         bikeUtility.AddBikeDetails(Model, Brand, PricePerDay);
//                         Console.WriteLine("Bike details added successfully");
//                         break;
//                     case 2:
//                         if (bikeDetails.Count > 0)
//                         {
//                             foreach(var i in bikeUtility.GroupBikesByBrand())
//                             {
//                                 foreach(var j in i.Value)
//                                 {
//                                     Console.WriteLine($"{i.Key} {j.Model} {j.PricePerDay}");
//                                 }
//                             }
//                         }
//                         break;
//                     default:
//                         Console.WriteLine("Invalid choide");
//                         break;
//                 }

//             }
//         }
//     }
// }

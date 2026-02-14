using System;
using Services;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankUtility utility = new BankUtility();

            while (true)
            {
                Console.WriteLine("1. Display");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = Convert.ToInt32(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        utility.GetAll();   
                        break;
                    case 2:
                        // TODO: Add entity
                            Console.WriteLine("Enter Account Name:");
                            string accountName = Console.ReadLine();
                            Console.WriteLine("Enter Account Number:");
                            string accountNumber = Console.ReadLine();
                            Console.WriteLine("Enter Balance:");
                            decimal balance = Convert.ToDecimal(Console.ReadLine());
                            try
                            {
                                utility.AddEntity(new Bank(accountNumber, accountName, balance));
                                Console.WriteLine("Entity added successfully.");
                            }
                            catch (NegativeBalanceException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        break;
                    case 3:
                        // TODO: Update entity
                            Console.WriteLine("Enter Account Number to Update:");
                                string accNumberToUpdate = Console.ReadLine();
                                Console.WriteLine("Enter New Balance:");
                                decimal newBalance = Convert.ToDecimal(Console.ReadLine());
                                try
                                {
                                    utility.Deposit(newBalance, accNumberToUpdate);
                                    Console.WriteLine("Entity updated successfully.");
                                }
                                catch (AccountNotFoundException ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }
                                catch (NegativeBalanceException ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }
                        break;
                    case 4:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

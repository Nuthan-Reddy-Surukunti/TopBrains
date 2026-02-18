using System;
using FlexibleInventorySystem.Services;
using FlexibleInventorySystem.Domain;
using FlexibleInventorySystem.Domain.Exceptions;

namespace FlexibleInventorySystem.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new InventoryManager();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Flexible Inventory System");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1\tDisplay Inventory by Priority");
                Console.WriteLine("2\tUpdate Item Priority");
                Console.WriteLine("3\tAdd Inventory Item");
                Console.WriteLine("4\tExit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                Console.WriteLine();

                if (!int.TryParse(choice, out int option))
                {
                    Console.WriteLine("Invalid option");
                    continue;
                }

                try
                {
                    switch (option)
                    {
                        case 1:
                            // TODO: Implement display logic. Call manager.GetInventoryStatus() once implemented.
                            foreach(var i in manager.GetInventoryStatus())
                            {
                                Console.WriteLine($"{i.ItemId} {i.ItemName} {i.PriorityLevel}");
                            }
                            break;

                        case 2:
                            // TODO: Read ItemId and NewPriority from console and call manager.UpdatePriority(...)
                            Console.WriteLine("Enter ItemId:");
                            var itemId = Console.ReadLine();
                            Console.WriteLine("Enter new priority:");
                            var newPriorityStr = Console.ReadLine();
                            manager.UpdatePriority(itemId, int.Parse(newPriorityStr));
                            break;

                        case 3:
                            // TODO: Read item fields, create InventoryItem and call manager.AddItem(...)
                            Console.WriteLine("Enter ItemId:");
                            var newItemId = Console.ReadLine();
                            Console.WriteLine("Enter ItemName:");
                            var newItemName = Console.ReadLine();
                            Console.WriteLine("Enter priority:");
                            var priorityStr = Console.ReadLine();
                            var newItem = new InventoryItem(newItemId, newItemName, int.Parse(priorityStr));
                            manager.AddItem(newItem);
                            Console.WriteLine("Item added successfully");
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                catch (InvalidPriorityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ItemNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
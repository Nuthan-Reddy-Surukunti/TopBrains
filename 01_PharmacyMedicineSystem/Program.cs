using System;
using Services;
using Exceptions;
using Domain;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicineUtility utility = new MedicineUtility();

            while (true)
            {
                Console.WriteLine("1. Display");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = Convert.ToInt32(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        try{
                        utility.GetAllMedicines();}
                        catch(MedicineNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        // TODO: Update entity
                        string id = Console.ReadLine();
                        int price =Convert.ToInt32(Console.ReadLine());
                        try{
                        utility.UpdateMedicinePrice(id,price);}
                        catch(InvalidPriceException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }catch(MedicineNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        // TODO: Add entity
                        string input = Console.ReadLine();
                        string[] parts = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                        try{
                        utility.AddMedicine(new Medicine(parts[0],parts[1],Convert.ToInt32(parts[2]),Convert.ToInt32(parts[3])));}
                        catch(InvalidExpiryYearException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }catch(DuplicateMedicineException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("invalid choice");
                        break;
                }
            }
        }
    }
}

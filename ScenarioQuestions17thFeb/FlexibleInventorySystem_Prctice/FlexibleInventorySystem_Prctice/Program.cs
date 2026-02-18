using System;
using FlexibleInventorySystem_Practice.Services;
using FlexibleInventorySystem_Practice.Models;

namespace FlexibleInventorySystem_Practice
{
    class Program
    {
        private static InventoryManager _inventory = new InventoryManager();

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProductMenu();
                        break;

                    case "2":
                        RemoveProductMenu();
                        break;

                    case "3":
                        UpdateQuantityMenu();
                        break;

                    case "4":
                        FindProductMenu();
                        break;

                    case "5":
                        ViewAllProducts();
                        break;

                    case "6":
                        GenerateReportsMenu();
                        break;

                    case "7":
                        LowStockMenu();
                        break;

                    case "8":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine(" FLEXIBLE INVENTORY SYSTEM ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Update Quantity");
            Console.WriteLine("4. Find Product");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. Generate Reports");
            Console.WriteLine("7. Check Low Stock");
            Console.WriteLine("8. Exit");
            Console.WriteLine("=================================");
        }

        static void AddProductMenu()
        {
            Console.WriteLine("Select Product Type:");
            Console.WriteLine("1. Electronic");
            Console.WriteLine("2. Grocery");
            Console.WriteLine("3. Clothing");

            string type = Console.ReadLine();

            Console.Write("Enter ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Product product = null;

            switch (type)
            {
                case "1":
                    ElectronicProduct ep = new ElectronicProduct();

                    ep.Id = id;
                    ep.Name = name;
                    ep.Price = price;
                    ep.Quantity = quantity;
                    ep.Category = "Electronics";
                    ep.DateAdded = DateTime.Now;

                    Console.Write("Enter Brand: ");
                    ep.Brand = Console.ReadLine();

                    Console.Write("Enter Warranty Months: ");
                    ep.WarrantyMonths = int.Parse(Console.ReadLine());

                    Console.Write("Enter Voltage: ");
                    ep.Voltage = Console.ReadLine();

                    product = ep;
                    break;

                case "2":
                    GroceryProduct gp = new GroceryProduct();

                    gp.Id = id;
                    gp.Name = name;
                    gp.Price = price;
                    gp.Quantity = quantity;
                    gp.Category = "Groceries";
                    gp.DateAdded = DateTime.Now;

                    Console.Write("Enter Expiry Date (yyyy-MM-dd): ");
                    gp.ExpiryDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter Weight: ");
                    gp.Weight = double.Parse(Console.ReadLine());

                    Console.Write("Enter Storage Temperature: ");
                    gp.StorageTemperature = Console.ReadLine();

                    product = gp;
                    break;

                case "3":
                    ClothingProduct cp = new ClothingProduct();

                    cp.Id = id;
                    cp.Name = name;
                    cp.Price = price;
                    cp.Quantity = quantity;
                    cp.Category = "Clothing";
                    cp.DateAdded = DateTime.Now;

                    Console.Write("Enter Size: ");
                    cp.Size = Console.ReadLine();

                    Console.Write("Enter Color: ");
                    cp.Color = Console.ReadLine();

                    Console.Write("Enter Material: ");
                    cp.Material = Console.ReadLine();

                    Console.Write("Enter Gender: ");
                    cp.Gender = Console.ReadLine();

                    Console.Write("Enter Season: ");
                    cp.Season = Console.ReadLine();

                    product = cp;
                    break;

                default:
                    Console.WriteLine("Invalid product type.");
                    return;
            }

            bool added = _inventory.AddProduct(product);

            if (added)
                Console.WriteLine("Product added successfully.");
            else
                Console.WriteLine("Failed to add product.");
        }

        static void RemoveProductMenu()
        {
            Console.Write("Enter Product ID to remove: ");
            string id = Console.ReadLine();

            if (_inventory.RemoveProduct(id))
                Console.WriteLine("Product removed.");
            else
                Console.WriteLine("Product not found.");
        }

        static void UpdateQuantityMenu()
        {
            Console.Write("Enter Product ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter New Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            if (_inventory.UpdateQuantity(id, qty))
                Console.WriteLine("Quantity updated.");
            else
                Console.WriteLine("Product not found.");
        }

        static void FindProductMenu()
        {
            Console.Write("Enter Product ID: ");
            string id = Console.ReadLine();

            Product p = _inventory.FindProduct(id);

            if (p != null)
                Console.WriteLine(p.ToString());
            else
                Console.WriteLine("Product not found.");
        }

        static void ViewAllProducts()
        {
            Console.WriteLine(_inventory.GenerateInventoryReport());
        }

        static void GenerateReportsMenu()
        {
            Console.WriteLine("1. Inventory Report");
            Console.WriteLine("2. Category Summary");
            Console.WriteLine("3. Value Report");
            Console.WriteLine("4. Expiry Report");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine(_inventory.GenerateInventoryReport());
                    break;

                case "2":
                    Console.WriteLine(_inventory.GenerateCategorySummary());
                    break;

                case "3":
                    Console.WriteLine(_inventory.GenerateValueReport());
                    break;

                case "4":
                    Console.Write("Enter days threshold: ");
                    int days = int.Parse(Console.ReadLine());
                    Console.WriteLine(_inventory.GenerateExpiryReport(days));
                    break;
            }
        }

        static void LowStockMenu()
        {
            Console.Write("Enter threshold: ");
            int threshold = int.Parse(Console.ReadLine());

            var products = _inventory.GetLowStockProducts(threshold);

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Id} - {p.Name} - Qty: {p.Quantity}");
            }
        }
    }
}

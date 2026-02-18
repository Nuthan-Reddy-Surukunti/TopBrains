using System;
using System.Collections.Generic;
using System.Linq;

public enum OrderStatus
{
    Placed,
    Shipped,
    Cancelled
}

public class OutOfStockException : Exception
{
    public OutOfStockException(string message) : base(message) { }
}

public class OrderAlreadyShippedException : Exception
{
    public OrderAlreadyShippedException(string message) : base(message) { }
}

public class CustomerBlacklistedException : Exception
{
    public CustomerBlacklistedException(string message) : base(message) { }
}

#region Entities
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
}

public class Customer
{
    public string CustomerId { get; set; }
    public string Name { get; set; }
    public bool IsBlacklisted { get; set; }
}

public class OrderItem
{
    public Product product { get; set; }
    public int Quantity { get; set; }

    public double TotalPrice()
    {
        return product.Price * Quantity;
    }
}

public class Order
{
    public int OrderId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> orderItems { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus OrderStatus { get; set; }
}
#endregion

#region Discount Strategy
public interface IDiscountStrategy
{
    double ApplyDiscount(double totalAmount);
}

public class PercentageDiscount : IDiscountStrategy
{
    public int Percentage { get; set; }

    public PercentageDiscount(int percentage)
    {
        Percentage = percentage;
    }

    public double ApplyDiscount(double totalAmount)
    {
        return totalAmount * Percentage / 100;
    }
}

public class FlatDiscount : IDiscountStrategy
{
    public double ApplyDiscount(double totalAmount)
    {
        return totalAmount * 0.10;
    }
}

public class FestivalDiscount : IDiscountStrategy
{
    public double ApplyDiscount(double totalAmount)
    {
        return totalAmount * 0.25;
    }
}
#endregion

#region Order Management System
public class OrderManagement
{
    public static List<Product> products = new List<Product>();
    public static List<Customer> customers = new List<Customer>();
    public static List<Order> orders = new List<Order>();

    public Dictionary<int, Product> ProductMap = new Dictionary<int, Product>();

    public void AddProduct(Product product)
    {
        var check = products.Any(i => i.Id == product.Id);
        if (!check)
        {
            products.Add(product);
        }
        else Console.WriteLine("product already exists");
    }

    public void AddCustomer(Customer customer)
    {
        var check = customers.Any(i => i.CustomerId == customer.CustomerId);
        if (!check)
        {
            customers.Add(customer);
        }
        else Console.WriteLine("customer already exists");
    }

    public void PlaceOrder(Order order)
    {
        bool check = orders.Any(i => i.OrderId == order.OrderId);
        if (!check)
        {
            orders.Add(order);
        }
        else Console.WriteLine("order already placed");
    }

    public void CancelOrder(int orderId)
    {
        var check = orders.FirstOrDefault(i => i.OrderId == orderId);
        if (check != null)
        {
            if (check.OrderStatus == OrderStatus.Shipped)
                throw new OrderAlreadyShippedException("Cannot cancel shipped order");

            check.OrderStatus = OrderStatus.Cancelled;
        }
    }

    public void ShipOrder(int orderId)
    {
        var check = orders.FirstOrDefault(i => i.OrderId == orderId);
        if (check != null)
        {
            check.OrderStatus = OrderStatus.Shipped;
        }
    }

    public double ApplyDiscount(Order order, IDiscountStrategy strategy)
    {
        var totalAmount = order.orderItems.Sum(i => i.TotalPrice());
        return strategy.ApplyDiscount(totalAmount);
    }

    public void ShowRecentOrders()
    {
        var lastWeekOrders = orders
            .Where(i => i.OrderDate >= DateTime.Now.AddDays(-7))
            .ToList();

        foreach (var i in lastWeekOrders)
        {
            Console.WriteLine($"{i.OrderId} {i.OrderStatus} {i.OrderDate} {i.Customer.Name}");
            foreach (var j in i.orderItems)
            {
                Console.WriteLine($"{j.product.Name}: {j.Quantity}");
            }
        }
    }

    public double GetTotalRevenue()
    {
        return orders.SelectMany(i => i.orderItems).Sum(g => g.TotalPrice());
    }

    public void GetMostSoldProduct()
    {
        var mostSoldProduct = orders
            .SelectMany(i => i.orderItems)
            .GroupBy(i => i.product)
            .OrderByDescending(i => i.Sum(x => x.Quantity))
            .FirstOrDefault();

        if (mostSoldProduct != null)
        {
            Console.WriteLine($"Most sold product: {mostSoldProduct.Key.Name}");
        }
    }

    public void GetTopCustomers()
    {
        var topCustomers = orders
            .GroupBy(i => i.Customer)
            .Select(g => new
            {
                CustomerName = g.Key,
                TotalAmount = g.Sum(x => x.orderItems.Sum(i => i.TotalPrice()))
            })
            .OrderByDescending(x => x.TotalAmount)
            .Take(5);

        foreach (var customer in topCustomers)
        {
            Console.WriteLine($"{customer.CustomerName.Name} {customer.TotalAmount}");
        }
    }

    public void GroupOrdersByStatus()
    {
        var groupedOrders = orders.GroupBy(o => o.OrderStatus);

        foreach (var group in groupedOrders)
        {
            Console.WriteLine($"{group.Key}: {group.Count()} orders");
        }
    }

    public void GetLowStockProducts()
    {
        var lowStockProducts = products
            .Where(i => i.Stock < 10)
            .OrderBy(i => i.Stock)
            .ToList();

        foreach (var i in lowStockProducts)
        {
            Console.WriteLine($"{i.Name} {i.Stock}");
        }
    }
}
#endregion

class Program
{
    static void Main()
    {
        OrderManagement system = new OrderManagement();

        // Products
        Product p1 = new Product { Id = 1, Name = "Laptop", Price = 50000, Stock = 5 };
        Product p2 = new Product { Id = 2, Name = "Mouse", Price = 500, Stock = 20 };
        Product p3 = new Product { Id = 3, Name = "Keyboard", Price = 1500, Stock = 8 };

        system.AddProduct(p1);
        system.AddProduct(p2);
        system.AddProduct(p3);

        // Customers
        Customer c1 = new Customer { CustomerId = "C1", Name = "Rahul", IsBlacklisted = false };
        Customer c2 = new Customer { CustomerId = "C2", Name = "Amit", IsBlacklisted = false };

        system.AddCustomer(c1);
        system.AddCustomer(c2);

        // Order items
        List<OrderItem> items1 = new List<OrderItem>
        {
            new OrderItem { product = p1, Quantity = 1 },
            new OrderItem { product = p2, Quantity = 2 }
        };

        List<OrderItem> items2 = new List<OrderItem>
        {
            new OrderItem { product = p3, Quantity = 1 },
            new OrderItem { product = p2, Quantity = 3 }
        };

        // Orders
        Order o1 = new Order
        {
            OrderId = 101,
            Customer = c1,
            orderItems = items1,
            OrderStatus = OrderStatus.Placed,
            OrderDate = DateTime.Now
        };

        Order o2 = new Order
        {
            OrderId = 102,
            Customer = c2,
            orderItems = items2,
            OrderStatus = OrderStatus.Placed,
            OrderDate = DateTime.Now.AddDays(-3)
        };

        system.PlaceOrder(o1);
        system.PlaceOrder(o2);

        // Discount
        IDiscountStrategy discount = new PercentageDiscount(10);
        double finalAmount = system.ApplyDiscount(o1, discount);
        Console.WriteLine($"Discounted amount for Order 101: {finalAmount}");

        // Ship order
        system.ShipOrder(101);

        // Outputs
        Console.WriteLine("\nMost Sold Product:");
        system.GetMostSoldProduct();

        Console.WriteLine("\nTop Customers:");
        system.GetTopCustomers();

        Console.WriteLine("\nLow Stock Products:");
        system.GetLowStockProducts();

        Console.WriteLine("\nOrders Grouped by Status:");
        system.GroupOrdersByStatus();
    }
}

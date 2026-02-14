class Book
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
}
class BookUtility
{
    
    public void GetBookDetails()
    {
        Book book = Program.book;
        Console.WriteLine($"Details: {book.Id} {book.Title} {book.Price} {book.Stock}");
        
    }
    public int UpdateBookPrice(int newPrice)
    {
        Program.book.Price=newPrice;
        return newPrice;
    }
    public int UpdateBookStock(int newStock)
    {
        Program.book.Stock=newStock;
        return newStock;
    }
}
class Program
{
    public static Book book = new Book();
    public static void Main()
    {
        string input = Console.ReadLine();
        string[] parts = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
        book.Id =parts[0];
        book.Title=parts[1];
        book.Price = Convert.ToInt32(parts[2]);
        book.Stock = Convert.ToInt32(parts[3]);
        while (true)
        {
            BookUtility bookUtility = new BookUtility();
            Console.WriteLine("1 → Display book details\n2 → Update book price \n3 → Update book stock \n4 → Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    bookUtility.GetBookDetails();
                    break;
                case 2:
                    int Price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Updated Price: "+bookUtility.UpdateBookPrice(Price));
                    break;
                case 3:
                    int Stock = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Updated Stock: "+bookUtility.UpdateBookStock(Stock));
                    break;
                case 4:
                    Console.WriteLine("Thank You");
                    return;
            }
        }
    }
}
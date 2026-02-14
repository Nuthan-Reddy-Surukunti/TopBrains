// class Program
// {
//     public static List<Book> bookList = new List<Book>();
//     public static void Main()
//     {
//         LibraryUtility library = new LibraryUtility();
//         while (true)
//         {
//             Console.WriteLine("1. Admin - Add Book");
//             Console.WriteLine("2. Admin - Update Book");
//             Console.WriteLine("3. User - Search Book by Name");
//             Console.WriteLine("4. User - View Price Extremes");
//             int choice = Convert.ToInt32(Console.ReadLine());
//             if (choice == 5)
//             {
//                 break;
//             }
//             switch (choice)
//             {
//                 case 1:
//                     Console.Write("Enter ID :");
//                     int BookId = Convert.ToInt32(Console.ReadLine());
//                     Console.Write("Enter Title :");
//                     string Title = Console.ReadLine();
//                     Console.Write("Enter Publisher :");
//                     string Publisher = Console.ReadLine();
//                     Console.Write("Enter Price :");
//                     double Price = Convert.ToDouble(Console.ReadLine());
//                     library.AddBook(new Book { BookId = BookId, Title = Title, Publisher = Publisher, Price = Price });
//                     break;
//                 case 2:
//                     Console.Write("Enter ID :");
//                     int id = Convert.ToInt32(Console.ReadLine());
//                     Console.Write("Enter New Price :");
//                     double newPrice = Convert.ToDouble(Console.ReadLine());
//                     if (library.UpdateBook(id, newPrice))
//                     {
//                         Console.WriteLine("Book updated successfully.");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Book not found.");
//                     }
//                     break;
//                 case 3:
//                     Console.Write("Enter Title :");
//                     string name = Console.ReadLine();
//                     var result = library.SearchByName(name);
//                     foreach (var item in result)                    {
//                         Console.WriteLine($"ID : {item.BookId} Title : {item.Title} Publisher : {item.Publisher} Price : {item.Price}");
//                     }
//                     break;
//                 case 4:
//                     Console.Write("View Price Extrems :");
//                     var highest = library.GetHighestPricedBook();
//                     var lowest = library.GetLowertPriceBook();
//                     Console.WriteLine($"Highest Priced Book: ID : {highest.BookId} Title : {highest.Title} Publisher : {highest.Publisher} Price : {highest.Price}");
//                     Console.WriteLine($"Lowest Priced Book: ID : {lowest.BookId} Title : {lowest.Title} Publisher : {lowest.Publisher} Price : {lowest.Price}");
//                     break;

//             }
//         }
//     }
// }
// class Book
// {
//     public int BookId { get; set; }
//     public string Title { get; set; }
//     public string Publisher { get; set; }
//     public double Price { get; set; }
// }
// class LibraryUtility
// {
    
//     public void AddBook(dynamic book)
//     {
//         if (!Program.bookList.Contains(book.BookId))
//         {
//             Program.bookList.Add(book);
//         }
//     }
//     public bool UpdateBook(int id,double newPrice)
//     {
//         var check = Program.bookList.Find(i=>i.BookId==id);
//         if (check != null)
//         {
//             check.Price = newPrice;
//             return true;
//         }
//         return false;
//     }
//     public bool DeleteBook(int id)
//     {
//         var check = Program.bookList.Find(i=>i.BookId==id);
//         if (check != null)
//         {
//             Program.bookList.Remove(check);
//             return true;
//         }
//         return false;
//     }
//     public List<Book> SearchByName(string name)
//     {
//         return Program.bookList.FindAll(i=>i.Title==name);
//     }
//     public List<Book> SearchByPublisher(string pub)
//     {
//         return Program.bookList.FindAll(i=>i.Publisher==pub);
//     }
//     public Book GetHighestPricedBook()
//     {
//         return Program.bookList.OrderByDescending(i=>i.Price).First();
//     }
//     public Book GetLowertPriceBook()
//     {
//         return Program.bookList.OrderBy(i=>i.Price).First();
//     }
// } 
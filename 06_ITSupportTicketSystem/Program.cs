using System;
using Services;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketUtility ticketUtility = new TicketUtility();

            while (true)
            {
                Console.WriteLine("1. Display Tickets by Priority");
                Console.WriteLine("2. Esclate Ticket");
                Console.WriteLine("3. Add Ticket");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = Convert.ToInt32(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                            ticketUtility.DisplayTickets();
                        break;
                    case 2:
                        // TODO: Add entity
                            Console.WriteLine("Enter Ticket ID to escalate:");
                            string ticketId = Console.ReadLine();
                            Console.WriteLine("Enter new severity level:");
                            int newSeverity = Convert.ToInt32(Console.ReadLine());
                            ticketUtility.UpdateEntity(ticketId, newSeverity);
                        break;
                    case 3:
                        // TODO: Update entity
                            Console.WriteLine("Enter Ticket ID:");
                            string newTicketId = Console.ReadLine();
                            Console.WriteLine("Enter Issue Description:");
                            string issueDescription = Console.ReadLine();
                            Console.WriteLine("Enter Severity Level (0-10):");
                            int severityLevel = Convert.ToInt32(Console.ReadLine());
                            ticketUtility.AddTicket(new Domain.Ticket(newTicketId, issueDescription, severityLevel));
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

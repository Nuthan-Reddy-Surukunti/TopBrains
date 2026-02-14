using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class TicketUtility
    {
        public static SortedDictionary<int, Queue<Ticket>> Tickets = new SortedDictionary<int, Queue<Ticket>>();

        public void AddTicket(Ticket ticket)
        {
            // TODO: Validate entity
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
            if(ticket.SecurityLevel<0||ticket.SecurityLevel>10) 
            throw new InvalidSeverityException("Invalid severity level");
            if (!Tickets.ContainsKey(ticket.SecurityLevel))
            {
                Tickets[ticket.SecurityLevel] = new Queue<Ticket>();
            }
            Tickets[ticket.SecurityLevel].Enqueue(ticket);
        }

        public void UpdateEntity(string ticketId,int newSeverity)
        {
            // TODO: Update entity logic
            if(newSeverity<=0) throw new InvalidSeverityException("Severity must be greater than 0");
            var check = Tickets.SelectMany(i=>i.Value).FirstOrDefault(g=>g.TicketId==ticketId);
            if(check==null) throw new TicketNotFoundException("Ticket is not Found");
            Tickets[check.SecurityLevel].Dequeue();
            if (!Tickets.ContainsKey(newSeverity))
            {
                Tickets[newSeverity] = new Queue<Ticket>();
            }
            Tickets[newSeverity].Enqueue(new Ticket(ticketId,check.IssueDescription,newSeverity));
        }

        public void DisplayTickets()
        {
            // TODO: Return sorted entities
            foreach(var i in Tickets)
            {
                foreach(var j in i.Value)
                {
                    Console.WriteLine($"{j.TicketId} {j.IssueDescription} {j.SecurityLevel}");
                }
            }
        }
    }
}

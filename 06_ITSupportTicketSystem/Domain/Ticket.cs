namespace Domain
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public string IssueDescription { get; set; }
        public int SecurityLevel { get; set; }
        public Ticket(string ticketId, string issueDescription, int securityLevel)
        {
            TicketId = ticketId;
            IssueDescription = issueDescription;
            SecurityLevel = securityLevel;
        }
    }
}

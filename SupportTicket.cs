namespace EventTicketingManagement.Models
{
    public class SupportTicket
    {
        public int TicketId { get; set; } // Primary Key
        public int CustomerId { get; set; } // Foreign Key (UserId)
        public string IssueDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; } // E.g., "Open", "Resolved"
        public int? AssignedAgentId { get; set; }
    }
}

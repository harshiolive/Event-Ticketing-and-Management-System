namespace EventTicketingManagement.Models
{
    public class Event
    {
        public int EventId { get; set; } // Primary Key
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int OrganizerId { get; set; } // Foreign Key (UserId)
        public int Capacity { get; set; } // Maximum attendees
        public string TicketTypes { get; set; } // JSON string to define ticket types and prices
        public string Status { get; set; }
    }
}

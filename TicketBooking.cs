namespace EventTicketingManagement.Models
{
    public class TicketBooking
    {
        public int BookingId { get; set; } // Primary Key
        public int EventId { get; set; } // Foreign Key (Event)
        public int CustomerId { get; set; } // Foreign Key (UserId)
        public string TicketType { get; set; } // E.g., "VIP", "General"
        public int Quantity { get; set; } // Number of tickets
        public decimal TotalPrice { get; set; } // Total cost
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
    }
}

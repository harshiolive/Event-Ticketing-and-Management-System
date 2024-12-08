namespace EventTicketingManagement.Models
{
    public class Schedule
    {
        public int PaymentId { get; set; } // Primary Key
        public int BookingId { get; set; } // Foreign Key (TicketBooking)
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; } // E.g., "Credit Card", "PayPal"
        public string PaymentStatus { get; set; } // E.g., "Success", "Failed"
        public DateTime PaymentDate { get; set; }
        public string TransactionId { get; set; }
        public int EventId { get; internal set; }
    }
}

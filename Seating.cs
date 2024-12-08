namespace EventTicketingManagement.Models
{
    public class Seating
    {
        public int SeatingId { get; set; } // Primary Key
        public int EventId { get; set; } // Foreign Key (Event)
        public string SeatNumber { get; set; } // E.g., "A1", "B2"
        public string Row { get; set; }
        public string Section { get; set; }
        public string AvailabilityStatus { get; set; }
    }
}

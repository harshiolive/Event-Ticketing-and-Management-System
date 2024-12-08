namespace EventTicketingManagement.Models
{
    public class Discount
    {
        public int DiscountId { get; set; } // Primary Key
        public int EventId { get; set; } // Foreign Key (Event)
        public string DiscountCode { get; set; }
        public decimal DiscountPercentage { get; set; } // E.g., 10% off
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}

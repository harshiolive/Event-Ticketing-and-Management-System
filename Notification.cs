namespace EventTicketingManagement.Models
{
    public class Notification
    {
        public int NotificationId { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key (User)
        public string Message { get; set; }
        public string Type { get; set; } // E.g., "Email", "SMS"
        public DateTime Timestamp { get; set; } // When the notification was sent
        public bool IsRead { get; set; }
    }
}

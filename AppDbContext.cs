using EventTicketingManagement.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<TicketBooking> TicketBookings { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<CustomerProfile> CustomerProfiles { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Seating> Seatings { get; set; }
    public DbSet<SupportTicket> SupportTickets { get; set; }
}

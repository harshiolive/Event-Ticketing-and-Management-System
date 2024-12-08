using EventTicketingManagement.Models;
using Microsoft.EntityFrameworkCore;

public interface ITicketBookingService
{
    Task<TicketBooking> BookTicketAsync(TicketBooking booking);
    Task<TicketBooking> GetBookingByIdAsync(int bookingId);
    Task<List<TicketBooking>> GetAllBookingsAsync();
    Task CancelBookingAsync(int bookingId);
    Task GetBookingsByCustomerIdAsync(int customerId);
}

public class TicketBookingService : ITicketBookingService
{
    private readonly ApplicationDbContext _context;

    public TicketBookingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TicketBooking> BookTicketAsync(TicketBooking booking)
    {
        var eventEntity = await _context.Events.FindAsync(booking.EventId);

        if (eventEntity == null || eventEntity.Capacity < booking.Quantity)
            throw new Exception("Not enough tickets available.");

        eventEntity.Capacity -= booking.Quantity;
        await _context.TicketBookings.AddAsync(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task<TicketBooking> GetBookingByIdAsync(int bookingId)
    {
        return await _context.TicketBookings.FindAsync(bookingId);
    }

    public async Task<List<TicketBooking>> GetAllBookingsAsync()
    {
        return await _context.TicketBookings.ToListAsync();
    }

    public async Task CancelBookingAsync(int bookingId)
    {
        var booking = await _context.TicketBookings.FindAsync(bookingId);
        if (booking != null)
        {
            _context.TicketBookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }

    public Task GetBookingsByCustomerIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }
}

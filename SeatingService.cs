using EventTicketingManagement.Models;
using Microsoft.EntityFrameworkCore;

public interface ISeatingService
{
    Task<List<Seating>> GetSeatingByEventIdAsync(int eventId);
    Task UpdateSeatingAvailabilityAsync(int seatingId, string status);
    Task AddSeatingLayoutAsync(List<Seating> seatings);
}
public class SeatingService : ISeatingService
{
    private readonly ApplicationDbContext _context;

    public SeatingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Seating>> GetSeatingByEventIdAsync(int eventId)
    {
        return await _context.Seatings
            .Where(s => s.EventId == eventId)
            .ToListAsync();
    }

    public async Task UpdateSeatingAvailabilityAsync(int seatingId, string status)
    {
        var seating = await _context.Seatings.FindAsync(seatingId);
        if (seating != null)
        {
            seating.AvailabilityStatus = status;
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddSeatingLayoutAsync(List<Seating> seatings)
    {
        await _context.Seatings.AddRangeAsync(seatings);
        await _context.SaveChangesAsync();
    }
}

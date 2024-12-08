using EventTicketingManagement.Models;
using Microsoft.EntityFrameworkCore;
public interface IEventService
{
    Task<Event> CreateEventAsync(Event eventData);
    Task<Event> GetEventByIdAsync(int eventId);
    Task<List<Event>> GetAllEventsAsync();
    Task UpdateEventAsync(Event eventData);
    Task DeleteEventAsync(int eventId);
}

public class EventService : IEventService
{
    private readonly ApplicationDbContext _context;

    public EventService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Event> CreateEventAsync(Event eventData)
    {
        await _context.Events.AddAsync(eventData);
        await _context.SaveChangesAsync();
        return eventData;
    }

    public async Task<Event> GetEventByIdAsync(int eventId)
    {
        return await _context.Events.FindAsync(eventId);
    }

    public async Task<List<Event>> GetAllEventsAsync()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task UpdateEventAsync(Event eventData)
    {
        _context.Events.Update(eventData);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(int eventId)
    {
        var eventEntity = await _context.Events.FindAsync(eventId);
        if (eventEntity != null)
        {
            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();
        }
    }
}

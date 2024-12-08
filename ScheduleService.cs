using EventTicketingManagement.Models;
using Microsoft.EntityFrameworkCore;

public interface IScheduleService
{
    Task<Schedule> AddScheduleAsync(Schedule schedule);
    Task<List<Schedule>> GetSchedulesByEventIdAsync(int eventId);
    Task<Schedule> GetScheduleByIdAsync(int scheduleId);
    Task UpdateScheduleAsync(Schedule schedule);
    Task DeleteScheduleAsync(int scheduleId);
}
public class ScheduleService : IScheduleService
{
    private readonly ApplicationDbContext _context;

    public ScheduleService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Schedule> AddScheduleAsync(Schedule schedule)
    {
        await _context.Schedules.AddAsync(schedule);
        await _context.SaveChangesAsync();
        return schedule;
    }

    public async Task<List<Schedule>> GetSchedulesByEventIdAsync(int eventId)
    {
        return await _context.Schedules
            .Where(s => s.EventId == eventId)
            .ToListAsync();
    }

    public async Task<Schedule> GetScheduleByIdAsync(int scheduleId)
    {
        return await _context.Schedules.FindAsync(scheduleId);
    }

    public async Task UpdateScheduleAsync(Schedule schedule)
    {
        _context.Schedules.Update(schedule);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteScheduleAsync(int scheduleId)
    {
        var schedule = await _context.Schedules.FindAsync(scheduleId);
        if (schedule != null)
        {
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
        }
    }
}

using EventTicketingManagement.Models;
using Microsoft.EntityFrameworkCore;

public interface INotificationService
{
    Task SendNotificationAsync(Notification notification);
    Task<List<Notification>> GetUserNotificationsAsync(int userId);
}
public class NotificationService : INotificationService
{
    private readonly ApplicationDbContext _context;

    public NotificationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SendNotificationAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Notification>> GetUserNotificationsAsync(int userId)
    {
        return await _context.Notifications
            .Where(n => n.UserId == userId)
            .ToListAsync();
    }
}

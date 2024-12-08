using EventTicketingManagement.Models;
using Microsoft.EntityFrameworkCore;

public interface ISupportTicketService
{
    Task<SupportTicket> CreateTicketAsync(SupportTicket ticket);
    Task<List<SupportTicket>> GetTicketsByCustomerIdAsync(int customerId);
    Task UpdateTicketStatusAsync(int ticketId, string status, int agentId);
}
public class SupportTicketService : ISupportTicketService
{
    private readonly ApplicationDbContext _context;

    public SupportTicketService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SupportTicket> CreateTicketAsync(SupportTicket ticket)
    {
        await _context.SupportTickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<List<SupportTicket>> GetTicketsByCustomerIdAsync(int customerId)
    {
        return await _context.SupportTickets
            .Where(t => t.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task UpdateTicketStatusAsync(int ticketId, string status, int agentId)
    {
        var ticket = await _context.SupportTickets.FindAsync(ticketId);
        if (ticket != null)
        {
            ticket.Status = status;
            ticket.AssignedAgentId = agentId;
            await _context.SaveChangesAsync();
        }
    }
}

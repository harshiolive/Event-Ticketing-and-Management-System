using EventTicketingManagement.Models;
using Microsoft.EntityFrameworkCore;

public interface IPaymentService
{
    Task<Payment> ProcessPaymentAsync(Payment payment);
    Task<List<Payment>> GetPaymentHistoryAsync(int customerId);
}
public class PaymentService : IPaymentService
{
    private readonly ApplicationDbContext _context;

    public PaymentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Payment> ProcessPaymentAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<List<Payment>> GetPaymentHistoryAsync(int customerId)
    {
        return await _context.Payments
            .ToListAsync();
    }
}

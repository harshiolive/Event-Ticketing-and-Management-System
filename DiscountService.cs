using EventTicketingManagement.Models;
using Microsoft.EntityFrameworkCore;

public interface IDiscountService
{
    Task<Discount> CreateDiscountAsync(Discount discount);
    Task<List<Discount>> GetDiscountsByEventIdAsync(int eventId);
    Task<Discount> GetDiscountByCodeAsync(string code);
    Task UpdateDiscountAsync(Discount discount);
    Task DeleteDiscountAsync(int discountId);
}
public class DiscountService : IDiscountService
{
    private readonly ApplicationDbContext _context;

    public DiscountService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Discount> CreateDiscountAsync(Discount discount)
    {
        await _context.Discounts.AddAsync(discount);
        await _context.SaveChangesAsync();
        return discount;
    }

    public async Task<List<Discount>> GetDiscountsByEventIdAsync(int eventId)
    {
        return await _context.Discounts
            .Where(d => d.EventId == eventId)
            .ToListAsync();
    }

    public async Task<Discount> GetDiscountByCodeAsync(string code)
    {
        return await _context.Discounts
            .FirstOrDefaultAsync(d => d.DiscountCode == code && d.Status == "Active");
    }

    public async Task UpdateDiscountAsync(Discount discount)
    {
        _context.Discounts.Update(discount);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDiscountAsync(int discountId)
    {
        var discount = await _context.Discounts.FindAsync(discountId);
        if (discount != null)
        {
            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();
        }
    }
}

using EventTicketingManagement.Models;
using Microsoft.EntityFrameworkCore;

public interface ICustomerProfileService
{
    Task<CustomerProfile> GetCustomerProfileAsync(int customerId);
    Task UpdateCustomerProfileAsync(CustomerProfile profile);
    Task<List<CustomerProfile>> GetAllCustomersAsync();
}
public class CustomerProfileService : ICustomerProfileService
{
    private readonly ApplicationDbContext _context;

    public CustomerProfileService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerProfile> GetCustomerProfileAsync(int customerId)
    {
        return await _context.CustomerProfiles.FindAsync(customerId);
    }

    public async Task UpdateCustomerProfileAsync(CustomerProfile profile)
    {
        _context.CustomerProfiles.Update(profile);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CustomerProfile>> GetAllCustomersAsync()
    {
        return await _context.CustomerProfiles.ToListAsync();
    }
}


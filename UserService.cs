using Microsoft.EntityFrameworkCore;

public interface IUserService
{
    Task<User> AuthenticateAsync(string username, string password);
    Task<User> RegisterAsync(User user, string password);
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int userId);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int userId);
    Task<string?> LoginAsync(string username, string password);
    Task RegisterUserAsync(User user);
    Task DeactivateUserAsync(int userId);
}
public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly ITokenService _tokenService;

    public UserService(ApplicationDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<User> AuthenticateAsync(string username, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return null;

        return user;
    }

    public async Task<User> RegisterAsync(User user, string password)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public Task<string?> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task RegisterUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeactivateUserAsync(int userId)
    {
        throw new NotImplementedException();
    }
}

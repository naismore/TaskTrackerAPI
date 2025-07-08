using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Backend.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MyDbContext _context;

    public UserRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetUserListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<(bool success, User? user)> CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0 ? (true, user) : (false, null);
    }
}
public interface IUserRepository
{
    Task<List<User>> GetUserListAsync();
    Task<(bool success, User? user)> CreateUserAsync(User user);
}
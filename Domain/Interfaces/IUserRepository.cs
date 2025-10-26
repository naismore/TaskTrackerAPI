using Domain.Models;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetListAsync();
    void Insert(User user);
}
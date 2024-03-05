using NuevoCreditoAPI.NuevoCredito.Domain.Models;

namespace NuevoCreditoAPI.NuevoCredito.Domain.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    void Update(User user);
    void Remove(User user);

    Task<User> FindByIdAsync(int id);
    Task<User> FindByEmailAsync(string email);
    Task<User> FindByEmailAndPasswordAsync(string email, string password);
}
using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.NuevoCredito.Domain.Services.Communication;

namespace NuevoCreditoAPI.NuevoCredito.Domain.Services;

public interface IUserService
{
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> UpdateAsync(int id, User user);
    Task<UserResponse> DeleteAsync(int id);
}
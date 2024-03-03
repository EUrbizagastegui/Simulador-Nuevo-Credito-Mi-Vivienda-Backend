using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.Shared.Domain.Services.Communication;

namespace NuevoCreditoAPI.NuevoCredito.Domain.Services.Communication;

public class UserResponse: BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {
    }

    public UserResponse(User resource) : base(resource)
    {
    }
}
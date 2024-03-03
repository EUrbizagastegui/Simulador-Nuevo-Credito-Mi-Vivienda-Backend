using NuevoCreditoAPI.NuevoCredito.Domain.Models;

namespace NuevoCreditoAPI.NuevoCredito.Resources;

public class UserResource
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public List<PaymentSchedule> PaymentSchedules { get; set; }
}
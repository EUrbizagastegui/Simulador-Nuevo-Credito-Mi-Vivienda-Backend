using NuevoCreditoAPI.NuevoCredito.Domain.Models;

namespace NuevoCreditoAPI.NuevoCredito.Domain.Repositories;

public interface IPaymentScheduleRespository
{
    Task<IEnumerable<PaymentSchedule>> ListAsync();
    Task AddAsync(PaymentSchedule paymentSchedule);
    Task<PaymentSchedule> FindByIdAsync(int paymentScheduleId);
    Task<PaymentSchedule> FindByUsernameAsync(string username);
    Task<IEnumerable<PaymentSchedule>> FindByUserIdAsync(int userId);
    void Update(PaymentSchedule paymentSchedule);
    void Remove(PaymentSchedule paymentSchedule);
}
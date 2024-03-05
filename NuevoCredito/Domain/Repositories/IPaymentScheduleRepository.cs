using NuevoCreditoAPI.NuevoCredito.Domain.Models;

namespace NuevoCreditoAPI.NuevoCredito.Domain.Repositories;

public interface IPaymentScheduleRepository
{
    Task AddAsync(PaymentSchedule paymentSchedule);
    void Update(PaymentSchedule paymentSchedule);
    void Remove(PaymentSchedule paymentSchedule);
    Task<IEnumerable<PaymentSchedule>> FindByUserIdAsync(int userId);
    Task<PaymentSchedule> FindByIdAsync(int paymentScheduleId);
}
using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.NuevoCredito.Domain.Services.Communication;

namespace NuevoCreditoAPI.NuevoCredito.Domain.Services;

public interface IPaymentScheduleService
{
    Task<IEnumerable<PaymentSchedule>> ListAsync();
    Task<IEnumerable<PaymentSchedule>> ListByUserIdAsync(int userId);
    Task<PaymentScheduleResponse> SaveAsync(PaymentSchedule paymentSchedule);
    Task<PaymentScheduleResponse> UpdateAsync(int paymentScheduleId, PaymentSchedule paymentSchedule);
    Task<PaymentScheduleResponse> DeleteAsync(int paymentScheduleId);
}
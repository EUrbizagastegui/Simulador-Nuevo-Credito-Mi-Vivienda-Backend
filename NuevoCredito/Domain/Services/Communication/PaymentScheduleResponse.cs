using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.Shared.Domain.Services.Communication;

namespace NuevoCreditoAPI.NuevoCredito.Domain.Services.Communication;

public class PaymentScheduleResponse:BaseResponse<PaymentSchedule>
{
    public PaymentScheduleResponse(string message) : base(message)
    {
    }

    public PaymentScheduleResponse(PaymentSchedule resource) : base(resource)
    {
    }
}
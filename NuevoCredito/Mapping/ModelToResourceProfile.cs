using AutoMapper;
using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.NuevoCredito.Resources;

namespace NuevoCreditoAPI.NuevoCredito.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
        CreateMap<PaymentSchedule, PaymentScheduleResource>();
    }
}
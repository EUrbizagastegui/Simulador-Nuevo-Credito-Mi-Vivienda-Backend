using AutoMapper;
using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.NuevoCredito.Resources;

namespace NuevoCreditoAPI.NuevoCredito.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveUserResource, User>();
        CreateMap<UpdateUserResource, User>();
        CreateMap<SavePaymentScheduleResource, PaymentSchedule>();
        CreateMap<UpdatePaymentScheduleResource, PaymentSchedule>();
    }
}